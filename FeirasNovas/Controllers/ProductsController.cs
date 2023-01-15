using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FeirasNovas.Data;
using FeirasNovas.Models;

namespace FeirasNovas.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
              return _context.Product != null ? 
                          View(await _context.Product.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Product'  is null.");
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.idProduto == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Feiras/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product products)
        {
            if (ModelState.IsValid)
            {
                _context.Product.Add(products);
                await _context.SaveChangesAsync();
                TempData["success"] = "Product created successfully";
                return RedirectToAction(nameof(Index));

            }
            return View(products);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var p = _context.Product.Find(id);


            if (p == null)
            {
                return NotFound();
            }

            return View(p);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            if (obj.idProduto < 0)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Product.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var P = _context.Product.Find(id);


            if (P == null)
            {
                return NotFound();
            }

            return View(P);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _context.Product.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Product.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
