using System.Windows.Forms;

namespace EmployeesTable.Feature.DeleteEmployee
{
    public class DeleteEmployee
    {
        private readonly Repository repository;

        public DeleteEmployee(Repository repository)
        {
            this.repository = repository;
        }

        public bool Perform(DataGridViewRow selectedRow)
        {
            if (selectedRow.Cells[0]?.Value == null)
                return false;

            var id = selectedRow.GetId();
            var mbAreYouSure = MessageBox.Show(@"Вы уверены, что хотите удалить запись?", @"Удаление",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (mbAreYouSure == DialogResult.No)
                return false;

            repository.DeleteEmployee(id);
            return true;
        }
    }
}
