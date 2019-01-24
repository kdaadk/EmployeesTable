using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EmployeesTable.Import;
using TinyStore;
using Application = System.Windows.Forms.Application;

namespace EmployeesTable
{
    public class Repository
    {
        private readonly Func<DialogResult> notUniqueDate = () => MessageBox.Show(
            @"Выбрана уже существующая дата работы.", @"Ошибка при заполнении",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private readonly Store store;

        public Repository()
        {
            store = new Store(Path.GetDirectoryName(Application.ExecutablePath));
        }

        public void SaveEmployee(string id, Employee employee)
        {
            store.Save(id, employee);
        }

        public void SaveOrderData(string id, OrderData orderData)
        {
             store.Save(id, orderData);
        }

        public bool IsOrderUniq(string id)
        {
            return store.FindByQuery<OrderData>(x => x.ID == id).Any();
        }

        public void RecreateEmployee(string id, Employee employee)
        {
            SaveEmployee(employee.GetFullNameID, employee);
            DeleteEmployee(id);
        }

        public void UpdateEmployee(string id, Employee employee)
        {
            store.ModifyById<Employee>(id, e =>
            {
                e.FullName = employee.FullName;
                e.Office = employee.Office;
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
                    employee.HoursPartialDays -= detalization.WorkHours;
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
                    notUniqueDate();
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
                    notUniqueDate();
                    isUnique = false;
                }

                if (oldDetalization != null && isUnique)
                {
                    var diffHours = detalization.WorkHours - oldDetalization.WorkHours;
                    employee.HoursPartialDays += diffHours;

                    oldDetalization.WorkHours = detalization.WorkHours;
                    oldDetalization.WorkDate = detalization.WorkDate;
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

        public IEnumerable<Employee> GetEmployeesWithFullNameBegin(string input)
        {
            return store.FindByQuery<Employee>(e =>
            {
                var capitalizeFirstLetterInput = $"{input.ToUpper().First()}{input.Substring(1)}";
                return e.Fired == false &&
                       (e.FullName.StartsWith(input) || e.FullName.StartsWith(capitalizeFirstLetterInput));
            });
        }

        public IEnumerable<Employee> GetEmployeesWith(GridFilterParameters parameters)
        {
            if (parameters.OfficeGroupName == @"Все" && !parameters.AnyDaysNumber)
                return store.FindByQuery<Employee>(e =>
                    e.Fired == parameters.IsFired
                    && e.HoursFullDays >= parameters.DaysNumberFrom * 8
                    && e.HoursFullDays <= parameters.DaysNumberTo * 8).OrderBy(e => e.FullName);
            if (parameters.OfficeGroupName == @"Все")
                return store.FindByQuery<Employee>(e =>
                    e.Fired == parameters.IsFired).OrderBy(e => e.FullName);
            if (!parameters.AnyDaysNumber)
                return store.FindByQuery<Employee>(e =>
                    e.Fired == parameters.IsFired
                    && parameters.SelectedOffices.Contains(e.Office)
                    && e.HoursFullDays >= parameters.DaysNumberFrom * 8
                    && e.HoursFullDays <= parameters.DaysNumberTo * 8).OrderBy(e => e.FullName);
            return store.FindByQuery<Employee>(e => e.Fired == parameters.IsFired
                && parameters.SelectedOffices.Contains(e.Office)).OrderBy(e => e.FullName);
        }

        public void DeleteEmployee(string id)
        {
            store.DeleteById<Employee>(id);
        }

        public bool TryAddFullDayDetalization(string id, FullDayDetalization detalization)
        {
            var isAdd = true;
            store.ModifyById<Employee>(id, employee =>
            {
                if (!IsUniqueWorkFullDayDate(detalization, employee))
                {
                    notUniqueDate();
                    isAdd = false;
                    return;
                }

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

            return isAdd;
        }

        public bool TryAddPartialDayDetalization(string id, PartialDayDetalization detalization)
        {
            var isAdd = true;
            store.ModifyById<Employee>(id, employee =>
            {
                if (!IsUniqueWorkPartialDayDate(detalization, employee))
                {
                    notUniqueDate();
                    isAdd = false;
                    return;
                }

                employee.PartialDayDetalization.Add(new PartialDayDetalization
                {
                    ID = Guid.NewGuid().ToString(),
                    WorkDate = detalization.WorkDate,
                    WorkHours = detalization.WorkHours,
                    Used = detalization.Used,
                    Comment = detalization.Comment
                });
                employee.HoursPartialDays += detalization.WorkHours;
            });

            return isAdd;
        }

        private bool IsUniqueWorkPartialDayDate(PartialDayDetalization detalization, Employee employee)
        {
            return employee.PartialDayDetalization.All(d => d.WorkDate?.Date != detalization?.WorkDate?.Date);
        }

        private bool IsUniqueWorkFullDayDate(FullDayDetalization detalization, Employee employee)
        {
            return employee.FullDayDetalizations.All(d => d.WorkDate?.Date != detalization?.WorkDate?.Date);
        }

        public bool TryGetNewOffices(List<string> prevOffices, out List<string> newOffices)
        {
            newOffices = GetAllEmployees()
                .Select(e => e.Office)
                .Distinct()
                .Where(r => !prevOffices
                    .Contains(r)).ToList();
            return newOffices.Count > 0;
        }
    }
}