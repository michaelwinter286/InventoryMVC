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
    public class LivestocksController : Controller
    {
        private readonly InventoryDBContext _context;

        public LivestocksController(InventoryDBContext context)
        {
            _context = context;
        }

        // GET: Livestocks
        public async Task<IActionResult> Index()
        {
              return _context.Livestock != null ? 
                          View(await _context.Livestock.ToListAsync()) :
                          Problem("Entity set 'InventoryDBContext.Livestock'  is null.");
        }

        // GET: Livestocks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Livestock == null)
            {
                return NotFound();
            }

            var livestock = await _context.Livestock
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livestock == null)
            {
                return NotFound();
            }

            return View(livestock);
        }

        // GET: Livestocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livestocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnimalTagOrName,Breed,Notes")] Livestock livestock)
        {
            if (ModelState.IsValid)
            {
                livestock.Id = Guid.NewGuid();
                _context.Add(livestock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livestock);
        }

        // GET: Livestocks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Livestock == null)
            {
                return NotFound();
            }

            var livestock = await _context.Livestock.FindAsync(id);
            if (livestock == null)
            {
                return NotFound();
            }
            return View(livestock);
        }

        // POST: Livestocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,AnimalTagOrName,Breed,Notes")] Livestock livestock)
        {
            if (id != livestock.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livestock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivestockExists(livestock.Id))
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
            return View(livestock);
        }

        // GET: Livestocks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Livestock == null)
            {
                return NotFound();
            }

            var livestock = await _context.Livestock
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livestock == null)
            {
                return NotFound();
            }

            return View(livestock);
        }

        // POST: Livestocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Livestock == null)
            {
                return Problem("Entity set 'InventoryDBContext.Livestock'  is null.");
            }
            var livestock = await _context.Livestock.FindAsync(id);
            if (livestock != null)
            {
                _context.Livestock.Remove(livestock);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivestockExists(Guid id)
        {
          return (_context.Livestock?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
