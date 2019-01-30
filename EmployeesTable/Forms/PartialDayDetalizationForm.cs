using System;
using System.Linq;
using System.Windows.Forms;
using EmployeesTable.Extensions;
using EmployeesTable.Model;

namespace EmployeesTable.Forms
{
    public sealed partial class PartialDayDetalizationForm : Form
    {
        private readonly Repository employeeRepository;
        private readonly string id;

        public PartialDayDetalizationForm(string id, Repository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this.id = id;
            InitializeComponent();
            dgvPartialDayDetalization.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Text = id;

        }

        private void EmployeeFDetalizationForm_Load(object sender, EventArgs e)
        {
            dgvPartialDayDetalization.Rows.Clear();
            var employee = employeeRepository.GetEmployeeById(id);

            if (employee.PartialDayDetalization != null)
                foreach (var d in employee.PartialDayDetalization.OrderBy(d => d.WorkDate))
                    dgvPartialDayDetalization.Rows.Add($"{d.WorkDate?.Date:dd/MM/yyyy}",
                        d.WorkHours, d.Used.GetDisplayName(), d.Comment);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var addData = new AddPartialDayDetalizationDataForm(new PartialDayDetalization {WorkDate = null},
                "Добавить детализацию неполного дня");

            if (addData.ShowDialog() == DialogResult.OK)
            {
                var d = addData.Detalization;
                if (employeeRepository.TryAddPartialDayDetalization(id, d))
                    dgvPartialDayDetalization.Rows.Add($"{d.WorkDate?.Date:dd/MM/yyyy}", d.WorkHours,
                        d.Used.GetDisplayName(), d.Comment);
            }
        }

        private void btDeleteSelectRow_Click(object sender, EventArgs e)
        {
            var selectedRowIndex = dgvPartialDayDetalization.SelectedCells[0].RowIndex;
            if (!DateTime.TryParse(dgvPartialDayDetalization.Rows[selectedRowIndex].Cells[0]?.Value?.ToString(),
                out var wDate))
                return;

            var mbAreYouSure = MessageBox.Show(@"Вы уверены, что хотите удалить запись?", @"Удаление",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (mbAreYouSure == DialogResult.No)
                return;

            employeeRepository.DeletePartialDayDetalizationByWorkDate(wDate, id);
            dgvPartialDayDetalization.Rows.RemoveAt(selectedRowIndex);
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvPartialDayDetalization.Rows[dgvPartialDayDetalization.SelectedCells[0].RowIndex];
            if (!DateTime.TryParse(dgvPartialDayDetalization.Rows[dgvPartialDayDetalization.SelectedCells[0].RowIndex]
                .Cells[0]?.Value?.ToString(), out var wDate))
                return;
            var editData = new AddPartialDayDetalizationDataForm(GetPDetalization(selectedRow), "Редактировать детализацию неполного дня");

            if (editData.ShowDialog() == DialogResult.OK)
                if (employeeRepository.TryEditPartialDayDetalization(wDate, id, editData.Detalization))
                    EditRowOnGrid(selectedRow, editData);
        }

        private void EditRowOnGrid(DataGridViewRow selectedRow,
            AddPartialDayDetalizationDataForm addPartialDayDetalizationData)
        {
            selectedRow.Cells[0].Value = $"{addPartialDayDetalizationData.Detalization.WorkDate:dd/MM/yyyy}";
            selectedRow.Cells[1].Value = addPartialDayDetalizationData.Detalization.WorkHours;
            selectedRow.Cells[2].Value = addPartialDayDetalizationData.Detalization.Used.GetDisplayName();
            selectedRow.Cells[3].Value = addPartialDayDetalizationData.Detalization.Comment;
        }

        private PartialDayDetalization GetPDetalization(DataGridViewRow selectedRow)
        {
            double.TryParse(selectedRow.Cells[1]?.Value.ToString(), out var workHours);
            return new PartialDayDetalization
            {
                WorkDate = DateTime.Parse(selectedRow.Cells[0]?.Value.ToString()),
                WorkHours = workHours,
                Used = UsedDetector.DetectFromComboBox(selectedRow.Cells[2].Value?.ToString()),
                Comment = selectedRow.Cells[3].Value?.ToString()
            };
        }
    }
}