using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Data;

namespace FirstWebMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await (_context.Employees as DbSet<Employee>).ToListAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Age")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                (_context.Employees as DbSet<Employee>).Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            if (!int.TryParse(id, out int employeeId))
            {
                return NotFound();
            }
            var employee = await (_context.Employees as DbSet<Employee>).FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmployeeId,Age")] Employee employee)
        {
            if (!int.TryParse(id, out int parsedId) || employee.EmployeeId != parsedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            return View(employee);
        }

        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }
            if (!int.TryParse(id, out int employeeId))
            {
                return NotFound();
            }
            var employee = await (_context.Employees as DbSet<Employee>)
                .FirstOrDefaultAsync(m => m.EmployeeId == employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Employees'  is null.");
            }
            var employee = await (_context.Employees as DbSet<Employee>).FindAsync(id);
            if (employee != null)
            {
                (_context.Employees as DbSet<Employee>).Remove(employee);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int? id)
        {
            if (id == null)
            {
                return false;
            }
            return (_context.Employees as DbSet<Employee>)?.Any(e => e.EmployeeId == id) ?? false;
        }
    }
}