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
        private readonly EmployeeRepository employeeRepository;
        private readonly EmployeeTableFormHelper employeeTableFormHelper;
        private List<Employee> employees;
        private GridFilterParameters filterParameters;

        public EmployeeTableForm()
        {
            filterParameters = new GridFilterParameters{Representations = new List<string>()};
            employeeRepository = new EmployeeRepository();
            employeeTableFormHelper = new EmployeeTableFormHelper(employeeRepository);
            InitializeComponent();
            dgvEmployees.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        class PageOffsetList : System.ComponentModel.IListSource
        {
            private readonly int count;

            public PageOffsetList(int count)
            {
                this.count = count;
            }

            public bool ContainsListCollection { get; protected set; }

            public System.Collections.IList GetList()
            {
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < count; offset += 50)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }

        private void bsPaging_CurrentChanged(object sender, EventArgs e)
        {
            int offset = (int)bsPaging.Current;
            dgvEmployees.Rows.Clear();
            for (int i = offset; i < offset + 50 && i < employees.Count; i++)
                dgvEmployees.Rows.Add(employees[i].FullName, employees[i].Representation,
                    employees[i].HoursFullDays / 8, employees[i].HoursPartialDays, employees[i].Comment);
        }

        private void EmployeeTableForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();
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

        private void LoadEmployees()
        {
            dgvEmployees.Rows.Clear();
            employees = employeeRepository.GetWorkingEmployees().OrderBy(e => e.FullName).ToList();

            foreach (var employee in employees)
                dgvEmployees.Rows.Add(employee.FullName, employee.Representation,
                    employee.HoursFullDays / 8, employee.HoursPartialDays, employee.Comment);
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
                LoadEmployees();
                return;
            }

            dgvEmployees.Rows.Clear();
            var filteredEmployees = employeeRepository.GetEmployeesWithFullNameBegin(input.Text);

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

            LoadEmployees();
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
            var gridFilter = new GridFilterForm(employees, filterParameters);

            if (gridFilter.ShowDialog() == DialogResult.OK)
            {
                filterParameters = gridFilter.Parameters;
                LoadGridWith(gridFilter.Parameters);
            }
        }

        private void LoadGridWith(GridFilterParameters parameters)
        {
            dgvEmployees.Rows.Clear();
            var fiteredEmployees = employeeRepository.GetEmployeesWith(parameters).ToList();

            foreach (var employee in fiteredEmployees)
                dgvEmployees.Rows.Add(employee.FullName, employee.Representation,
                    employee.HoursFullDays / 8, employee.HoursPartialDays, employee.Comment);
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
                LoadEmployees();
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

                LoadEmployees();
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void cbPaging_CheckedChanged(object sender, EventArgs e)
        {
            bnPaging.Visible = cbPaging.Checked;
            if (cbPaging.Checked)
            {
                bnPaging.BindingSource = bsPaging;
                bsPaging.CurrentChanged += bsPaging_CurrentChanged;
                bsPaging.DataSource = new PageOffsetList(employees.Count);
            }
            else
            {
                LoadEmployees();
            }
        }
    }
}