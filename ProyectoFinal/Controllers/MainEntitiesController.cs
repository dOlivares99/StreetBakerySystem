using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    [Authorize]
    public class MainEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MainEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MainEntities
        public async Task<IActionResult> Index()
        {
              return _context.AdminBaker != null ? 
                          View(await _context.AdminBaker.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AdminBaker'  is null.");
        }

        // GET: MainEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AdminBaker == null)
            {
                return NotFound();
            }

            var mainEntity = await _context.AdminBaker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mainEntity == null)
            {
                return NotFound();
            }

            return View(mainEntity);
        }

        // GET: MainEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MainEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Mobile,Email,Soruce")] MainEntity mainEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mainEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mainEntity);
        }

        // GET: MainEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AdminBaker == null)
            {
                return NotFound();
            }

            var mainEntity = await _context.AdminBaker.FindAsync(id);
            if (mainEntity == null)
            {
                return NotFound();
            }
            return View(mainEntity);
        }

        // POST: MainEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,Mobile,Email,Soruce")] MainEntity mainEntity)
        {
            if (id != mainEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainEntityExists(mainEntity.Id))
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
            return View(mainEntity);
        }

        // GET: MainEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AdminBaker == null)
            {
                return NotFound();
            }

            var mainEntity = await _context.AdminBaker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mainEntity == null)
            {
                return NotFound();
            }

            return View(mainEntity);
        }

        // POST: MainEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AdminBaker == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AdminBaker'  is null.");
            }
            var mainEntity = await _context.AdminBaker.FindAsync(id);
            if (mainEntity != null)
            {
                _context.AdminBaker.Remove(mainEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainEntityExists(int id)
        {
          return (_context.AdminBaker?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
