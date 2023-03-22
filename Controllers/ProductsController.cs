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
    public class ProductsController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly IProductService _productService;
        private readonly IMemoryDeviceService _memoryDeviceService;
        private readonly IOSService _operatingSystemService;
        private readonly IProcessorSrvice _processorService;
        private readonly IStraogeServices _straogeServices;
        private readonly IVGAService _vgaServices;

        public ProductsController(IProductService productService, IMemoryDeviceService memoryDeviceService, IOSService operatingSystemService, IProcessorSrvice processorService, IStraogeServices straogeServices, IVGAService vgaServices)
        {
            _productService = productService;
            _memoryDeviceService = memoryDeviceService;
            _operatingSystemService = operatingSystemService;
            _operatingSystemService = operatingSystemService;
            _processorService = processorService;
            _straogeServices = straogeServices;
            _vgaServices = vgaServices;
        }
       

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);

        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);

        }

        // GET: Products/Create
        public IActionResult Create()
        {

            ViewData["MemoryDeviceId"] = new SelectList(_memoryDeviceService.GetAllMemoryDevices(), "MemoryDeviceId", "MemoryDeviceId");
            ViewData["OSId"] = new SelectList(_operatingSystemService.GetAllOperatingSystems(), "OSId", "OSId");
            ViewData["ProcessorTypeId"] = new SelectList(_processorService.GetAllProcessors(), "ProcessorTypeId", "ProcessorTypeId");
            ViewData["StorageDeviceId"] = new SelectList(_straogeServices.GetAllStorageDevices(), "StorageDeviceId", "StorageDeviceId");
            ViewData["VGADeviceId"] = new SelectList(_vgaServices.GetAllVGADevices(), "VGADeviceId", "VGADeviceId");

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Products products)
        {
            //if (ModelState.IsValid)
            //{
            //    _productService.AddProduct(products);
            //    return RedirectToAction(nameof(Index));
            //}
            _productService.AddProduct(products);
            return RedirectToAction(nameof(Index));
            //return View(products);

        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);

        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Products product)
        {
            if(product != null)
            {
                _productService.EditProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            _productService.DeleteProdcut(id);
            return RedirectToAction();
        }

        private bool ProductsExists(string id)
        {
          //return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
            return false;
        }
    }
}
