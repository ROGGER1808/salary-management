using System.ComponentModel.DataAnnotations;

namespace App_Salary_Management.Models;

public class TimeSheet
{
    [Display(Name = "ID")] [Key] public int TimeSheetID { get; set; }
    [Display(Name = "Ngày")] public DateTime date { get; set; }

    [Display(Name = "ID nhân viên")] public int EmployeeId { get; set; }

    [Display(Name = "Nhân viên")] public virtual Employee? Employee { get; set; }
}