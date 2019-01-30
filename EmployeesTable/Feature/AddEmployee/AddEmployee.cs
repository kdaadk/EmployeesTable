using System;
using System.Windows.Forms;
using EmployeesTable.Model;

namespace EmployeesTable.Feature.AddEmployee
{
    public class AddEmployee
    {
        private readonly Repository repository;

        public AddEmployee(Repository repository)
        {
            this.repository = repository;
        }

        public bool Perform()
        {
            var addData = new AddEmployeeDataForm(new Employee(), "Добавить сотрудника");
            if (addData.ShowDialog() == DialogResult.OK)
            {
                var employee = new Employee
                {
                    ID = Guid.NewGuid().ToString(),
                    FullName = addData.Employee.FullName,
                    Office = addData.Employee.Office,
                    Comment = addData.Employee.Comment
                };
                repository.SaveEmployee($"{employee.FullName}, {employee.Office}", employee);
                return true;
            }

            return false;
        }
    }
}
