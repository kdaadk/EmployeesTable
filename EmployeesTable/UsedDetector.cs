namespace EmployeesTable
{
    public class UsedDetector
    {
        public static Used DetectFromComboBox(string input)
        {
            switch (input)
            {
                case @"Да":
                    return Used.YesFull;
                case @"Частично":
                    return Used.YesPartially;
                case @"Не использован":
                    return Used.No;
                default:
                    return Used.Undefined;
            }
        }
    }
}
