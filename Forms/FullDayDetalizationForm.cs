using System;
using System.Windows.Forms;

namespace EmployeesTable.Forms
{
    public partial class FullDayDetalizationForm : Form
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly string id;

        public FullDayDetalizationForm(string id, EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this.id = id;
            InitializeComponent();
        }

        private void EmployeeFDetalizationForm_Load(object sender, EventArgs e)
        {
            detalizationDataGridView.Rows.Clear();
            var employee = employeeRepository.GetEmployeeById(id);

            if (employee.FullDayDetalizations != null)
                foreach (var d in employee.FullDayDetalizations)
                    detalizationDataGridView.Rows.Add($"{d.WorkDate?.Date:dd/MM/yyyy}",
                        d.Payment.GetDisplayName(), d.WorkHours, d.Used.GetDisplayName(),
                        $"{d.RestDate?.Date:dd/MM/yyyy}", d.Comment);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var addData = new AddFullDayDetalizationDataForm(new FullDayDetalization {WorkDate = null, RestDate = null});

            if (addData.ShowDialog() == DialogResult.OK)
            {
                var d = addData.Detalization;
                employeeRepository.AddFullDayDetalization(id, d);

                detalizationDataGridView.Rows.Add($"{d.WorkDate?.Date:dd/MM/yyyy}",
                    d.Payment.GetDisplayName(), d.WorkHours,
                    d.Used.GetDisplayName(), $"{d.RestDate?.Date:dd/MM/yyyy}", d.Comment);
            }
        }

        private void btDeleteSelectRow_Click(object sender, EventArgs e)
        {
            var mbAreYouSure = MessageBox.Show(@"Вы уверены, что хотите удалить запись?", @"Удаление", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (mbAreYouSure == DialogResult.No)
                return;

            var selectedRowIndex = detalizationDataGridView.SelectedCells[0].RowIndex;
            var wDate = DateTime.Parse(detalizationDataGridView.Rows[selectedRowIndex].Cells[0].Value.ToString());
            employeeRepository.DeleteFullDayDetalizationByWorkDate(wDate, id);
            detalizationDataGridView.Rows.RemoveAt(selectedRowIndex);
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = detalizationDataGridView.Rows[detalizationDataGridView.SelectedCells[0].RowIndex];
            var wDate = DateTime.Parse(detalizationDataGridView.Rows[detalizationDataGridView.SelectedCells[0].RowIndex]
                .Cells[0].Value.ToString());
            var addData = new AddFullDayDetalizationDataForm(GetFDetalization(selectedRow));

            if (addData.ShowDialog() == DialogResult.OK
                && employeeRepository.TryEditFullDayDetalization(wDate, id, addData.Detalization))
                 EditRowOnGrid(selectedRow, addData);
        }

        private void EditRowOnGrid(DataGridViewRow selectedRow, AddFullDayDetalizationDataForm addFullDayDetalizationData)
        {
            selectedRow.Cells[0].Value = $"{addFullDayDetalizationData.Detalization.WorkDate:dd/MM/yyyy}";
            selectedRow.Cells[1].Value = addFullDayDetalizationData.Detalization.Payment.GetDisplayName();
            selectedRow.Cells[2].Value = addFullDayDetalizationData.Detalization.WorkHours;
            selectedRow.Cells[3].Value = addFullDayDetalizationData.Detalization.Used.GetDisplayName();
            selectedRow.Cells[4].Value = $"{addFullDayDetalizationData.Detalization.RestDate:dd/MM/yyyy}";
            selectedRow.Cells[5].Value = addFullDayDetalizationData.Detalization.Comment;
        }

        private FullDayDetalization GetFDetalization(DataGridViewRow selectedRow)
        {
            DateTime? restDate = null;
            if (!string.IsNullOrEmpty((string)selectedRow.Cells[4].Value))
                restDate = DateTime.Parse(selectedRow.Cells[4]?.Value.ToString());
            return new FullDayDetalization
            {
                WorkDate = DateTime.Parse(selectedRow.Cells[0]?.Value.ToString()),
                Comment = selectedRow.Cells[5].Value?.ToString(),
                Payment = selectedRow.Cells[1].Value?.ToString() == "Оплата" ? Payment.Money : Payment.Rest,
                RestDate = restDate,
                WorkHours = double.Parse(selectedRow.Cells[2]?.Value.ToString()),
                Used = selectedRow.Cells[3].Value?.ToString() == "Да" ? Used.YesFull
                    : selectedRow.Cells[3].Value?.ToString() == "Частично" ? Used.YesPartially : Used.No
            };
        }
    }
}
