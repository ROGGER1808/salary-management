using System.ComponentModel.DataAnnotations;

namespace App_Salary_Management.Models;

public class Department
{
    [Display(Name = "ID")] [Key] public int DepartmentID { get; set; }
    [Display(Name = "Tên phòng ban")] public String Name { get; set; }
    [Display(Name = "Mô tả")] public String Description { get; set; }

    public ICollection<Employee> Employees;
}