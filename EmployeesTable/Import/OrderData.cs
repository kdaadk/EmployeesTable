﻿using System.Collections.Generic;

namespace EmployeesTable.Import
{
    public class OrderData
    {
        public string ID { get; set; }
        public string FullName { get; set; }
        public string Office { get; set; }
        public List<string> WorkDates { get; set; }
    }
}