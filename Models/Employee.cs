using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App_Salary_Management.Models;

public class Employee
{
    [Display(Name = "ID")] [Key] public int EmployeeID { get; set; }
    [Display(Name = "Tên nhân viên")] public String Name { get; set; }
    [Display(Name = "Email")] public String Email { get; set; }
    [Display(Name = "Số điện thoại")] public String Phone { get; set; }
    [Display(Name = "Địa chỉ")] public String Address { get; set; }
    [Display(Name = "Lương cơ sở (ngày)")] public Double BaseSalary { get; set; }

    [NotMapped] public Double Salary { get; set; }

    [Display(Name = "ID phòng ban")] public int DepartmentID { get; set; }
    [Display(Name = "Phòng ban")] public virtual Department? Department { get; set; }

    public ICollection<TimeSheet> TimeSheets;
}