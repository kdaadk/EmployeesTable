using System.Windows.Forms;
using EmployeesTable.Feature.AddEmployee;

namespace EmployeesTable.Feature.EditEmployee
{
    public class EditEmployee
    {
        private readonly Repository repository;

        public EditEmployee(Repository repository)
        {
            this.repository = repository;
        }

        public bool Perform(DataGridViewRow selectedRow)
        {
            if (selectedRow.Cells[0]?.Value == null)
                return false;

            var id = selectedRow.GetId();
            var editData = new AddEmployeeDataForm(repository.GetEmployeeById(id), "Редактировать сотрудника");

            if (editData.ShowDialog() == DialogResult.OK)
            {
                if (id != editData.Employee.GetFullNameID)
                    repository.RecreateEmployee(id, editData.Employee);
                else
                    repository.UpdateEmployee(id, editData.Employee);

                return true;
            }

            return false;
        }
    }
}