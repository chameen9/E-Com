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
using System.Security.Cryptography;

using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace E_Com.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _env;

        public IMemoryDeviceService _memoryDeviceService;
        public IOSService _osService;
        public IProcessorService _processorService;
        public IProductCategoryService _productCategoryService;
        public IStorageDevicesService _storageDevices;
        public IVGAService _vgaService;

        public IProductService _productService;

        public ProductsController(
            ApplicationDbContext context, 
            IMemoryDeviceService memoryDeviceService, 
            IOSService osService, 
            IProcessorService processorService,
            IProductCategoryService productCategoryService,
            IStorageDevicesService storageDevices,
            IVGAService vgaService,
            IProductService productService,
            IWebHostEnvironment env
            )
        {
            _context = context;
            _memoryDeviceService = memoryDeviceService;
            _osService = osService;
            _processorService = processorService;
            _productCategoryService = productCategoryService;
            _storageDevices = storageDevices;
            _vgaService = vgaService;
            _productService = productService;
            _env = env;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            ViewData["ProductsList"] = _productService.GetAllProducts();

            return View();
        }

        // GET: Products/Details/5
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
                .Include(p => p.ProductCategory)
                .Include(p => p.StorageDevices)
                .Include(p => p.VGADevices)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["MemoryDeviceList"] = _memoryDeviceService.GetAllMemoryDevices();
            ViewData["OperatingSystemsList"] = _osService.GetAllOperatingSystems();
            ViewData["ProcessorsList"] = _processorService.GetAllProcessors();
            ViewData["ProductCategoriesList"] = _productCategoryService.GetAllProductCategories();
            ViewData["StorageDevicesList"] = _storageDevices.GetAllStorageDevices();
            ViewData["VGADevicesList"] = _vgaService.GetAllVGADevices();
            var product = new Products();

            return View(product);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Products product)
        {
            var CreatedProduct = _productService.CreateProduct(product);


            if (CreatedProduct != null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
            //string ProductId, string ProductName, string ProductDescription, string ProductCategoryId, string ProcessorTypeId, string MemoryDeviceId,string VGADeviceId,string OSId,string StorageDeviceId, string Price, IFormFile ImageFile
            //string uniqueFileName = UploadedFile(product);
            //var model = _productService.AddProduct(ProductId, ProductName, ProductDescription, Convert.ToInt32(ProductCategoryId), Convert.ToInt32(ProcessorTypeId), Convert.ToInt32(MemoryDeviceId), Convert.ToInt32(VGADeviceId), Convert.ToInt32(OSId), Convert.ToInt32(StorageDeviceId), Convert.ToDouble(Price), ImageFile);

           
            //return RedirectToAction(nameof(Index));

            return View();
        }

        // GET: Products/Edit/5
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
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "ProductCategoryId", "ProductCategoryId", products.ProductCategoryId);
            ViewData["StorageDeviceId"] = new SelectList(_context.StorageDevices, "StorageDeviceId", "StorageDeviceId", products.StorageDeviceId);
            ViewData["VGADeviceId"] = new SelectList(_context.VGADevices, "VGADeviceId", "VGADeviceId", products.VGADeviceId);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProductId,ProductName,ProductDescription,ProductCategoryId,ProcessorTypeId,MemoryDeviceId,VGADeviceId,OSId,StorageDeviceId,CreatedAt,ModifiedAt,DeletedAt")] Products products)
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
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategory, "ProductCategoryId", "ProductCategoryId", products.ProductCategoryId);
            ViewData["StorageDeviceId"] = new SelectList(_context.StorageDevices, "StorageDeviceId", "StorageDeviceId", products.StorageDeviceId);
            ViewData["VGADeviceId"] = new SelectList(_context.VGADevices, "VGADeviceId", "VGADeviceId", products.VGADeviceId);
            return View(products);
        }

        // GET: Products/Delete/5
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
                .Include(p => p.ProductCategory)
                .Include(p => p.StorageDevices)
                .Include(p => p.VGADevices)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Products == null)
            {
                return Problem("Product is null.");
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
         
        public string UploadedFile (Products product)
        {
            string uniqueFileName = null;
            if (product.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + product.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    product.ImageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
