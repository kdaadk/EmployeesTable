using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Spire.Doc;

namespace EmployeesTable.Feature.ImportOrder
{
    public class OrderParser
    {
        private Payment payment;
        private string orderId;
        private readonly Repository repository;

        public OrderParser(Repository repository)
        {
            payment = Payment.Undefined;
            this.repository = repository;
        }

        public bool TryParse(string path, out List<OrderData> orderData)
        {
            orderData = null;
            var lines = GetWords(path);

            if (!IsCorrectOrder(lines))
                return false;

            payment = PaymentDetector.DetectFromOrder(lines[5]);
            const int StartIndex = 22;
            orderId = $"Приказ {lines[12]}";
            var getOrderDataFunc = GetFuncOrderData(payment);

            if (repository.IsOrderUniq(orderId))
            {
                MessageBox.Show(@"Протокол с таким номером уже был загружен", @"Ошибка записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (getOrderDataFunc == null)
                return false;

            try
            {
                orderData = getOrderDataFunc(StartIndex, lines);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($@"{e}", @"Ошибка при чтении файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool IsCorrectOrder(List<string> lines)
        {
            if (lines.Count < 22)
                return false;

            if (!lines[20].Contains("С приказом ознакомлен"))
                return false;

            if (!lines[12].StartsWith("от "))
                return false;

            return true;
        }

        private Func<int, List<string>, List<OrderData>> GetFuncOrderData(Payment pay)
        {
            if (pay == Payment.Money)
                return GetOrderDataFromMoneyOrder;
            if (pay == Payment.Rest)
                return GetOrderDataFromRestOrder;
            MessageBox.Show(@"Файл не удалось распознать", @"Ошибка при чтении файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
        

        private List<OrderData> GetOrderDataFromRestOrder(int index, List<string> lines)
        {
            var orderDatas = new List<OrderData>();

            for (var i = index; i < lines.Count; i += 6)
            {
                if (i + 4 > lines.Count)
                    break;

                var officeDelimeterIndex = lines[i + 4].IndexOf(",", StringComparison.Ordinal);
                var dateDelimeterIndex = lines[i + 2].IndexOf(";", StringComparison.Ordinal);
                var orderData = new OrderData
                {
                    ID = orderId,
                    FullName = lines[i],
                    Office = officeDelimeterIndex != -1
                        ? lines[i + 4].Substring(0, officeDelimeterIndex)
                        : lines[i + 4]
                };

                if (dateDelimeterIndex != -1 && dateDelimeterIndex < 14)
                {
                    var dates = lines[i + 2].Split(';').ToList();
                    orderData.WorkDates = dates;
                }
                else if (dateDelimeterIndex != -1 && dateDelimeterIndex >= 14)
                {
                    var lastDate = lines[i + 2].Split(';').Last().Trim().Substring(0, 10);
                    orderData.WorkDates = new List<string> {lastDate};
                }
                else
                {
                    orderData.WorkDates = new List<string> {lines[i + 2]};
                }

                orderDatas.Add(orderData);
            }

            return orderDatas;
        }

        private List<OrderData> GetOrderDataFromMoneyOrder(int index, List<string> words)
        {
            var orderDatas = new List<OrderData>();

            for (var i = index; i < words.Count; i += 6)
            {
                if (i + 4 > words.Count)
                    break;

                var delimeterIndex = words[i + 4].IndexOf(",", StringComparison.Ordinal);
                var orderData = new OrderData
                {
                    ID = orderId,
                    FullName = words[i],
                    Office = delimeterIndex != -1 ? words[i + 4].Substring(0, delimeterIndex) : words[i + 4]
                };

                if (words[i + 2].Contains(";"))
                {
                    var dates = words[i + 2].Split(';').ToList();
                    orderData.WorkDates = dates;
                }
                else
                {
                    orderData.WorkDates = new List<string> {words[i + 2]};
                }

                orderDatas.Add(orderData);
            }

            return orderDatas;
        }

        public Payment GetPayment()
        {
            return payment;
        }


        private List<string> GetWords(string path)
        {
            var document = new Document();
            document.LoadFromFile(path);
            return document.GetText().Replace("\r", string.Empty).Split('\n')
                .Where(w => !string.IsNullOrWhiteSpace(w)).Select(w => w.TrimEnd()).ToList();
        }
    }
}