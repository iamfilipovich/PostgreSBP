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
    public class rezervacijesController : Controller
    {
        private readonly PostgreHotelContext _context;

        public rezervacijesController(PostgreHotelContext context)
        {
            _context = context;
        }

        // GET: rezervacijes
        public async Task<IActionResult> Index()
        {
            return View(await _context.rezervacije.ToListAsync());
        }

        // GET: rezervacijes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacije = await _context.rezervacije
                .FirstOrDefaultAsync(m => m.rezervacijaid == id);
            if (rezervacije == null)
            {
                return NotFound();
            }

            return View(rezervacije);
        }

        // GET: rezervacijes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: rezervacijes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("rezervacijaid,gostid,sobaid,datumdolaska,datumodlaska")] rezervacije rezervacije)
        {
            if (ModelState.IsValid)
            {
                rezervacije.datumdolaska = DateTime.UtcNow;
                rezervacije.datumodlaska = DateTime.UtcNow;

                _context.Add(rezervacije);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rezervacije);
        }

        // GET: rezervacijes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacije = await _context.rezervacije.FindAsync(id);
            if (rezervacije == null)
            {
                return NotFound();
            }
            return View(rezervacije);
        }

        // POST: rezervacijes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("rezervacijaid,gostid,sobaid,datumdolaska,datumodlaska")] rezervacije rezervacije)
        {
            if (id != rezervacije.rezervacijaid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervacije);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!rezervacijeExists(rezervacije.rezervacijaid))
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
            return View(rezervacije);
        }

        // GET: rezervacijes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacije = await _context.rezervacije
                .FirstOrDefaultAsync(m => m.rezervacijaid == id);
            if (rezervacije == null)
            {
                return NotFound();
            }

            return View(rezervacije);
        }

        // POST: rezervacijes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervacije = await _context.rezervacije.FindAsync(id);
            if (rezervacije != null)
            {
                _context.rezervacije.Remove(rezervacije);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool rezervacijeExists(int id)
        {
            return _context.rezervacije.Any(e => e.rezervacijaid == id);
        }
    }
}
