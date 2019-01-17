using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EmployeesTable.Import;

namespace EmployeesTable
{
    public class EmployeeTableFormHelper
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly StringBuilder Log;

        public EmployeeTableFormHelper(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            Log = new StringBuilder();
        }

        private string GetLogPath()
        {
            var now = DateTime.Now;
            var logPath = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\Logs";
            var filePath = $"{logPath}\\{now.ToShortDateString()}.{now.Hour}.{now.Minute}.{now.Second}.txt";

            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);
            File.WriteAllLines(filePath, Log.ToString().Split('\n'));

            return filePath;
        }

        public void AddOrderData(OrderParser parser, IEnumerable<OrderData> orderDatas)
        {
            var recordCounter = 0;
            var newEmployeesName = new List<string>();
            var payment = parser.GetPayment();
            foreach (var orderData in orderDatas)
            {
                var id = $"{orderData.FullName}, {orderData.Representation}";
                if (!TryGetAllDetalizations(orderData.WorkDates, payment, out var fDetalizations))
                {
                    MessageBox.Show(@"Некорректный файл", @"Импорт приказа", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                recordCounter += fDetalizations.Count;

                if (employeeRepository.GetEmployeeById(id) == null)
                {
                    newEmployeesName.Add(orderData.FullName);
                    var newEmployee = new Employee
                    {
                        FullName = orderData.FullName,
                        Representation = orderData.Representation,
                        FullDayDetalizations = fDetalizations,
                        PartialDayDetalization = new List<PartialDayDetalization>(),
                        Fired = false,
                        HoursFullDays = fDetalizations.Sum(d => d.WorkHours)
                    };
                    employeeRepository.SaveEmployee(id, newEmployee);
                    Log.AppendLine(
                        $"Добавлен: {newEmployee.FullName}, {newEmployee.Representation}");
                    continue;
                }

                foreach (var d in fDetalizations)
                    employeeRepository.TryAddFullDayDetalization(id, d);
            }

            var path = GetLogPath();
            MessageBox.Show(
                $@"Загружено {recordCounter} записей
Из них новых сотрудников {newEmployeesName.Count}:
Посмотреть их можно в файле: {path}",
                @"Импорт приказа", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool TryGetAllDetalizations(IEnumerable<string> workDates, Payment payment,
            out List<FullDayDetalization> detalizations)
        {
            detalizations = new List<FullDayDetalization>();
            foreach (var workDateLine in workDates)
            {
                if (!DateTime.TryParse(workDateLine, out var workDate))
                    return false;

                switch (payment)
                {
                    case Payment.Rest:
                        detalizations.Add(new FullDayDetalization
                        {
                            Payment = payment,
                            WorkDate = workDate,
                            WorkHours = 8,
                            Used = Used.No
                        });
                        break;
                    case Payment.Money:
                        detalizations.Add(new FullDayDetalization
                        {
                            Payment = payment,
                            WorkDate = workDate,
                            WorkHours = 0,
                            Used = Used.YesFull,
                            RestDate = workDate
                        });
                        break;
                }
            }

            return true;
        }

        public void CopyAlltoClipboard(DataGridView dgvEmployees)
        {
            dgvEmployees.SelectAll();
            var dataObj = dgvEmployees.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
    }
}