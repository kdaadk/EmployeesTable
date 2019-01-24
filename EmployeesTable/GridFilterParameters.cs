using System.Collections.Generic;

namespace EmployeesTable
{
    public class GridFilterParameters
    {
        public bool IsFired { get; set; }
        public List<string> SelectedOffices { get; set; }
        public List<string> AllOffices { get; set; }
        public string OfficeGroupName { get; set; }
        public double DaysNumberFrom { get; set; }
        public double DaysNumberTo { get; set; }
        public bool AnyDaysNumber{ get; set; }
    }
}