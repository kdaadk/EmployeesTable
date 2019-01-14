using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TinyStore;

namespace EmployeesTable
{
    public class EmployeeRepository
    {
        private readonly Store store;

        public EmployeeRepository()
        {
            store = new Store(Path.GetDirectoryName(Application.ExecutablePath));
        }

        public void SaveEmployee(string id, Employee employee)
        {
            store.Save(id, employee);
        }

        public void UpdateEmployee(string id, Employee employee)
        {
            store.ModifyById<Employee>(id, e =>
            {
                e.FullName = employee.FullName;
                e.Representation = employee.Representation;
                e.Comment = employee.Comment;
            });
        }

        public void DeleteFullDayDetalizationByWorkDate(DateTime? workDate, string id)
        {
            store.ModifyById<Employee>(id, employee =>
            {
                var detalization =
                    employee.FullDayDetalizations.FirstOrDefault(d => d.WorkDate?.Date == workDate?.Date);
                if (detalization != null)
                {
                    employee.HoursFullDays -= detalization.WorkHours;
                    employee.FullDayDetalizations.Remove(detalization);
                }
            });
        }

        public void DeletePartialDayDetalizationByWorkDate(DateTime? workDate, string id)
        {
            store.ModifyById<Employee>(id, employee =>
            {
                var detalization =
                    employee.PartialDayDetalization.FirstOrDefault(d => d.WorkDate?.Date == workDate?.Date);
                if (detalization != null)
                {
                    employee.HoursPartialDays -= detalization.BalanceHours;
                    employee.PartialDayDetalization.Remove(detalization);
                }
            });
        }

        public bool TryEditFullDayDetalization(DateTime? workDate, string id, FullDayDetalization detalization)
        {
            var isEdit = false;
            store.ModifyById<Employee>(id, employee =>
            {
                var isUnique = true;
                var oldDetalization =
                    employee.FullDayDetalizations.FirstOrDefault(d => d.WorkDate?.Date == workDate?.Date);

                if (!IsUniqueWorkFullDayDate(detalization, employee) && workDate?.Date != detalization.WorkDate?.Date)
                {
                    MessageBox.Show(@"Выбрана уже существующая дата работы.", @"Ошибка при заполнении",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isUnique = false;
                }

                if (oldDetalization != null && isUnique)
                {
                    var diffHours = detalization.WorkHours - oldDetalization.WorkHours;
                    employee.HoursFullDays += diffHours;

                    oldDetalization.Payment = detalization.Payment;
                    oldDetalization.RestDate = detalization.RestDate;
                    oldDetalization.WorkHours = detalization.WorkHours;
                    oldDetalization.WorkDate = detalization.WorkDate;
                    oldDetalization.Used = detalization.Used;
                    oldDetalization.Comment = detalization.Comment;
                    isEdit = true;
                }
            });
            return isEdit;
        }

        public bool TryEditPartialDayDetalization(DateTime? workDate, string id, PartialDayDetalization detalization)
        {
            var isEdit = false;
            store.ModifyById<Employee>(id, employee =>
            {
                var isUnique = true;
                var oldDetalization =
                    employee.PartialDayDetalization.FirstOrDefault(d => d.WorkDate?.Date == workDate?.Date);

                if (!IsUniqueWorkPartialDayDate(detalization, employee) &&
                    workDate?.Date != detalization.WorkDate?.Date)
                {
                    MessageBox.Show(@"Выбрана уже существующая дата работы.", @"Ошибка при заполнении",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isUnique = false;
                }

                if (oldDetalization != null && isUnique)
                {
                    var diffHours = detalization.BalanceHours - oldDetalization.BalanceHours;
                    employee.HoursPartialDays += diffHours;

                    oldDetalization.WorkHours = detalization.WorkHours;
                    oldDetalization.WorkDate = detalization.WorkDate;
                    oldDetalization.BalanceHours = detalization.BalanceHours;
                    oldDetalization.Used = detalization.Used;
                    oldDetalization.Comment = detalization.Comment;
                    isEdit = true;
                }
            });
            return isEdit;
        }

        public Employee GetEmployeeById(string id)
        {
            return store.FindById<Employee>(id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return store.FindByQuery<Employee>(_ => true);
        }

        public IEnumerable<Employee> GetWorkingEmployees()
        {
            return store.FindByQuery<Employee>(e => e.Fired == false);
        }

        public IEnumerable<Employee> GetEmployeesWithFullNameBegin(string input)
        {
            return store.FindByQuery<Employee>(e =>
            {
                var capitalizeFirstLetterInput = $"{input.ToUpper().First()}{input.Substring(1)}";
                return e.FullName.StartsWith(input) || e.FullName.StartsWith(capitalizeFirstLetterInput);
            });
        }

        public IEnumerable<Employee> GetEmployeesWith(GridFilterParameters parameters)
        {
            return store.FindByQuery<Employee>(e =>
                e.Fired == parameters.IsFired
                && (parameters.Representation == "Все" || e.Representation == parameters.Representation)
                && e.HoursFullDays >= parameters.HoursNumberFrom
                && e.HoursFullDays <= parameters.HoursNumberTo);
        }

        public void DeleteEmployee(string id)
        {
            store.DeleteById<Employee>(id);
        }

        public void AddFullDayDetalization(string id, FullDayDetalization detalization)
        {
            store.ModifyById<Employee>(id, employee =>
            {
                if (!IsUniqueWorkFullDayDate(detalization, employee))
                    return;

                employee.FullDayDetalizations.Add(new FullDayDetalization
                {
                    ID = Guid.NewGuid().ToString(),
                    WorkDate = detalization.WorkDate,
                    Payment = detalization.Payment,
                    WorkHours = detalization.WorkHours,
                    Used = detalization.Used,
                    RestDate = detalization.RestDate,
                    Comment = detalization.Comment
                });
                employee.HoursFullDays += detalization.WorkHours;
            });
        }

        public void AddPartialDayDetalization(string id, PartialDayDetalization detalization)
        {
            store.ModifyById<Employee>(id, employee =>
            {
                if (!IsUniqueWorkPartialDayDate(detalization, employee))
                    return;

                employee.PartialDayDetalization.Add(new PartialDayDetalization
                {
                    ID = Guid.NewGuid().ToString(),
                    WorkDate = detalization.WorkDate,
                    WorkHours = detalization.WorkHours,
                    Used = detalization.Used,
                    BalanceHours = detalization.BalanceHours,
                    Comment = detalization.Comment
                });
                employee.HoursPartialDays += detalization.BalanceHours;
            });
        }

        private bool IsUniqueWorkPartialDayDate(PartialDayDetalization detalization, Employee employee)
        {
            return employee.PartialDayDetalization.Any(d => d.WorkDate?.Date != detalization?.WorkDate?.Date);
        }

        private bool IsUniqueWorkFullDayDate(FullDayDetalization detalization, Employee employee)
        {
            return employee.FullDayDetalizations.All(d => d.WorkDate?.Date != detalization?.WorkDate?.Date);
        }
    }
}