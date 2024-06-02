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
    public class zaposlenicisController : Controller
    {
        private readonly PostgreHotelContext _context;

        public zaposlenicisController(PostgreHotelContext context)
        {
            _context = context;
        }

        // GET: zaposlenicis
        public async Task<IActionResult> Index()
        {
            return View(await _context.zaposlenici.ToListAsync());
        }

        // GET: zaposlenicis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaposlenici = await _context.zaposlenici
                .FirstOrDefaultAsync(m => m.zaposlenikid == id);
            if (zaposlenici == null)
            {
                return NotFound();
            }

            return View(zaposlenici);
        }

        // GET: zaposlenicis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: zaposlenicis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("zaposlenikid,ime,prezime,poziija,placa,hotelid")] zaposlenici zaposlenici)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zaposlenici);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zaposlenici);
        }

        // GET: zaposlenicis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaposlenici = await _context.zaposlenici.FindAsync(id);
            if (zaposlenici == null)
            {
                return NotFound();
            }
            return View(zaposlenici);
        }

        // POST: zaposlenicis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("zaposlenikid,ime,prezime,poziija,placa,hotelid")] zaposlenici zaposlenici)
        {
            if (id != zaposlenici.zaposlenikid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zaposlenici);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!zaposleniciExists(zaposlenici.zaposlenikid))
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
            return View(zaposlenici);
        }

        // GET: zaposlenicis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaposlenici = await _context.zaposlenici
                .FirstOrDefaultAsync(m => m.zaposlenikid == id);
            if (zaposlenici == null)
            {
                return NotFound();
            }

            return View(zaposlenici);
        }

        // POST: zaposlenicis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zaposlenici = await _context.zaposlenici.FindAsync(id);
            if (zaposlenici != null)
            {
                _context.zaposlenici.Remove(zaposlenici);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool zaposleniciExists(int id)
        {
            return _context.zaposlenici.Any(e => e.zaposlenikid == id);
        }
    }
}
