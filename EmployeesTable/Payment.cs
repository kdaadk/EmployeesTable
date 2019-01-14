using System.ComponentModel.DataAnnotations;

namespace EmployeesTable
{
    public enum Payment
    {
        [Display(Name = "Оплата")]
        Money,
        [Display(Name = "Отгул")]
        Rest
    }
}
