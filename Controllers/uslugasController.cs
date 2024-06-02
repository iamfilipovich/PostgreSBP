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
    public class uslugasController : Controller
    {
        private readonly PostgreHotelContext _context;

        public uslugasController(PostgreHotelContext context)
        {
            _context = context;
        }

        // GET: uslugas
        public async Task<IActionResult> Index()
        {
            return View(await _context.usluga.ToListAsync());
        }

        // GET: uslugas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usluga = await _context.usluga
                .FirstOrDefaultAsync(m => m.uslugaid == id);
            if (usluga == null)
            {
                return NotFound();
            }

            return View(usluga);
        }

        // GET: uslugas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: uslugas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("uslugaid,naziv,cijena,hotelid")] usluga usluga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usluga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usluga);
        }

        // GET: uslugas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usluga = await _context.usluga.FindAsync(id);
            if (usluga == null)
            {
                return NotFound();
            }
            return View(usluga);
        }

        // POST: uslugas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("uslugaid,naziv,cijena,hotelid")] usluga usluga)
        {
            if (id != usluga.uslugaid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usluga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!uslugaExists(usluga.uslugaid))
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
            return View(usluga);
        }

        // GET: uslugas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usluga = await _context.usluga
                .FirstOrDefaultAsync(m => m.uslugaid == id);
            if (usluga == null)
            {
                return NotFound();
            }

            return View(usluga);
        }

        // POST: uslugas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usluga = await _context.usluga.FindAsync(id);
            if (usluga != null)
            {
                _context.usluga.Remove(usluga);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool uslugaExists(int id)
        {
            return _context.usluga.Any(e => e.uslugaid == id);
        }
    }
}
