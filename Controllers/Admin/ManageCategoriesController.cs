using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Com.Data;
using E_Com.Models.Data;
using E_Com.Business.Interfaces;
using E_Com.Business.Services;

namespace E_Com.Controllers.Admin
{
    public class ManageCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IProductCategoryService _productCategoryService;

        public ManageCategoriesController(ApplicationDbContext context, IProductCategoryService productCategoryService)
        {
            _context = context;
            _productCategoryService = productCategoryService;
        }

        // GET: ManageCategories
        public async Task<IActionResult> Index()
        {
              return _context.ProductCategory != null ? 
                          View(await _context.ProductCategory.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ProductCategory'  is null.");
        }

        // GET: ManageCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductCategory == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategory
                .FirstOrDefaultAsync(m => m.ProductCategoryId == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // GET: ManageCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManageCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCategory productCategory)
        {
            var CreatedProductCategory = _productCategoryService.CreateProductCategory(productCategory);


            if (CreatedProductCategory != null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: ManageCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductCategory == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategory.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            return View(productCategory);
        }

        // POST: ManageCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ProductCategoryId, string ProductCategoryName, string ProductCategoryDescription, ProductCategory productCategory)
        {
            if(ProductCategoryId != null)
            {
                _productCategoryService.UpdateCategory(ProductCategoryId, ProductCategoryName, ProductCategoryDescription);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                NotFound();
            }
            return View(productCategory);
        }

        // GET: ManageCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductCategory == null)
            {
                return NotFound();
            }

            var productCategory = await _context.ProductCategory
                .FirstOrDefaultAsync(m => m.ProductCategoryId == id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // POST: ManageCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductCategory == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductCategory'  is null.");
            }
            var productCategory = await _context.ProductCategory.FindAsync(id);
            if (productCategory != null)
            {
                _context.ProductCategory.Remove(productCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCategoryExists(int id)
        {
          return (_context.ProductCategory?.Any(e => e.ProductCategoryId == id)).GetValueOrDefault();
        }
    }
}
