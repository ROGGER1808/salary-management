using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App_Salary_Management.Data;
using App_Salary_Management.Models;
using Microsoft.AspNetCore.Authorization;

namespace App_Salary_Management.Controllers
{
    [Authorize]
    public class TimeSheetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimeSheetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TimeSheet
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TimeSheets.Include(t => t.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TimeSheet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TimeSheets == null)
            {
                return NotFound();
            }

            var timeSheet = await _context.TimeSheets
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.TimeSheetID == id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            return View(timeSheet);
        }

        // GET: TimeSheet/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeID", "Name");
            return View();
        }

        // POST: TimeSheet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeSheetID,date,EmployeeId,Status")] TimeSheet timeSheet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeSheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeID", "Name", timeSheet.EmployeeId);
            return View(timeSheet);
        }

        // GET: TimeSheet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TimeSheets == null)
            {
                return NotFound();
            }

            var timeSheet = await _context.TimeSheets.FindAsync(id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeID", "Name", timeSheet.EmployeeId);
            return View(timeSheet);
        }

        // POST: TimeSheet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeSheetID,date,EmployeeId")] TimeSheet timeSheet)
        {
            if (id != timeSheet.TimeSheetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeSheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeSheetExists(timeSheet.TimeSheetID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeID", "Name", timeSheet.EmployeeId);
            return View(timeSheet);
        }

        // GET: TimeSheet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TimeSheets == null)
            {
                return NotFound();
            }

            var timeSheet = await _context.TimeSheets
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.TimeSheetID == id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            return View(timeSheet);
        }

        // POST: TimeSheet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TimeSheets == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TimeSheets'  is null.");
            }

            var timeSheet = await _context.TimeSheets.FindAsync(id);
            if (timeSheet != null)
            {
                _context.TimeSheets.Remove(timeSheet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeSheetExists(int id)
        {
            return (_context.TimeSheets?.Any(e => e.TimeSheetID == id)).GetValueOrDefault();
        }
    }
}