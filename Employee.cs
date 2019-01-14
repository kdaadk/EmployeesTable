using System.Collections.Generic;

namespace EmployeesTable
{
    public class Employee
    {
        public Employee()
        {
            FullDayDetalizations = new List<FullDayDetalization>();
            PartialDayDetalization = new List<PartialDayDetalization>();
        }
        public string ID { get; set; }
        public string FullName { get; set; }
        public string Representation { get; set; }
        public double HoursFullDays { get; set; }
        public double HoursPartialDays { get; set; }
        public string Comment { get; set; }
        public List<FullDayDetalization> FullDayDetalizations { get; set; }
        public List<PartialDayDetalization> PartialDayDetalization { get; set; }
        public bool Fired { get; set; }
    }
}
