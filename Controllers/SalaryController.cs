using App_Salary_Management.Data;
using App_Salary_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_Salary_Management.Controllers;

[Authorize]
public class SalaryController : Controller
{
    private readonly ApplicationDbContext _context;

    public SalaryController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET
    public IActionResult Index()
    {
        var result = _context.TimeSheets
            .Join(_context.Employees, ts => ts.EmployeeId, e => e.EmployeeID,
                (e, ts) => new { e, ts })
            .GroupBy(x => new { x.e.EmployeeId, x.e.date.Month, x.e.date.Year })
            .Select(g => new
            {
                g.Key.EmployeeId,
                month = g.Key.Month,
                year = g.Key.Year,
                Count = g.Count()
            }).Join(_context.Employees, arg => arg.EmployeeId,
                employee => employee.EmployeeID, (arg, e) =>
                    new Salary
                    {
                        EmployeeID = e.EmployeeID,
                        Address = e.Address,
                        Email = e.Email,
                        Name = e.Name,
                        Phone = e.Phone,
                        BaseSalary = e.BaseSalary,
                        Salaryb = e.BaseSalary * arg.Count,
                        Moth = arg.month,
                        year = arg.year,
                        WorkNumberDay = arg.Count
                    }
            ).ToList();

        return View(result);
    }
}