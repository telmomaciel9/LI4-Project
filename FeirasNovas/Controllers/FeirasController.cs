using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FeirasNovas.Data;
using FeirasNovas.Models;
using FeirasNovas.Services;
using Microsoft.AspNetCore.Identity;

namespace FeirasNovas.Controllers
{
    public class FeirasController : Controller
    {
        private readonly ApplicationDbContext _context;
       

        public FeirasController(ApplicationDbContext context)
        {
            _context = context;
    
        }

        // GET: Feiras
        public async Task<IActionResult> Index()
        {
              return _context.Feiras != null ? 
                          View(await _context.Feiras.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Feiras'  is null.");
        }

        // GET: Feiras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Feiras == null)
            {
                return NotFound();
            }

            var feiras = await _context.Feiras
                .FirstOrDefaultAsync(m => m.idFeira == id);
            if (feiras == null)
            {
                return NotFound();
            }

            return View(feiras);
        }

        // GET: Feiras/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Feiras feira)
        {
            if (ModelState.IsValid)
            {
                _context.Feiras.Add(feira);
                await _context.SaveChangesAsync();
                TempData["sucess"] = "Category created successfully";
                return RedirectToAction(nameof(Index));

            }
            return View(feira);
        }

        // GET: Feiras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Feiras == null)
            {
                return NotFound();
            }

            var feiras = await _context.Feiras.FindAsync(id);
            if (feiras == null)
            {
                return NotFound();
            }

            return View(feiras);
        }

        // POST: Feiras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idFeira,Categoria")] Feiras feiras)
        {
            if (id != feiras.idFeira)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feiras);
                    TempData["sucess"] = "Category updated successfully";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeirasExists(feiras.idFeira))
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
            return View(feiras);
        }

        // GET: Feiras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Feiras == null)
            {
                return NotFound();
            }

            var feiras = await _context.Feiras
                .FirstOrDefaultAsync(m => m.idFeira == id);
            if (feiras == null)
            {
                return NotFound();
            }

            return View(feiras);
        }

        // POST: Feiras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Feiras == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Feiras'  is null.");
            }
            var feiras = await _context.Feiras.FindAsync(id);
            if (feiras != null)
            {

                _context.Feiras.Remove(feiras);

            }
            
            await _context.SaveChangesAsync();
            TempData["sucess"] = "Category deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool FeirasExists(int id)
        {
          return (_context.Feiras?.Any(e => e.idFeira == id)).GetValueOrDefault();
        }
    }
}
