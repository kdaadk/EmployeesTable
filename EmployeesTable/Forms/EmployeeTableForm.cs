using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesTable.Import;
using Microsoft.Office.Interop.Excel;
using System.IO;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace EmployeesTable.Forms
{
    public partial class EmployeeTableForm : Form
    {
        private readonly EmployeeRepository employeeRepository;
        private List<Employee> employees;
        private readonly System.Data.DataTable dgvCacheData;
        private readonly StringBuilder Log;

        public EmployeeTableForm()
        {
            InitializeComponent();
            employeeRepository = new EmployeeRepository();
            dgvCacheData = new System.Data.DataTable();
            Log = new StringBuilder();
            }

        private void EmployeeTableForm_Load(object sender, EventArgs e)
        {
            //var dbTransfer = new DbTransfer(employeeRepository);
            //dbTransfer.LoadData();

            LoadEmployees();
            LoadCacheData();
        }

        private void EmployeeTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(@"Вы действительно хотите выйти?", @"Выход", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                    Environment.Exit(0);
                else
                    e.Cancel = true;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void LoadCacheData()
        {
            foreach (DataGridViewColumn col in dgvEmployees.Columns)
                dgvCacheData.Columns.Add(col.Name);

            foreach (DataGridViewRow row in dgvEmployees.Rows)
            {
                var dRow = dgvCacheData.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                    dRow[cell.ColumnIndex] = cell.Value;
                dgvCacheData.Rows.Add(dRow);
            }
        }

        private void LoadEmployees()
        {
            dgvEmployees.Rows.Clear();
            employees = employeeRepository.GetWorkingEmployees().ToList();

            foreach (var employee in employees)
                dgvEmployees.Rows.Add(employee.FullName, employee.Representation,
                    $"{employee.HoursFullDays} — {employee.HoursFullDays / 8}",
                    $"{employee.HoursPartialDays} — {employee.HoursPartialDays / 8}", employee.Comment);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var addData = new AddEmployeeDataForm(new Employee());
            if (addData.ShowDialog() == DialogResult.OK)
            {
                var employee = new Employee
                {
                    ID = Guid.NewGuid().ToString(),
                    FullName = addData.Employee.FullName,
                    Representation = addData.Employee.Representation
                };
                employeeRepository.SaveEmployee($"{employee.FullName}, {employee.Representation}", employee);

                LoadEmployees();
            }
        }

        private void btDeleteSelectRow_Click(object sender, EventArgs e)
        {
            var mbAreYouSure = MessageBox.Show(@"Вы уверены, что хотите удалить запись?", @"Удаление", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (mbAreYouSure == DialogResult.No)
                return;

            var rowIndex = dgvEmployees.SelectedCells[0].RowIndex;
            var selectedFullName = dgvEmployees.Rows[rowIndex].Cells[0].Value.ToString();
            var selectedRepresentation = dgvEmployees.Rows[rowIndex].Cells[1].Value.ToString();
            var id = $"{selectedFullName}, {selectedRepresentation}";
            employeeRepository.DeleteEmployee(id);
            dgvEmployees.Rows.RemoveAt(rowIndex);
        }

        private void employeesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = dgvEmployees.Rows[dgvEmployees.SelectedCells[0].RowIndex];
            var selectedFullName = selectedRow.Cells[0].Value.ToString();
            var selectedRepresentation = selectedRow.Cells[1].Value.ToString();
            var id = $"{selectedFullName}, {selectedRepresentation}";
            var employee = employeeRepository.GetEmployeeById(id);

            if (e.ColumnIndex == 2)
            {
                var detalization = new FullDayDetalizationForm(id, employeeRepository);
                detalization.ShowDialog();
                selectedRow.Cells[2].Value = $"{employee.HoursFullDays} — {employee.HoursFullDays / 8}";
            }

            if (e.ColumnIndex == 3)
            {
                var detalization = new PartialDayDetalizationForm(id, employeeRepository);
                detalization.ShowDialog();
                selectedRow.Cells[3].Value = $"{employee.HoursPartialDays} — {employee.HoursPartialDays / 8}";
            }


        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvEmployees.Rows[dgvEmployees.SelectedCells[0].RowIndex];
            var selectedFullName = selectedRow.Cells[0].Value.ToString();
            var selectedRepresentation = selectedRow.Cells[1].Value.ToString();
            var id = $"{selectedFullName}, {selectedRepresentation}";
            var editData = new AddEmployeeDataForm(employeeRepository.GetEmployeeById(id));

            if (editData.ShowDialog() == DialogResult.OK)
            {
                var employee = new Employee {
                    FullName = editData.Employee.FullName,
                    Representation = editData.Employee.Representation,
                    Comment = editData.Employee.Comment,
                    Fired = editData.Employee.Fired
                };

                employeeRepository.UpdateEmployee(id, employee);
                selectedRow.Cells[0].Value = employee.FullName;
                selectedRow.Cells[1].Value = employee.Representation;
                selectedRow.Cells[4].Value = employee.Comment;
            }
        }

        private void tstbFullNameSearcher_TextChanged(object sender, EventArgs e)
        {
            var input = (ToolStripTextBox) sender;

            if (string.IsNullOrWhiteSpace(input.Text))
            {
                LoadEmployees();
                return;
            }

            var dt = new System.Data.DataTable();
            foreach (DataGridViewColumn col in dgvEmployees.Columns)
                dt.Columns.Add(col.Name);

            foreach (DataRow row in dgvCacheData.Rows)
                if (row.ItemArray[0] != null && row.ItemArray[0].ToString().StartsWith(input.Text))
                    dt.Rows.Add(row.ItemArray[0], row.ItemArray[1], row.ItemArray[2], row.ItemArray[3],
                        row.ItemArray[4]);

            if (dt.Rows.Count != 0)
            {
                dgvEmployees.Rows.Clear();
                foreach (DataRow r in dt.Rows)
                    dgvEmployees.Rows.Add(r.ItemArray[0], r.ItemArray[1], r.ItemArray[2], r.ItemArray[3]);
            }
            else
                dgvEmployees.Rows.Clear();
        }

        private async void btLoadOrder_Click(object sender, EventArgs e)
        {
            var parser = new OrderParser();
            string orderPath = null;
            var orderDatas = new List<OrderData>();

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = @"doc files (*.doc;*.docx)|*.doc;*docx";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    orderPath = openFileDialog.FileName;
            }

            pbStatusImportOrder.Visible = true;
            pbStatusImportOrder.Style = ProgressBarStyle.Marquee;
            pbStatusImportOrder.MarqueeAnimationSpeed = 30;

            btImportOrder.Enabled = false;

            if (orderPath != null)
                await Task.Run(() => orderDatas = parser.Parse(orderPath));

            if (orderDatas.Count > 0)
                await Task.Run(() => AddOrderData(parser, orderDatas));

            LoadEmployees();
            btImportOrder.Enabled = true;
            pbStatusImportOrder.Style = ProgressBarStyle.Continuous;
            pbStatusImportOrder.MarqueeAnimationSpeed = 0;
            pbStatusImportOrder.Visible = false;
        }

        private void AddOrderData(OrderParser parser, IEnumerable<OrderData> orderDatas)
        {
            var recordCounter = 0;
            var newEmployeesName = new List<string>();
            var payment = parser.GetPayment();
            foreach (var orderData in orderDatas)
            {
                var id = $"{orderData.FullName}, {orderData.Representation}";
                if (!TryGetAllDetalizations(orderData.WorkDates, payment, out var fDetalizations))
                {
                    MessageBox.Show(@"Некорректный файл", @"Импорт приказа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                recordCounter += fDetalizations.Count;

                if (employeeRepository.GetEmployeeById(id) == null)
                {
                    newEmployeesName.Add(orderData.FullName);
                    var newEmployee = new Employee
                    {
                        FullName = orderData.FullName,
                        Representation = orderData.Representation,
                        FullDayDetalizations = fDetalizations,
                        PartialDayDetalization = new List<PartialDayDetalization>(),
                        Fired = false,
                        HoursFullDays = fDetalizations.Sum(d => d.WorkHours)
                    };
                    employeeRepository.SaveEmployee(id, newEmployee);
                    Log.AppendLine(
                        $"Добавлен: {newEmployee.FullName}, {newEmployee.Representation}");
                    continue;
                }

                foreach (var d in fDetalizations)
                    employeeRepository.AddFullDayDetalization(id, d);
            }

            var path = GetLogPath();
            MessageBox.Show(
                $@"Загружено {recordCounter} записей
Из них новых сотрудников {newEmployeesName.Count}:
Посмотреть их можно в файле: {path}",
                @"Импорт приказа", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GetLogPath()
        {
            var now = DateTime.Now;
            var logPath = $"{Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath)}\\Logs";
            var filePath = $"{logPath}\\{now.ToShortDateString()}.{now.Hour}.{now.Minute}.{now.Second}.txt";

            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);
            File.WriteAllLines(filePath, Log.ToString().Split('\n'));

            return filePath;
        }

        private bool TryGetAllDetalizations(IEnumerable<string> workDates, Payment payment,
            out List<FullDayDetalization> detalizations)
        {
            detalizations = new List<FullDayDetalization>();
            foreach (var workDateLine in workDates)
            {
                if (!DateTime.TryParse(workDateLine, out var workDate))
                    return false;

                switch (payment)
                {
                    case Payment.Rest:
                        detalizations.Add(new FullDayDetalization
                        {
                            Payment = payment,
                            WorkDate = workDate,
                            WorkHours = 8,
                            Used = Used.No
                        });
                        break;
                    case Payment.Money:
                        detalizations.Add(new FullDayDetalization
                        {
                            Payment = payment,
                            WorkDate = workDate,
                            WorkHours = 0,
                            Used = Used.YesFull,
                            RestDate = workDate
                        });
                        break;
                }
            }

            return true;
        }

        private void btExportTable_Click(object sender, EventArgs e)
        {
            CopyAlltoClipboard();
            object misValue = System.Reflection.Missing.Value;
            var xlexcel = new Application {Visible = true};
            var xlWorkBook = xlexcel.Workbooks.Add(misValue);
            var xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.Item[1];
            var CR = (Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void CopyAlltoClipboard()
        {
            dgvEmployees.SelectAll();
            var dataObj = dgvEmployees.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void BtnGridFilter_Click(object sender, EventArgs e)
        {
            var gridFilter = new GridFilterForm(employees);

            if (gridFilter.ShowDialog() == DialogResult.OK)
                LoadGridWith(gridFilter.Parameters);
            
        }

        private void LoadGridWith(GridFilterParameters parameters)
        {
            dgvEmployees.Rows.Clear();
            var fiteredEmployees = employeeRepository.GetEmployeesWith(parameters).ToList();

            foreach (var employee in fiteredEmployees)
                dgvEmployees.Rows.Add(employee.FullName, employee.Representation,
                    $"{employee.HoursFullDays} — {employee.HoursFullDays / 8}",
                    $"{employee.HoursPartialDays} — {employee.HoursPartialDays / 8}", employee.Comment);
        }
    }
}