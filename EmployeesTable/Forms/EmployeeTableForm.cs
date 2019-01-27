using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeesTable.Import;

namespace EmployeesTable.Forms
{
    public partial class EmployeeTableForm : Form
    {
        private Repository repository;
        private EmployeeTableFormHelper employeeTableFormHelper;
        private List<Employee> filteredEmployees;
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
            repository = new Repository();

            //string[] filePaths = Directory.GetFiles
            //(@"C:\Users\klopov\Desktop\PersonalWorks\EmployeesTableNetFramework\EmployeesTable\bin\Debug\tinyDb\Employee\", "*.*",
            //    SearchOption.TopDirectoryOnly);

            //foreach (var filePath in filePaths)
            //{
            //    var text = File.ReadAllLines(filePath);
            //    var changedText = text.Select(t => t.Replace("Representation", "Office"));
            //    File.WriteAllLines(filePath, changedText);
            //}

            var selectedOffices = repository.GetAllEmployees().Select(e => e.Office).Distinct().ToList();
            var allOffices = repository.GetAllEmployees().Select(e => e.Office).Distinct().ToList();
            filterParameters = new GridFilterParameters
            {
                SelectedOffices = selectedOffices,
                AllOffices = allOffices,
                DaysNumberFrom = 0,
                DaysNumberTo = 50,
                AnyDaysNumber = true,
                IsFired = false,
                OfficeGroupName = @"Все",
            };
            employeeTableFormHelper = new EmployeeTableFormHelper(repository);
        }

        private void LoadEmployeesWith(GridFilterParameters parameters)
        {
            dgvEmployees.Rows.Clear();
            filteredEmployees.Clear();

            if (repository.TryGetNewOffices(parameters.AllOffices, out var newOffices))
                parameters.AllOffices.AddRange(newOffices);

            filteredEmployees.AddRange(repository.GetEmployeesWith(parameters));

            foreach (var employee in filteredEmployees)
                dgvEmployees.Rows.Add(employee.FullName, employee.Office,
                    employee.HoursFullDays / 8, employee.HoursPartialDays, employee.Comment);

            slbEmployeesCount.Text = $@"Найдено: {filteredEmployees.Count} {employeeTableFormHelper.GetDeclension(filteredEmployees.Count, "сотрудник", "сотрудника", "сотрудников")}";
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
            var selectedOffice = selectedRow.Cells[1].Value.ToString();
            var id = $"{selectedFullName}, {selectedOffice}";
            var employee = repository.GetEmployeeById(id);

            if (e.ColumnIndex == 2)
            {
                var detalization = new FullDayDetalizationForm(id, repository);
                detalization.ShowDialog();
                selectedRow.Cells[2].Value = employee.HoursFullDays / 8;
            }

            if (e.ColumnIndex == 3)
            {
                var detalization = new PartialDayDetalizationForm(id, repository);
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
            filteredEmployees = repository.GetEmployeesWithFullNameBegin(input.Text).ToList();

            if (filteredEmployees != null)
                foreach (var employee in filteredEmployees)
                    dgvEmployees.Rows.Add(employee.FullName, employee.Office,
                        employee.HoursFullDays / 8, employee.HoursPartialDays);
        }

        private async void btImportOrder_Click(object sender, EventArgs e)
        {
            var parser = new OrderParser(repository);
            string orderPath = null;

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = @"doc files (*.doc;*.docx)|*.doc;*docx";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    orderPath = openFileDialog.FileName;
            }

            EnableProgressBar(false);

            if (orderPath != null && parser.TryParse(orderPath, out var orderData))
                await Task.Run(() => employeeTableFormHelper.AddOrderData(parser, orderData));

            LoadEmployeesWith(filterParameters);
            EnableProgressBar(true);
        }

        private void EnableProgressBar(bool isEnable)
        {
            pbStatusImportOrder.Visible = !isEnable;
            pbStatusImportOrder.Style = isEnable ? ProgressBarStyle.Continuous : ProgressBarStyle.Marquee;
            pbStatusImportOrder.MarqueeAnimationSpeed = isEnable ? 0 : 30;
            btImportOrder.Enabled = isEnable;
        }

        private void btExportTable_Click(object sender, EventArgs e)
        {
            btExportTable.Enabled = false;
            employeeTableFormHelper.ExportTableToExcel(filteredEmployees);
            btExportTable.Enabled = true;
        }

        private void BtnGridFilter_Click(object sender, EventArgs e)
        {
            var gridFilter = new GridFilterForm(filterParameters);

            if (gridFilter.ShowDialog() == DialogResult.OK)
            {
                filterParameters = gridFilter.Parameters;
                LoadEmployeesWith(gridFilter.Parameters);
                var paging = new Paging(bnPaging, bsPaging, dgvEmployees, filteredEmployees);
                paging.Checked();
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
                    Office = addData.Employee.Office
                };
                repository.SaveEmployee($"{employee.FullName}, {employee.Office}", employee);
                LoadEmployeesWith(filterParameters);
            }
        }

        private void btEmployeeEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvEmployees.Rows[dgvEmployees.SelectedCells[0].RowIndex];

            if (selectedRow.Cells[0]?.Value == null)
                return;

            var selectedFullName = selectedRow.Cells[0].Value.ToString();
            var selectedOffice = selectedRow.Cells[1].Value.ToString();
            var id = $"{selectedFullName}, {selectedOffice}";
            var editData = new AddEmployeeDataForm(repository.GetEmployeeById(id), "Редактировать сотрудника");

            if (editData.ShowDialog() == DialogResult.OK)
            {
                if (id != editData.Employee.GetFullNameID)
                    repository.RecreateEmployee(id, editData.Employee);
                else
                    repository.UpdateEmployee(id, editData.Employee);

                LoadEmployeesWith(filterParameters);
            }
        }

        private void btEmployeeDelete_Click(object sender, EventArgs e)
        {
            var rowIndex = dgvEmployees.SelectedCells[0].RowIndex;

            if (dgvEmployees.Rows[rowIndex].Cells[0]?.Value == null)
                return;

            var selectedFullName = dgvEmployees.Rows[rowIndex].Cells[0].Value.ToString();
            var selectedOffice = dgvEmployees.Rows[rowIndex].Cells[1].Value.ToString();
            var id = $"{selectedFullName}, {selectedOffice}";

            var mbAreYouSure = MessageBox.Show(@"Вы уверены, что хотите удалить запись?", @"Удаление",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (mbAreYouSure == DialogResult.No)
                return;

            repository.DeleteEmployee(id);
            dgvEmployees.Rows.RemoveAt(rowIndex);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tstbFullNameSearcher.Control.Text = "";

            if (cbPaging.Checked)
            {
                var paging = new Paging(bnPaging, bsPaging, dgvEmployees, filteredEmployees);
                paging.Checked();
            }
            else
            {
                LoadEmployeesWith(filterParameters);
            }
        }

        private void cbPaging_CheckedChanged(object sender, EventArgs e)
        {
            var paging = new Paging(bnPaging, bsPaging, dgvEmployees, filteredEmployees);

            bnPaging.Visible = cbPaging.Checked;
            if (cbPaging.Checked)
            {
                slbEmployeesCount.Margin = new Padding(210, 3, 1, 3);
                paging.Checked();
            }
            else
            {
                slbEmployeesCount.Margin = new Padding(1, 3, 1, 3);
                LoadEmployeesWith(filterParameters);
            }
        }
    }
}