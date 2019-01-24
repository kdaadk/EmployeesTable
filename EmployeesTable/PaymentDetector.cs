namespace EmployeesTable
{
    public static class PaymentDetector
    {
        public static Payment DetectFromComboBox(string input)
        {
            switch (input)
            {
                case @"Оплата":
                    return Payment.Money;
                case @"Отгул":
                    return Payment.Rest;
                default:
                    return Payment.Undefined;
            }
        }

        public static Payment DetectFromOrder(string line)
        {
            if (line.Contains("произвести оплату"))
                return Payment.Money;

            if (line.Contains("Предоставить выходной день"))
                return Payment.Rest;

            return Payment.Undefined;
        }
    }
}