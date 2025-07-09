using Microsoft.AspNetCore.Mvc;
// using Demo.Models; // Ensure this matches the actual namespace of your Person model

// If your Person model is in a different namespace, update the using directive accordingly, for example:
// using YourActualNamespace.Models;
// using Demo.Data; // Ensure this matches the namespace where ApplicationDbContext is defined

// Update the following using directives to match your actual namespaces:
// using Demo.Models; // Uncomment and update this line if your Person model is in Demo.Models
// using Demo.Models; // Replace 'Demo.Models' with the correct namespace if different
// Update the line below to the correct namespace for your Person model, for example:
// using Demo.Models; // Removed because 'Demo.Models' does not exist. Add the correct namespace for your Person model if needed.
// using Demo.Data;   // Replace with the actual namespace where 'ApplicationDbContext' is defined
// Update the line below to the correct namespace where ApplicationDbContext is defined, for example:
using Demo.Data; // Replace 'YourActualNamespace.Data' with the real namespace
using Microsoft.EntityFrameworkCore;
// Add the correct namespace for ApplicationDbContext if it's different
// For example, if ApplicationDbContext is in Demo.Models:
// using Demo.Models; // Removed because 'Demo.Models' does not exist. Add the correct namespace for your Person model if needed.
// using Demo.Data; // Removed because 'Demo.Data' does not exist or is not needed
// using Demo.Data; // Removed because 'Demo.Data' does not exist or is not needed

namespace Demo.Controllers
{
    public class PersonController : Controller
    {
        // Ensure ApplicationDbContext is defined in your project under the correct namespace
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.Persons.ToListAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FullName,Address")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonId,FullName,Address")] Person person)
        {
            if (id != person.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonId))
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
            return View(person);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Persons == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Persons'  is null.");
            }
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool PersonExists(string id)
        {
            return (_context.Persons?.Any(e => e.PersonId == id)).GetValueOrDefault();
        }
    }
}


