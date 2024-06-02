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
    public class sobesController : Controller
    {
        private readonly PostgreHotelContext _context;

        public sobesController(PostgreHotelContext context)
        {
            _context = context;
        }

        // GET: sobes
        public async Task<IActionResult> Index()
        {
            return View(await _context.sobe.ToListAsync());
        }

        // GET: sobes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sobe = await _context.sobe
                .FirstOrDefaultAsync(m => m.sobaid == id);
            if (sobe == null)
            {
                return NotFound();
            }

            return View(sobe);
        }

        // GET: sobes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: sobes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("sobaid,tipsobe,brojkreveta,cijena,hotelid")] sobe sobe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sobe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sobe);
        }

        // GET: sobes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sobe = await _context.sobe.FindAsync(id);
            if (sobe == null)
            {
                return NotFound();
            }
            return View(sobe);
        }

        // POST: sobes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("sobaid,tipsobe,brojkreveta,cijena,hotelid")] sobe sobe)
        {
            if (id != sobe.sobaid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sobe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sobeExists(sobe.sobaid))
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
            return View(sobe);
        }

        // GET: sobes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sobe = await _context.sobe
                .FirstOrDefaultAsync(m => m.sobaid == id);
            if (sobe == null)
            {
                return NotFound();
            }

            return View(sobe);
        }

        // POST: sobes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sobe = await _context.sobe.FindAsync(id);
            if (sobe != null)
            {
                _context.sobe.Remove(sobe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sobeExists(int id)
        {
            return _context.sobe.Any(e => e.sobaid == id);
        }
    }
}
