using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationContext _context;

        public ReservationController(ReservationContext context)
        {
            _context = context;
        }

        // GET: /Contact
        public async Task<IActionResult> Index()
        {
            var list = await _context.Reservations.AsNoTracking().ToListAsync();
            return View(list);
        }

        // GET: /Contact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null) return NotFound();
            return View(reservation);
        }

        // GET: /Contact/Create
        public IActionResult Create() => View();

        // POST: /Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationDetails model)
        {
            if (!ModelState.IsValid) return View(model);
            _context.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Contact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null) return NotFound();
            return View(reservation);
        }

        // POST: /Contact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReservationDetails model)
        {
            if (id != model.Id) return BadRequest();
            if (!ModelState.IsValid) return View(model);

            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Reservations.AnyAsync(e => e.Id == id)) return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Contact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null) return NotFound();
            return View(reservation);
        }

        // POST: /Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}