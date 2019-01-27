using System.Windows.Forms;

namespace EmployeesTable
{
    public static class DataGridViewExtensions
    {
        public static string GetId(this DataGridViewRow selectedRow)
        {
            var selectedFullName = selectedRow.Cells[0].Value.ToString();
            var selectedOffice = selectedRow.Cells[1].Value.ToString();
            return $"{selectedFullName}, {selectedOffice}";
        }

        public static DataGridViewRow GetSelectedRow(this DataGridView dataGridEmployees)
        {
            return dataGridEmployees.Rows[dataGridEmployees.SelectedCells[0].RowIndex];
        }

        public static int GetSelectedRowIndex(this DataGridView dataGridEmployees)
        {
            return dataGridEmployees.SelectedCells[0].RowIndex;
        }
    }
}
