using System;
using System.Collections.Generic;
using System.IO;

namespace EmployeesTable
{
    public class EmpData
    {
        public string FN { get; set; }
        public string Re { get; set; }
        public DateTime Date { get; set; }
        public double Hours { get; set; }
        public string GetId => $"{FN}, {Re}";
    }

    public class DecemberData
    {
        private readonly EmployeeRepository employeeRepository;

        public DecemberData(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public int Load()
        {
            var counter = 0;
            var empDatas = new List<EmpData>();

            var path = @"C:\Users\klopov\Desktop\";
            var fn = File.ReadAllLines(path + "fn.txt");
            var re = File.ReadAllLines(path + "re.txt");
            var date = File.ReadAllLines(path + "date.txt");

            for (int i = 0; i < re.Length; i++)
            {
                var index = re[i].IndexOf(",", StringComparison.Ordinal);
                re[i] = index != -1 ? re[i].Substring(0, index) : re[i];
            }


            for (int i = 0; i < fn.Length; i++)
            {
                empDatas.Add(new EmpData
                {
                    Date = DateTime.Parse(date[i]),
                    FN = fn[i],
                    Hours = 0,
                    Re = re[i]
                });
            }

            foreach (var empData in empDatas)
            {
                var employee = employeeRepository.GetEmployeeById(empData.GetId);
                if (employeeRepository.TryAddFullDayDetalization(employee.GetFullNameID, new FullDayDetalization
                {
                    Payment = Payment.Money,
                    ID = Guid.NewGuid().ToString(),
                    WorkDate = empData.Date,
                    RestDate = empData.Date,
                    WorkHours = empData.Hours,
                    Used = Used.YesFull
                }))
                    counter++;
            }

            return counter;
        }
    }
}
