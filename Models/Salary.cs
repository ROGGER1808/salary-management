using System.ComponentModel.DataAnnotations;

namespace App_Salary_Management.Models;

public class Salary
{
    [Display(Name = "ID")]
    public int EmployeeID { get; set; }
    [Display(Name = "Tên")]
    public String Name { get; set; }
    [Display(Name = "Email")]
    public String Email { get; set; }
    [Display(Name = "Số điện thoại")]
    public String Phone { get; set; }
    [Display(Name = "Địa chỉ")]
    public String Address { get; set; }
    [Display(Name = "Lương cơ sở (ngày)")]
    [DisplayFormat(DataFormatString = "{0:#,##0}")]
    public Double BaseSalary { get; set; }
    [Display(Name = "Lương đạt được")]
    [DisplayFormat(DataFormatString = "{0:#,##0}")]
    public  Double Salaryb { get; set; }
    [Display(Name = "Tháng")]
    public int Moth { get; set; }
    [Display(Name = "Năm")]
    public int year { get; set; }
    [Display(Name = "Số ngày làm việc")]
    public int WorkNumberDay { get; set; }

}