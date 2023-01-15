using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FeirasNovas.Data;
using FeirasNovas.Models;
using Microsoft.AspNetCore.Identity;

namespace FeirasNovas.Controllers
{
    public class FeirasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FeirasController(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _userManager = user;

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

        // POST: Feiras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idFeira,Categoria,VenderUsername")] Feiras feiras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feiras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feiras);
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
        public async Task<IActionResult> Edit(int id, [Bind("idFeira,Categoria,VenderUsername")] Feiras feiras)
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
            return RedirectToAction(nameof(Index));
        }

        private bool FeirasExists(int id)
        {
          return (_context.Feiras?.Any(e => e.idFeira == id)).GetValueOrDefault();
        }

        public async Task<List<ApplicationUser>> GetUsersByFeira(Feiras feira)
        {
            var users = new List<ApplicationUser>();
            foreach (var username in feira.UserNames)
            {
                var user = await _userManager.FindByNameAsync(username);
                users.Add(user);
            }
            return users;
        }

        public async Task AddUserToFeira(Feiras feira, string username)
        {
            feira.UserNames.Add(username);
            await _context.SaveChangesAsync();
        }

    }



}
