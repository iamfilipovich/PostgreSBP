using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PostgreHotel.Data;

namespace PostgreHotel.Controllers
{
    public class gostisController : Controller
    {
        private readonly PostgreHotelContext _context;

        public gostisController(PostgreHotelContext context)
        {
            _context = context;
        }

        // GET: gostis
        public async Task<IActionResult> Index()
        {
            return View(await _context.gosti.ToListAsync());
        }

        // GET: gostis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gosti = await _context.gosti
                .FirstOrDefaultAsync(m => m.gostid == id);
            if (gosti == null)
            {
                return NotFound();
            }

            return View(gosti);
        }

        // GET: gostis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: gostis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("gostid,ime,prezime,adresa,telefon,email")] gosti gosti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gosti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gosti);
        }

        // GET: gostis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gosti = await _context.gosti.FindAsync(id);
            if (gosti == null)
            {
                return NotFound();
            }
            return View(gosti);
        }

        // POST: gostis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("gostid,ime,prezime,adresa,telefon,email")] gosti gosti)
        {
            if (id != gosti.gostid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gosti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!gostiExists(gosti.gostid))
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
            return View(gosti);
        }

        // GET: gostis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gosti = await _context.gosti
                .FirstOrDefaultAsync(m => m.gostid == id);
            if (gosti == null)
            {
                return NotFound();
            }

            return View(gosti);
        }

        // POST: gostis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gosti = await _context.gosti.FindAsync(id);
            if (gosti != null)
            {
                _context.gosti.Remove(gosti);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool gostiExists(int id)
        {
            return _context.gosti.Any(e => e.gostid == id);
        }
    }
}
