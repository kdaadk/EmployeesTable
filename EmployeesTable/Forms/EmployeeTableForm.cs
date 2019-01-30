using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EmployeesTable.Extensions;
using EmployeesTable.Feature.AddEmployee;
using EmployeesTable.Feature.DeleteEmployee;
using EmployeesTable.Feature.EditEmployee;
using EmployeesTable.Feature.ExportExcel;
using EmployeesTable.Feature.FilterEmployee;
using EmployeesTable.Feature.ImportOrder;
using EmployeesTable.Feature.Paging;
using EmployeesTable.Model;

namespace EmployeesTable.Forms
{
    public partial class EmployeeTableForm : Form
    {
        private Repository repository;
        private List<Employee> filteredEmployees;
        private GridFilterParameters filterParameters;
        private readonly EmployeeLoader gridLoader;

        public EmployeeTableForm()
        {
            filteredEmployees = new List<Employee>();
            repository = new Repository();

            ChangeNameFields();
            InitializeComponent();

            var selectedOffices = repository.GetAllEmployees().Select(e => e.Office).Distinct().ToList();
            var allOffices = repository.GetAllEmployees().Select(e => e.Office).Distinct().ToList();
            filterParameters = GridFilterParameters.GetBaseParameters(selectedOffices, allOffices);
            gridLoader = new EmployeeLoader(dgvEmployees, filteredEmployees, repository, slbEmployeesCount);
            dgvEmployees.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void ChangeNameFields()
        {
            //string[] filePaths = Directory.GetFiles
            //(@"C:\Users\klopov\Desktop\PersonalWorks\EmployeesTableNetFramework\EmployeesTable\bin\Debug\tinyDb\Employee\", "*.*",
            //    SearchOption.TopDirectoryOnly);

            //foreach (var filePath in filePaths)
            //{
            //    var text = File.ReadAllLines(filePath);
            //    var changedText = text.Select(t => t.Replace("Representation", "Office"));
            //    File.WriteAllLines(filePath, changedText);
            //}
        }

        private void EmployeeTableForm_Load(object sender, EventArgs e)
        {
            gridLoader.LoadWith(filterParameters);
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

            var selectedRow = dgvEmployees.GetSelectedRow();

            if (selectedRow.Cells[0]?.Value == null)
                return;

            var id = selectedRow.GetId();
            var employee = repository.GetEmployeeById(id);

            if (e.ColumnIndex == 2)
            {
                new FullDayDetalizationForm(id, repository).ShowDialog();
                selectedRow.Cells[2].Value = employee.HoursFullDays / 8;
            }

            if (e.ColumnIndex == 3)
            {
                new PartialDayDetalizationForm(id, repository).ShowDialog();
                selectedRow.Cells[3].Value = employee.HoursPartialDays;
            }
        }

        private void tstbFullNameSearcher_TextChanged(object sender, EventArgs e)
        {
            var input = (ToolStripTextBox) sender;

            if (string.IsNullOrWhiteSpace(input.Text))
            {
                gridLoader.LoadWith(filterParameters);
                return;
            }

            dgvEmployees.Rows.Clear();
            filteredEmployees = repository.GetEmployeesWithFullNameBegin(input.Text).ToList();

            if (filteredEmployees != null)
                foreach (var employee in filteredEmployees)
                    dgvEmployees.Rows.Add(employee.FullName, employee.Office,
                        employee.HoursFullDays / 8, employee.HoursPartialDays);
        }

        private void btImportOrder_Click(object sender, EventArgs e)
        {
            EnableProgressBar(false);
            var importOrder = new ImportOrder(repository);
            if (importOrder.Import())
                gridLoader.LoadWith(filterParameters);
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
            var exportExcel = new ExportExcel(btExportTable);
            exportExcel.Perform(filteredEmployees);
        }

        private void BtnGridFilter_Click(object sender, EventArgs e)
        {
            var gridFilter = new GridFilterForm(filterParameters);

            if (gridFilter.ShowDialog() == DialogResult.OK)
            {
                filterParameters = gridFilter.Parameters;
                gridLoader.LoadWith(filterParameters);
                var paging = new Paging(bnPaging, bsPaging, dgvEmployees, filteredEmployees);
                paging.Checked();
            }
        }

        private void btEmployeeAdd_Click(object sender, EventArgs e)
        {
            var addEmployee = new AddEmployee(repository);
            if (addEmployee.Perform())
                gridLoader.LoadWith(filterParameters);
        }

        private void btEmployeeEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvEmployees.GetSelectedRow();
            var editEmployee = new EditEmployee(repository);
            if (editEmployee.Perform(selectedRow))
                gridLoader.LoadWith(filterParameters);
        }

        private void btEmployeeDelete_Click(object sender, EventArgs e)
        {
            var selectedRowIndex = dgvEmployees.GetSelectedRowIndex();
            var selectedRow = dgvEmployees.GetSelectedRow();
            var deleteEmployee = new DeleteEmployee(repository);
            if (deleteEmployee.Perform(selectedRow))
                dgvEmployees.Rows.RemoveAt(selectedRowIndex);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tstbFullNameSearcher.Control.Text = "";
            var paging = new Paging(bnPaging, bsPaging, dgvEmployees, filteredEmployees);

            if (cbPaging.Checked)
                paging.Checked();
            else
                gridLoader.LoadWith(filterParameters);
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
                gridLoader.LoadWith(filterParameters);
            }
        }
    }
}