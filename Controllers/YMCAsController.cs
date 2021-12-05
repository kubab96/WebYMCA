using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebYMCA.Data;
using WebYMCA.Models;

namespace WebYMCA.Controllers
{
    public class YMCAsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YMCAsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: YMCAs
        public async Task<IActionResult> Index()
        {
            return View(await _context.YMCA.OrderBy(x => x.Date).ToListAsync());
        }

        // GET: YMCAs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yMCA = await _context.YMCA
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yMCA == null)
            {
                return NotFound();
            }

            return View(yMCA);
        }

        // GET: YMCAs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YMCAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Waist,Weight,Age,IsMale")] YMCA yMCA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yMCA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yMCA);
        }

        // GET: YMCAs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yMCA = await _context.YMCA.FindAsync(id);
            if (yMCA == null)
            {
                return NotFound();
            }
            return View(yMCA);
        }

        // POST: YMCAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Waist,Weight,Age,IsMale")] YMCA yMCA)
        {
            if (id != yMCA.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yMCA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YMCAExists(yMCA.Id))
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
            return View(yMCA);
        }

        // GET: YMCAs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yMCA = await _context.YMCA
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yMCA == null)
            {
                return NotFound();
            }

            return View(yMCA);
        }

        // POST: YMCAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yMCA = await _context.YMCA.FindAsync(id);
            _context.YMCA.Remove(yMCA);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YMCAExists(int id)
        {
            return _context.YMCA.Any(e => e.Id == id);
        }
    }
}
