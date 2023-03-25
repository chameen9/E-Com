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

namespace E_Com.Controllers
{
    public class ProductsTestController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IProductService _productService;
        public IMemoryDeviceService _memoryDeviceService;

        public ProductsTestController(ApplicationDbContext context, IProductService productService, IMemoryDeviceService memoryDeviceService)
        {
            _context = context;
            _productService = productService;
            _memoryDeviceService = memoryDeviceService;
        }

        // GET: ProductsTest
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.MemoryDevices).Include(p => p.OperatingSytems).Include(p => p.Processors).Include(p => p.StorageDevices).Include(p => p.VGADevices);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductsTest/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.MemoryDevices)
                .Include(p => p.OperatingSytems)
                .Include(p => p.Processors)
                .Include(p => p.StorageDevices)
                .Include(p => p.VGADevices)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: ProductsTest/Create
        public IActionResult Create()
        {
            ViewData["MemoryDevicesList"] = _memoryDeviceService.GetAllMemoryDevices();
            ViewData["MemoryDeviceId"] = new SelectList(_context.MemoryDevices, "MemoryDeviceId", "MemoryDeviceId");
            ViewData["OSId"] = new SelectList(_context.OperatingSytems, "OSId", "OSId");
            ViewData["ProcessorTypeId"] = new SelectList(_context.Processors, "ProcessorTypeId", "ProcessorTypeId");
            ViewData["StorageDeviceId"] = new SelectList(_context.StorageDevices, "StorageDeviceId", "StorageDeviceId");
            ViewData["VGADeviceId"] = new SelectList(_context.VGADevices, "VGADeviceId", "VGADeviceId");
            return View();
        }

        // POST: ProductsTest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProcessorTypeId,MemoryDeviceId,VGADeviceId,OSId,StorageDeviceId,CreatedAt,ModifiedAt,DeletedAt")] Products products)
        {
            //var thisProductID = products.ProductId;
            //var existingProductId = _context.Products.FirstOrDefault(p => p.ProductId == thisProductID);
            //if(existingProductId == null) { return NotFound(); }
            //else
            //{
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
           
            //products.CreatedAt = DateTime.Now;
            //if (ModelState.IsValid)
            //{
            //    _context.Add(products);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["MemoryDeviceId"] = new SelectList(_context.MemoryDevices, "MemoryDeviceId", "MemoryDeviceId", products.MemoryDeviceId);
            //ViewData["OSId"] = new SelectList(_context.OperatingSytems, "OSId", "OSId", products.OSId);
            //ViewData["ProcessorTypeId"] = new SelectList(_context.Processors, "ProcessorTypeId", "ProcessorTypeId", products.ProcessorTypeId);
            //ViewData["StorageDeviceId"] = new SelectList(_context.StorageDevices, "StorageDeviceId", "StorageDeviceId", products.StorageDeviceId);
            //ViewData["VGADeviceId"] = new SelectList(_context.VGADevices, "VGADeviceId", "VGADeviceId", products.VGADeviceId);
            //return View(products);
        }

        // GET: ProductsTest/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["MemoryDeviceId"] = new SelectList(_context.MemoryDevices, "MemoryDeviceId", "MemoryDeviceId", products.MemoryDeviceId);
            ViewData["OSId"] = new SelectList(_context.OperatingSytems, "OSId", "OSId", products.OSId);
            ViewData["ProcessorTypeId"] = new SelectList(_context.Processors, "ProcessorTypeId", "ProcessorTypeId", products.ProcessorTypeId);
            ViewData["StorageDeviceId"] = new SelectList(_context.StorageDevices, "StorageDeviceId", "StorageDeviceId", products.StorageDeviceId);
            ViewData["VGADeviceId"] = new SelectList(_context.VGADevices, "VGADeviceId", "VGADeviceId", products.VGADeviceId);
            return View(products);
        }

        // POST: ProductsTest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProductId,ProductName,ProcessorTypeId,MemoryDeviceId,VGADeviceId,OSId,StorageDeviceId,CreatedAt,ModifiedAt,DeletedAt")] Products products)
        {
            if (id != products.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.ProductId))
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
            ViewData["MemoryDeviceId"] = new SelectList(_context.MemoryDevices, "MemoryDeviceId", "MemoryDeviceId", products.MemoryDeviceId);
            ViewData["OSId"] = new SelectList(_context.OperatingSytems, "OSId", "OSId", products.OSId);
            ViewData["ProcessorTypeId"] = new SelectList(_context.Processors, "ProcessorTypeId", "ProcessorTypeId", products.ProcessorTypeId);
            ViewData["StorageDeviceId"] = new SelectList(_context.StorageDevices, "StorageDeviceId", "StorageDeviceId", products.StorageDeviceId);
            ViewData["VGADeviceId"] = new SelectList(_context.VGADevices, "VGADeviceId", "VGADeviceId", products.VGADeviceId);
            return View(products);
        }

        // GET: ProductsTest/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.MemoryDevices)
                .Include(p => p.OperatingSytems)
                .Include(p => p.Processors)
                .Include(p => p.StorageDevices)
                .Include(p => p.VGADevices)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: ProductsTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var products = await _context.Products.FindAsync(id);
            if (products != null)
            {
                _context.Products.Remove(products);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(string id)
        {
          return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
