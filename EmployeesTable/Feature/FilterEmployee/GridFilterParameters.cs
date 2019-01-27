using System.Collections.Generic;

namespace EmployeesTable.Feature.FilterEmployee
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

        public static GridFilterParameters GetBaseParameters(List<string> selectedOffices, List<string> allOffices)
        {
            return new GridFilterParameters
            {
                SelectedOffices = selectedOffices,
                AllOffices = allOffices,
                DaysNumberFrom = 0,
                DaysNumberTo = 50,
                AnyDaysNumber = true,
                IsFired = false,
                OfficeGroupName = @"Все",
            };
        }
    }
}