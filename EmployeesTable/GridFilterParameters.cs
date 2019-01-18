using System.Collections.Generic;

namespace EmployeesTable
{
    public class GridFilterParameters
    {
        public bool IsFired { get; set; }
        public List<string> Representations { get; set; }
        public double DaysNumberFrom { get; set; }
        public double DaysNumberTo { get; set; }
    }
}