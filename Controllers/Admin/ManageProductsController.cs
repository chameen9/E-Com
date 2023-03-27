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
using Microsoft.AspNetCore.Authorization;

namespace E_Com.Controllers.Admin
{
    [Authorize]
    public class ManageProductsController : Controller
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

        public ManageProductsController(
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

        // GET: ManageProducts
        public async Task<IActionResult> Index()
        {
            ViewData["ProductsList"] = _productService.GetAllProducts();

            return View();
        }

        // GET: ManageProducts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var product = _productService.GetProductById(id);
            ViewData["Product"] = _productService.GetProductById(id);

            return View(product);
        }

        // GET: ManageProducts/Create
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

        // POST: ManageProducts/Create
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
        }

        // GET: ManageProducts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            ViewData["MemoryDeviceList"] = _memoryDeviceService.GetAllMemoryDevices();
            ViewData["OperatingSystemsList"] = _osService.GetAllOperatingSystems();
            ViewData["ProcessorsList"] = _processorService.GetAllProcessors();
            ViewData["ProductCategoriesList"] = _productCategoryService.GetAllProductCategories();
            ViewData["StorageDevicesList"] = _storageDevices.GetAllStorageDevices();
            ViewData["VGADevicesList"] = _vgaService.GetAllVGADevices();

            var product = _productService.GetProductById(id);

            ViewData["Product"] = product;

            return View(product);
        }

        // POST: ManageProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string ProductId, string ProductName, string ProductDescription, int ProductCategoryId, int ProcessorTypeId, int MemoryDeviceId, int VGADeviceId, int OSId, int StorageDeviceId, double Price, IFormFile ImageFile, Products products)
        {
            if(products.ImageFile == null)
            {
                _productService.UpdateProduct(ProductId, ProductName, ProductDescription, ProductCategoryId, ProcessorTypeId, MemoryDeviceId, VGADeviceId, OSId, StorageDeviceId, Price);
            }
            else
            {
                products.ModifiedAt = DateTime.Now;
                products.ImageFileName = UploadedFile(products);

                _context.Entry(products).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public string UploadedFile(Products product)
        {
            string uniqueFileName = null;
            if (product.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + product.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    product.ImageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        // GET: ManageProducts/Delete/5
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

        // POST: ManageProducts/Delete/5
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
