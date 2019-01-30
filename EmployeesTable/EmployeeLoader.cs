using System.Collections.Generic;
using System.Windows.Forms;
using EmployeesTable.Feature.FilterEmployee;
using EmployeesTable.Model;

namespace EmployeesTable
{
    public class EmployeeLoader
    {
        private readonly DataGridView dataGridEmployees;
        readonly List<Employee> filteredEmployees;
        private readonly Repository repository;
        private readonly ToolStripStatusLabel employeeCounter;

        public EmployeeLoader(DataGridView dataGridEmployees, List<Employee> filteredEmployees,
            Repository repository, ToolStripStatusLabel employeeCounter)
        {
            this.dataGridEmployees = dataGridEmployees;
            this.filteredEmployees = filteredEmployees;
            this.repository = repository;
            this.employeeCounter = employeeCounter;
        }

        public void LoadWith(GridFilterParameters parameters)
        {
            dataGridEmployees.Rows.Clear();
            filteredEmployees.Clear();

            if (repository.TryGetNewOffices(parameters.AllOffices, out var newOffices))
                parameters.AllOffices.AddRange(newOffices);

            filteredEmployees.AddRange(repository.GetEmployeesWith(parameters));

            foreach (var employee in filteredEmployees)
                dataGridEmployees.Rows.Add(employee.FullName, employee.Office,
                    employee.HoursFullDays / 8, employee.HoursPartialDays, employee.Comment);

            employeeCounter.Text = $@"Найдено: {filteredEmployees.Count} {GetDeclension(filteredEmployees.Count, "сотрудник", "сотрудника", "сотрудников")}";
        }

        private string GetDeclension(int number, string nominativ, string genetiv, string plural)
        {
            number = number % 100;

            if (number >= 11 && number <= 19)
                return plural;

            var i = number % 10;
            switch (i)
            {
                case 1:
                    return nominativ;
                case 2:
                case 3:
                case 4:
                    return genetiv;
                default:
                    return plural;
            }
        }
    }
}
