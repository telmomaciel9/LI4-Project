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
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
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
        [Authorize]
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
                TempData["success"] = "Category created successfully";
                return RedirectToAction(nameof(Index));

            }
            return View(feira);
        }

        //GET
        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var feiras = _context.Feiras.Find(id);


            if (feiras == null)
            {
                return NotFound();
            }

            return View(feiras);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Feiras obj)
        {
            if (obj.idFeira < 0)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Feiras.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Market updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var feiras = _context.Feiras.Find(id);
            

            if (feiras == null)
            {
                return NotFound();
            }

            return View(feiras);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _context.Feiras.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Feiras.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "Market deleted successfully";
            return RedirectToAction("Index");

        }

    }   
}
