using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EmployeesTable
{
    class Data
    {
        public string Representaion { get; set; }
        public Dictionary<DateTime, FullDayDetalization> WorkDates { get; set; }
    }

    class EmployeeLoad
    {
        public string Representation { get; set; }
        public DateTime DateRecru { get; set; }
        public DateTime? DateFaired { get; set; }
        public string CutName { get; set; }
        public string FullName { get; set; }
        public bool IsFaired { get; set; }
        public Dictionary<DateTime, FullDayDetalization> WorkDates { get; set; }

        public List<FullDayDetalization> FullDayDetalizations { get; set; }
    }

    
    public class DbTransfer
    {
        public List<string> Log = new List<string>();
        private readonly EmployeeRepository employeeRepository;

        public DbTransfer(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public void LoadData()
        {
            var rightRepresentationEmployees = GetEmployeeCollection();

            var dbWorkDates = File.ReadAllLines("db.txt");
            var indexes = GetIndexes(dbWorkDates);
            var dict = new Dictionary<string, Data>();
            AddDataWorkDates(indexes, dict, dbWorkDates);

            var dbInfo = File.ReadAllLines("rawDb.txt");
            var employees = new List<EmployeeLoad>();

            GetEmployeesByRawDb(dbInfo, employees);
            RemoveDates(dict, employees);

            foreach (var employee in employees)
            {
                if (dict.ContainsKey(employee.FullName))
                    employee.WorkDates = dict[employee.FullName].WorkDates;
            }

            var sortedEmployees = employees.OrderBy(e => e.FullName).ToList();

            foreach (var emp in sortedEmployees)
            {
                var repre = rightRepresentationEmployees
                    .Where(e => e.FullName.StartsWith(emp.FullName.Substring(5)))
                    .FirstOrDefault(e => e.DateRecru.Date == emp.DateRecru.Date);


                if (repre == null)
                {
                    Log.Add("Not found: "+emp.FullName);
                    continue;
                }

                var fDetaList = new List<FullDayDetalization>();
                if (emp.WorkDates != null)
                    fDetaList.AddRange(emp.WorkDates.Values.ToList());
                var newEmp = new Employee
                {
                    Comment = null,
                    Fired = emp.IsFaired,
                    FullDayDetalizations = fDetaList,
                    FullName = emp.FullName.Substring(5),
                    HoursFullDays = fDetaList.Sum(x => x.WorkHours),
                    HoursPartialDays = 0,
                    ID = Guid.NewGuid().ToString(),
                    Representation = repre.Representation,
                    PartialDayDetalization = new List<PartialDayDetalization>()
                };
                employeeRepository.SaveEmployee($"{newEmp.FullName}, {newEmp.Representation}", newEmp);
            }

            File.WriteAllLines("log.txt", Log);
        }

        private List<EmployeeLoad> GetEmployeeCollection()
        {
            var fn = File.ReadAllLines("fn.txt");
            var re = File.ReadAllLines("re.txt");
            var dr = File.ReadAllLines("dr.txt");

            var employees = new List<EmployeeLoad>();

            for (int i = 0; i < fn.Length; i++)
            {
                var indexReDelimeter = re[i].IndexOf(",", StringComparison.Ordinal);
                var representation = re[i];
                if (indexReDelimeter != -1)
                    representation = re[i].Substring(0, indexReDelimeter);
                employees.Add(new EmployeeLoad{FullName = fn[i], Representation = representation, DateRecru = DateTime.Parse(dr[i]) });
            }

            return employees;
        }

        private void GetEmployeesByRawDb(string[] dbInfo, List<EmployeeLoad> employees)
        {
            for (int i = 0; i < dbInfo.Length; i += 5)
            {
                DateTime? dateFaired = null;
                if (dbInfo[i + 4] != string.Empty)
                    dateFaired = DateTime.Parse(dbInfo[i + 4]);
                employees.Add(new EmployeeLoad
                {
                    FullName = "ФИО: " + dbInfo[i + 0],
                    CutName = dbInfo[i + 1],
                    Representation = dbInfo[i + 2],
                    DateRecru = DateTime.Parse(dbInfo[i + 3]),
                    DateFaired = dateFaired,
                    IsFaired = dateFaired != null
                });
            }
        }

        private void RemoveDates(Dictionary<string, Data> dict, List<EmployeeLoad> employees)
        {
            foreach (var data in dict)
            {
                var dateFaired = employees.FirstOrDefault(e => e.FullName == data.Key)?.DateFaired;
                if (dateFaired != null)
                {
                    var dates = new List<DateTime>();
                    dates.AddRange(data.Value.WorkDates.Select(x => x.Key).Where(d => d.Date < dateFaired));

                    foreach (var dateTime in dates)
                        data.Value.WorkDates.Remove(dateTime);
                }
            }
        }

        private void AddDataWorkDates(List<int> indexes, Dictionary<string, Data> dict, string[] data)
        {
            for (var i = 0; i < indexes.Count - 1; i++)
            {
                dict.Add(data[indexes[i]], new Data
                {
                    Representaion = data[indexes[i] + 1],
                    WorkDates = GetWorkDates(indexes[i], indexes[i + 1], data, data[indexes[i]])
                });
            }
        }

        private List<int> GetIndexes(string[] yearData)
        {
            var indexes = new List<int>();

            for (var i = 0; i < yearData.Length; i++)
                if (yearData[i].StartsWith("ФИО"))
                    indexes.Add(i);

            return indexes;
        }

        private Dictionary<DateTime, FullDayDetalization> GetWorkDates(int i, int i1, string[] yearData, string name)
        {
            var dates = new Dictionary<DateTime, FullDayDetalization>();
            for (int j = i + 2; j < i1; j++)
            {
                var indexDelimeter = yearData[j].IndexOf(";", StringComparison.Ordinal);
                var date = yearData[j].Substring(0, indexDelimeter);
                var value = yearData[j].Substring(indexDelimeter + 2);
                var fDeta = GetFDetalization(value, DateTime.Parse(date), name);
                if (!dates.ContainsKey(DateTime.Parse(date)) && fDeta != null)
                    dates.Add(DateTime.Parse(date), fDeta);
                else Console.WriteLine(j);
            }

            return dates;
        }

        private FullDayDetalization GetFDetalization(string value, DateTime workDate, string name)
        {
            var fDeta = new FullDayDetalization
            {
                ID = Guid.NewGuid().ToString(),
                RestDate = null,
                Comment = null,
                WorkDate = workDate,
                WorkHours = 8
            };
            if (value == "оплата")
            {
                fDeta.Used = Used.YesFull;
                fDeta.Payment = Payment.Money;
                fDeta.RestDate = workDate;
                fDeta.WorkHours = 0;
                return fDeta;
            }

            if (value == "отгул")
            {
                fDeta.Used = Used.No;
                fDeta.Payment = Payment.Rest;
                fDeta.RestDate = null;
                return fDeta;
            }

            if (value.StartsWith("отгул") && value.Length > 15 && value.Length < 20 && value != "отгул" &&
                !value.StartsWith("отгул (Новый"))
            {
                var index = value.IndexOf("(", StringComparison.Ordinal);
                var date = DateTime.Parse(value.Substring(index + 1, 10));
                fDeta.RestDate = date;
                fDeta.Used = Used.YesFull;
                fDeta.Payment = Payment.Rest;
                fDeta.WorkHours = 0;
                return fDeta;
            }

            Log.Add(name);
            Log.Add(workDate + " " + value);
            return null;
        }
    }
}
