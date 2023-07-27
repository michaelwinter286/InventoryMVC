using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryMVC;
using InventoryMVC.Models;

namespace InventoryMVC.Controllers
{
    public class SuppliesController : Controller
    {
        private readonly InventoryDBContext _context;

        public SuppliesController(InventoryDBContext context)
        {
            _context = context;
        }

        //Single Responsibility Principle (SRP) / Since all of the task function indepentently of each other I made sure seperate all the methods to cut out the errors.

        // GET: Supplies
        public async Task<IActionResult> Index()
        {
              return _context.Supplies != null ? 
                          View(await _context.Supplies.ToListAsync()) :
                          Problem("Entity set 'InventoryDBContext.Supplies'  is null.");
        }

        // GET: Supplies/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Supplies == null)
            {
                return NotFound();
            }

            var supplies = await _context.Supplies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supplies == null)
            {
                return NotFound();
            }

            return View(supplies);
        }

        // GET: Supplies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Item,Amount,Minimum,Description")] Supplies supplies)
        {
            if (ModelState.IsValid)
            {
                supplies.Id = Guid.NewGuid();
                _context.Add(supplies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplies);
        }

        // GET: Supplies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Supplies == null)
            {
                return NotFound();
            }

            var supplies = await _context.Supplies.FindAsync(id);
            if (supplies == null)
            {
                return NotFound();
            }
            return View(supplies);
        }

        // POST: Supplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Item,Amount,Minimum,Description")] Supplies supplies)
        {
            if (id != supplies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuppliesExists(supplies.Id))
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
            return View(supplies);
        }

        // GET: Supplies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Supplies == null)
            {
                return NotFound();
            }

            var supplies = await _context.Supplies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supplies == null)
            {
                return NotFound();
            }

            return View(supplies);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Supplies == null)
            {
                return Problem("Entity set 'InventoryDBContext.Supplies'  is null.");
            }
            var supplies = await _context.Supplies.FindAsync(id);
            if (supplies != null)
            {
                _context.Supplies.Remove(supplies);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuppliesExists(Guid id)
        {
          return (_context.Supplies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
