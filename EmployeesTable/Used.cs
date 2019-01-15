using System.ComponentModel.DataAnnotations;

namespace EmployeesTable
{
    public enum Used
    {
        [Display(Name = "Да")] YesFull,
        [Display(Name = "Частично")] YesPartially,
        [Display(Name = "Не использован")] No
    }
}