using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcEfCodeFirstDemo.Data;
using MvcEfCodeFirstDemo.Models;

namespace MvcEfCodeFirstDemo.Controllers.Boxes
{
    public class BoxesController : Controller
    {
        private readonly DataContext _context;

        public BoxesController(DataContext context)
        {
            _context = context;
        }

        // GET: Boxes
        public async Task<IActionResult> Index()
        {
              return _context.Boxes != null ? 
                          View(await _context.Boxes.ToListAsync()) :
                          Problem("Entity set 'DataContext.Boxes'  is null.");
        }

        // GET: Boxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Boxes == null)
            {
                return NotFound();
            }

            var box = await _context.Boxes
                .FirstOrDefaultAsync(m => m.Id == id);

            box.Sensors = await _context.Sensors.Where(s => s.BoxId == id).ToListAsync();

            if (box == null)
            {
                return NotFound();
            }

            return View(box);
        }

        // GET: Boxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boxes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Models.Box box)
        {
            if (ModelState.IsValid)
            {
                _context.Add(box);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(box);
        }

        // GET: Boxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Boxes == null)
            {
                return NotFound();
            }

            var box = await _context.Boxes.FindAsync(id);
            if (box == null)
            {
                return NotFound();
            }
            return View(box);
        }

        // POST: Boxes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Models.Box box)
        {
            if (id != box.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(box);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoxExists(box.Id))
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
            return View(box);
        }

        // GET: Boxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Boxes == null)
            {
                return NotFound();
            }

            var box = await _context.Boxes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (box == null)
            {
                return NotFound();
            }

            return View(box);
        }

        // POST: Boxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Boxes == null)
            {
                return Problem("Entity set 'DataContext.Boxes'  is null.");
            }
            var box = await _context.Boxes.FindAsync(id);
            if (box != null)
            {
                _context.Boxes.Remove(box);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoxExists(int id)
        {
          return (_context.Boxes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
