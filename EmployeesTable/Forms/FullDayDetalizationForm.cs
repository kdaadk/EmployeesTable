using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EmployeesTable.Forms
{
    public sealed partial class FullDayDetalizationForm : Form
    {
        private readonly Repository employeeRepository;
        private readonly string id;

        public FullDayDetalizationForm(string id, Repository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this.id = id;
            InitializeComponent();
            dgvFullDayDetalization.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Text = id;
        }

        private void EmployeeFullDayDetalizationForm_Load(object sender, EventArgs e)
        {
            dgvFullDayDetalization.Rows.Clear();
            var employee = employeeRepository.GetEmployeeById(id);

            if (employee.FullDayDetalizations != null)
                foreach (var d in employee.FullDayDetalizations.OrderBy(d => d.WorkDate))
                {
                    dgvFullDayDetalization.Rows.Add($"{d.WorkDate?.Date:dd/MM/yyyy}",
                        d.Payment.GetDisplayName(), d.WorkHours, d.Used.GetDisplayName(),
                        $"{d.RestDate?.Date:dd/MM/yyyy}", d.Comment);
                    if (d.Payment == Payment.Rest)
                        dgvFullDayDetalization.Rows[dgvFullDayDetalization.Rows.Count - 2].Cells[1].Style.ForeColor =
                            Color.Red;
                }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var addData =
                new AddFullDayDetalizationDataForm(new FullDayDetalization {WorkDate = null, RestDate = null}, "Добавить детализацию полного дня");

            if (addData.ShowDialog() == DialogResult.OK)
            {
                var d = addData.Detalization;

                if (employeeRepository.TryAddFullDayDetalization(id, d))
                    dgvFullDayDetalization.Rows.Add($"{d.WorkDate?.Date:dd/MM/yyyy}",
                        d.Payment.GetDisplayName(), d.WorkHours,
                        d.Used.GetDisplayName(), $"{d.RestDate?.Date:dd/MM/yyyy}", d.Comment);
            }
        }

        private void btDeleteSelectRow_Click(object sender, EventArgs e)
        {
            var selectedRowIndex = dgvFullDayDetalization.SelectedCells[0].RowIndex;
            if (!DateTime.TryParse(dgvFullDayDetalization.Rows[selectedRowIndex].Cells[0]?.Value?.ToString(),
                out var wDate))
                return;

            var mbAreYouSure = MessageBox.Show(@"Вы уверены, что хотите удалить запись?", @"Удаление",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (mbAreYouSure == DialogResult.No)
                return;

            employeeRepository.DeleteFullDayDetalizationByWorkDate(wDate, id);
            dgvFullDayDetalization.Rows.RemoveAt(selectedRowIndex);
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvFullDayDetalization.Rows[dgvFullDayDetalization.SelectedCells[0].RowIndex];

            if (!DateTime.TryParse(dgvFullDayDetalization.Rows[dgvFullDayDetalization.SelectedCells[0].RowIndex]
                .Cells[0]?.Value?.ToString(), out var wDate))
                return;

            var editData = new AddFullDayDetalizationDataForm(GetFullDayDetalization(selectedRow), "Редактировать детализацию полного дня");

            if (editData.ShowDialog() == DialogResult.OK
                && employeeRepository.TryEditFullDayDetalization(wDate, id, editData.Detalization))
                EditRowOnGrid(selectedRow, editData);
        }

        private void EditRowOnGrid(DataGridViewRow selectedRow,
            AddFullDayDetalizationDataForm addFullDayDetalizationData)
        {
            selectedRow.Cells[0].Value = $"{addFullDayDetalizationData.Detalization.WorkDate:dd/MM/yyyy}";
            selectedRow.Cells[1].Value = addFullDayDetalizationData.Detalization.Payment.GetDisplayName();
            selectedRow.Cells[2].Value = addFullDayDetalizationData.Detalization.WorkHours;
            selectedRow.Cells[3].Value = addFullDayDetalizationData.Detalization.Used.GetDisplayName();
            selectedRow.Cells[4].Value = $"{addFullDayDetalizationData.Detalization.RestDate:dd/MM/yyyy}";
            selectedRow.Cells[5].Value = addFullDayDetalizationData.Detalization.Comment;
        }

        private FullDayDetalization GetFullDayDetalization(DataGridViewRow selectedRow)
        {
            DateTime? restDate = null;

            if (!string.IsNullOrEmpty((string) selectedRow.Cells[4].Value))
                restDate = DateTime.Parse(selectedRow.Cells[4]?.Value.ToString());

            double.TryParse(selectedRow.Cells[2]?.Value.ToString(), out var workHours);
            return new FullDayDetalization
            {
                WorkDate = DateTime.Parse(selectedRow.Cells[0]?.Value.ToString()),
                Comment = selectedRow.Cells[5].Value?.ToString(),
                Payment = PaymentDetector.DetectFromComboBox(selectedRow.Cells[1].Value?.ToString()),
                RestDate = restDate,
                WorkHours = workHours,
                Used = UsedDetector.DetectFromComboBox(selectedRow.Cells[3].Value?.ToString())
            };
        }
    }
}