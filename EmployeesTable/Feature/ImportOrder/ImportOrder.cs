using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmployeesTable.Feature.ImportOrder
{
    public class ImportOrder
    {
        private readonly Repository repository;
        private readonly StringBuilder Log;

        public ImportOrder(Repository repository)
        {
            this.repository = repository;
            Log = new StringBuilder();
        }

        public void AddData(OrderParser parser, List<OrderData> orderData)
        {
            var recordCounter = 0;
            var newEmployeesName = new List<string>();
            var payment = parser.GetPayment();
            foreach (var data in orderData)
            {
                var id = $"{data.FullName}, {data.Office}";
                if (!TryGetAllDetalizations(data.WorkDates, payment, data.ID, out var fullDayDetalizations))
                {
                    MessageBox.Show(@"Файл не удалось распознать", @"Ошибка при чтении файла",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                recordCounter += fullDayDetalizations.Count;

                if (repository.GetEmployeeById(id) == null)
                {
                    newEmployeesName.Add(data.FullName);
                    var newEmployee = new Employee
                    {
                        FullName = data.FullName,
                        Office = data.Office,
                        FullDayDetalizations = fullDayDetalizations,
                        PartialDayDetalization = new List<PartialDayDetalization>(),
                        Fired = false,
                        HoursFullDays = fullDayDetalizations.Sum(d => d.WorkHours)
                    };
                    repository.SaveEmployee(id, newEmployee);
                    Log.AppendLine(
                        $"Добавлен: {newEmployee.FullName}, {newEmployee.Office}");
                    continue;
                }

                foreach (var d in fullDayDetalizations)
                    repository.TryAddFullDayDetalization(id, d);
            }

            foreach (var data in orderData)
                repository.SaveOrderData(Guid.NewGuid().ToString(), data);

            var loadInfo = $@"Загружено {recordCounter} записей
Из них новых сотрудников {newEmployeesName.Count}:
Посмотреть их можно в файле: {$"{Path.GetDirectoryName(Application.ExecutablePath)}\\Logs"}";

            MessageBox.Show(loadInfo, @"Импорт приказа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Log.AppendLine(loadInfo);
            SaveLog();
        }

        public bool Import()
        {
            var parser = new OrderParser(repository);
            string orderPath = null;

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = @"doc files (*.doc;*.docx)|*.doc;*docx";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    orderPath = openFileDialog.FileName;
            }

            if (orderPath != null && parser.TryParse(orderPath, out var orderData))
            {
                AddData(parser, orderData);
                return true;
            }

            return false;
        }

        private bool TryGetAllDetalizations(IEnumerable<string> workDates, Payment payment,
            string comment, out List<FullDayDetalization> detalizations)
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
                            Used = Used.No,
                            Comment = comment
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

        private void SaveLog()
        {
            var now = DateTime.Now;
            var logPath = $"{Path.GetDirectoryName(Application.ExecutablePath)}\\Logs";
            var filePath = $"{logPath}\\{now.ToShortDateString()}.{now.Hour}.{now.Minute}.{now.Second}.txt";

            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);
            File.WriteAllLines(filePath, Log.ToString().Split('\n'));
        }
    }
}
