using System;

namespace EmployeesTable
{
    public class PartialDayDetalization
    {
        public double BalanceHours { get; set; }
        public string ID { get; set; }
        public DateTime? WorkDate { get; set; }
        public double WorkHours { get; set; }
        public Used Used { get; set; }
        public string Comment { get; set; }
    }
}