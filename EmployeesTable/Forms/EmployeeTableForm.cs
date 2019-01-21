using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeesTable.Import;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace EmployeesTable.Forms
{
    public partial class EmployeeTableForm : Form
    {
        private EmployeeRepository employeeRepository;
        private EmployeeTableFormHelper employeeTableFormHelper;
        private List<Employee> filteredEmployees;
        private List<Employee> allEmployees;
        private GridFilterParameters filterParameters;

        public EmployeeTableForm()
        {
            DefineLocalFields();
            InitializeComponent();
            dgvEmployees.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void DefineLocalFields()
        {
            filteredEmployees = new List<Employee>();
            employeeRepository = new EmployeeRepository();
            allEmployees = employeeRepository.GetAllEmployees().ToList();
            filterParameters = new GridFilterParameters
            {
                Representations = allEmployees
                    .Select(e => e.Representation).Distinct().ToList(),
                DaysNumberFrom = 0,
                DaysNumberTo = 50,
                AnyDaysNumber = true,
                IsFired = false,
                RepresentationGroupName = @"Все"
            };
            employeeTableFormHelper = new EmployeeTableFormHelper(employeeRepository);
        }

        private void LoadEmployeesWith(GridFilterParameters parameters)
        {
            dgvEmployees.Rows.Clear();
            filteredEmployees.Clear();
            filteredEmployees.AddRange(employeeRepository.GetEmployeesWith(parameters));

            foreach (var employee in filteredEmployees)
                dgvEmployees.Rows.Add(employee.FullName, employee.Representation,
                    employee.HoursFullDays / 8, employee.HoursPartialDays, employee.Comment);
        }

        private void bsPaging_CurrentChanged(object sender, EventArgs e)
        {
            var offset = (int)bsPaging.Current;
            dgvEmployees.Rows.Clear();
            for (var i = offset; i < offset + 50 && i < filteredEmployees.Count; i++)
                dgvEmployees.Rows.Add(filteredEmployees[i].FullName, filteredEmployees[i].Representation,
                    filteredEmployees[i].HoursFullDays / 8, filteredEmployees[i].HoursPartialDays,
                    filteredEmployees[i].Comment);
        }

        private void EmployeeTableForm_Load(object sender, EventArgs e)
        {
            LoadEmployeesWith(filterParameters);
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

        private void employeesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2 && e.ColumnIndex != 3)
                return;

            var selectedRow = dgvEmployees.Rows[dgvEmployees.SelectedCells[0].RowIndex];

            if (selectedRow.Cells[0]?.Value == null)
                return;

            var selectedFullName = selectedRow.Cells[0].Value.ToString();
            var selectedRepresentation = selectedRow.Cells[1].Value.ToString();
            var id = $"{selectedFullName}, {selectedRepresentation}";
            var employee = employeeRepository.GetEmployeeById(id);

            if (e.ColumnIndex == 2)
            {
                var detalization = new FullDayDetalizationForm(id, employeeRepository);
                detalization.ShowDialog();
                selectedRow.Cells[2].Value = employee.HoursFullDays / 8;
            }

            if (e.ColumnIndex == 3)
            {
                var detalization = new PartialDayDetalizationForm(id, employeeRepository);
                detalization.ShowDialog();
                selectedRow.Cells[3].Value = employee.HoursPartialDays;
            }
        }

        private void tstbFullNameSearcher_TextChanged(object sender, EventArgs e)
        {
            var input = (ToolStripTextBox) sender;

            if (string.IsNullOrWhiteSpace(input.Text))
            {
                LoadEmployeesWith(filterParameters);
                return;
            }

            dgvEmployees.Rows.Clear();
            filteredEmployees = employeeRepository.GetEmployeesWithFullNameBegin(input.Text).ToList();

            if (filteredEmployees != null)
                foreach (var employee in filteredEmployees)
                    dgvEmployees.Rows.Add(employee.FullName, employee.Representation,
                        employee.HoursFullDays / 8, employee.HoursPartialDays);
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
                await Task.Run(() => employeeTableFormHelper.AddOrderData(parser, orderDatas));

            LoadEmployeesWith(filterParameters);
            btImportOrder.Enabled = true;
            pbStatusImportOrder.Style = ProgressBarStyle.Continuous;
            pbStatusImportOrder.MarqueeAnimationSpeed = 0;
            pbStatusImportOrder.Visible = false;
        }

        private void btExportTable_Click(object sender, EventArgs e)
        {
            employeeTableFormHelper.CopyAlltoClipboard(dgvEmployees);
            object misValue = Missing.Value;
            var xlexcel = new Application {Visible = true};
            var xlWorkBook = xlexcel.Workbooks.Add(misValue);
            var xlWorkSheet = (Worksheet) xlWorkBook.Worksheets.Item[1];
            var CR = (Range) xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void BtnGridFilter_Click(object sender, EventArgs e)
        {
            var gridFilter = new GridFilterForm(allEmployees, filterParameters);

            if (gridFilter.ShowDialog() == DialogResult.OK)
            {
                filterParameters = gridFilter.Parameters;
                LoadEmployeesWith(gridFilter.Parameters);
            }
        }

        private void btEmployeeAdd_Click(object sender, EventArgs e)
        {
            var addData = new AddEmployeeDataForm(new Employee(), "Добавить сотрудника");
            if (addData.ShowDialog() == DialogResult.OK)
            {
                var employee = new Employee
                {
                    ID = Guid.NewGuid().ToString(),
                    FullName = addData.Employee.FullName,
                    Representation = addData.Employee.Representation
                };
                employeeRepository.SaveEmployee($"{employee.FullName}, {employee.Representation}", employee);
                LoadEmployeesWith(filterParameters);
            }
        }

        private void btEmployeeEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvEmployees.Rows[dgvEmployees.SelectedCells[0].RowIndex];

            if (selectedRow.Cells[0]?.Value == null)
                return;

            var selectedFullName = selectedRow.Cells[0].Value.ToString();
            var selectedRepresentation = selectedRow.Cells[1].Value.ToString();
            var id = $"{selectedFullName}, {selectedRepresentation}";
            var editData = new AddEmployeeDataForm(employeeRepository.GetEmployeeById(id), "Редактировать сотрудника");

            if (editData.ShowDialog() == DialogResult.OK)
            {
                if (id != editData.Employee.GetFullNameID)
                    employeeRepository.RecreateEmployee(id, editData.Employee);
                else
                    employeeRepository.UpdateEmployee(id, editData.Employee);

                LoadEmployeesWith(filterParameters);
            }
        }

        private void btEmployeeDelete_Click(object sender, EventArgs e)
        {
            var rowIndex = dgvEmployees.SelectedCells[0].RowIndex;

            if (dgvEmployees.Rows[rowIndex].Cells[0]?.Value == null)
                return;

            var selectedFullName = dgvEmployees.Rows[rowIndex].Cells[0].Value.ToString();
            var selectedRepresentation = dgvEmployees.Rows[rowIndex].Cells[1].Value.ToString();
            var id = $"{selectedFullName}, {selectedRepresentation}";

            var mbAreYouSure = MessageBox.Show(@"Вы уверены, что хотите удалить запись?", @"Удаление",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (mbAreYouSure == DialogResult.No)
                return;

            employeeRepository.DeleteEmployee(id);
            dgvEmployees.Rows.RemoveAt(rowIndex);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEmployeesWith(filterParameters);
        }

        private void cbPaging_CheckedChanged(object sender, EventArgs e)
        {
            bnPaging.Visible = cbPaging.Checked;
            if (cbPaging.Checked)
            {
                bnPaging.BindingSource = bsPaging;
                bsPaging.CurrentChanged += bsPaging_CurrentChanged;
                bsPaging.DataSource = new PageOffsetList(filteredEmployees.Count);
            }
            else
            {
                LoadEmployeesWith(filterParameters);
            }
        }
    }
}