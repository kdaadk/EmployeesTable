using System;
using System.Collections.Generic;
using System.Linq;
using Spire.Doc;

namespace EmployeesTable.Import
{
    public class OrderParser
    {
        private Payment payment;

        public List<OrderData> Parse(string path)
        {
            var index = 0;
            var words = GetWords(path);

            for (var i = 0; i < 100; i++)
            {
                if (words[i].Contains("произвести оплату"))
                    payment = Payment.Money;
                if (words[i].Contains("Предоставить выходной день"))
                    payment = Payment.Rest;
                if (words[i].Contains("С приказом ознакомлен"))
                {
                    index = i + 2;
                    break;
                }
            }

            if (payment == Payment.Money)
                return GetOrderDatasFromMoneyOrder(index, words);

            if (payment == Payment.Rest)
                return GetOrderDatasFromRestOrder(index, words);

            throw new ArgumentException();
        }

        private List<OrderData> GetOrderDatasFromRestOrder(int index, List<string> words)
        {
            var orderDatas = new List<OrderData>();

            for (var i = index; i < words.Count; i += 6)
            {
                if (i + 4 > words.Count)
                    break;

                var date = words[i + 2].Substring(0, words[i + 2].IndexOf(",", StringComparison.Ordinal));
                var delimeterIndex = words[i + 4].IndexOf(",", StringComparison.Ordinal);
                var orderData = new OrderData
                {
                    FullName = words[i],
                    Representation = delimeterIndex != -1 ? words[i + 4].Substring(0, delimeterIndex) : words[i + 4]
                };

                if (words[i + 2].Contains(";") && date.Length < 12)
                {
                    var dates = words[i + 2].Split(';').ToList();
                    orderData.WorkDates = dates;
                }
                else if (words[i + 2].Contains(";") && date.Length > 12)
                {
                    var lastDate = words[i + 2].Split(';').Last().Substring(0, 10);
                    orderData.WorkDates = new List<string> { lastDate };
                }
                else
                {
                    orderData.WorkDates = new List<string> { words[i + 2] };
                }

                orderDatas.Add(orderData);

            }

            return orderDatas;
        }

        private List<OrderData> GetOrderDatasFromMoneyOrder(int index, List<string> words)
        {
            var orderDatas = new List<OrderData>();

            for (var i = index; i < words.Count; i += 6)
            {
                if (i + 4 > words.Count)
                    break;

                var delimeterIndex = words[i + 4].IndexOf(",", StringComparison.Ordinal);
                var orderData = new OrderData
                {
                    FullName = words[i],
                    Representation = delimeterIndex != -1 ? words[i + 4].Substring(0, delimeterIndex) : words[i + 4]
                };

                if (words[i + 2].Contains(";"))
                {
                    var dates = words[i + 2].Split(';').ToList();
                    orderData.WorkDates = dates;
                }
                else
                {
                    orderData.WorkDates = new List<string> { words[i + 2] };
                }

                orderDatas.Add(orderData);

            }

            return orderDatas;
        }

        public Payment GetPayment() => payment;


        private List<string> GetWords(string path)
        {
            var document = new Document();
            document.LoadFromFile(path);
            return document.GetText().Replace("\r", string.Empty).Split('\n')
                .Where(w => !string.IsNullOrWhiteSpace(w)).Select(w => w.TrimEnd()).ToList();
        }
    }
}
