using System;
using System.Windows.Forms;

namespace EmployeesTable.Forms
{
    public partial class PartialDayDetalizationForm : Form
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly string id;

        public PartialDayDetalizationForm(string id, EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this.id = id;
            InitializeComponent();
        }

        private void EmployeeFDetalizationForm_Load(object sender, EventArgs e)
        {
            detalizationDataGridView.Rows.Clear();
            var employee = employeeRepository.GetEmployeeById(id);

            if (employee.PartialDayDetalization != null)
                foreach (var d in employee.PartialDayDetalization)
                    detalizationDataGridView.Rows.Add($"{d.WorkDate?.Date:dd/MM/yyyy}",
                        d.WorkHours, d.Used.GetDisplayName(), d.BalanceHours,
                        string.Format($"{0:dd/MM/yyyy}"), d.Comment);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var addData = new AddPartialDayDetalizationDataForm(new PartialDayDetalization { WorkDate = null});

            if (addData.ShowDialog() == DialogResult.OK)
            {
                var d = addData.Detalization;
                employeeRepository.AddPartialDayDetalization(id, d);

                detalizationDataGridView.Rows.Add($"{d.WorkDate?.Date:dd/MM/yyyy}", d.WorkHours,
                    d.Used.GetDisplayName(), d.BalanceHours, d.Comment);
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
            employeeRepository.DeletePartialDayDetalizationByWorkDate(wDate, id);
            detalizationDataGridView.Rows.RemoveAt(selectedRowIndex);
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            var selectedRow = detalizationDataGridView.Rows[detalizationDataGridView.SelectedCells[0].RowIndex];
            var wDate = DateTime.Parse(detalizationDataGridView.Rows[detalizationDataGridView.SelectedCells[0].RowIndex]
                .Cells[0].Value.ToString());
            var addData = new AddPartialDayDetalizationDataForm(GetPDetalization(selectedRow));

            if (addData.ShowDialog() == DialogResult.OK)
            {
                if (employeeRepository.TryEditPartialDayDetalization(wDate, id, addData.Detalization))
                    EditRowOnGrid(selectedRow, addData);
            }
        }

        private void EditRowOnGrid(DataGridViewRow selectedRow, AddPartialDayDetalizationDataForm addPartialDayDetalizationData)
        {
            selectedRow.Cells[0].Value = $"{addPartialDayDetalizationData.Detalization.WorkDate:dd/MM/yyyy}";
            selectedRow.Cells[1].Value = addPartialDayDetalizationData.Detalization.WorkHours;
            selectedRow.Cells[2].Value = addPartialDayDetalizationData.Detalization.Used.GetDisplayName();
            selectedRow.Cells[3].Value = addPartialDayDetalizationData.Detalization.BalanceHours;
            selectedRow.Cells[4].Value = addPartialDayDetalizationData.Detalization.Comment;
        }

        private PartialDayDetalization GetPDetalization(DataGridViewRow selectedRow) => new PartialDayDetalization
        {
            WorkDate = DateTime.Parse(selectedRow.Cells[0]?.Value.ToString()),
            WorkHours = double.Parse(selectedRow.Cells[1]?.Value.ToString()),
            Used = selectedRow.Cells[2].Value?.ToString() == "Да" ? Used.YesFull
                : selectedRow.Cells[2].Value?.ToString() == "Частично" ? Used.YesPartially : Used.No,
            BalanceHours = double.Parse(selectedRow.Cells[3]?.Value.ToString()),
            Comment = selectedRow.Cells[4].Value?.ToString()
        };
    }
}
