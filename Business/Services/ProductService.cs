using E_Com.Business.Interfaces;
using E_Com.Data;
using E_Com.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace E_Com.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductService(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public Products CreateProduct(Products products)
        {
            products.CreatedAt = DateTime.Now;

            var thisCategory = _context.ProductCategory.Where(x => x.ProductCategoryId == products.ProductCategoryId).FirstOrDefault();
            products.ProductCategory = thisCategory;
            var thisProcessor = _context.Processors.Where(x => x.ProcessorTypeId == products.ProcessorTypeId).FirstOrDefault();
            products.Processors = thisProcessor;
            var thisMemory = _context.MemoryDevices.Where(x => x.MemoryDeviceId == products.MemoryDeviceId).FirstOrDefault();
            products.MemoryDevices = thisMemory;
            var thisVGA = _context.VGADevices.Where(x => x.VGADeviceId == products.VGADeviceId).FirstOrDefault();
            products.VGADevices = thisVGA;
            var thisOS = _context.OperatingSytems.Where(x => x.OSId == products.OSId).FirstOrDefault();
            products.OperatingSytems = thisOS;
            var thisStorage = _context.StorageDevices.Where(x => x.StorageDeviceId == products.StorageDeviceId).FirstOrDefault();
            products.StorageDevices = thisStorage;

            products.ImageFileName = UploadedFile(products);
            _context.Products.Add(products);
            _context.SaveChanges();

            return products;
        }

        public Products AddProduct(string ProductId, string ProductName, string ProductDescription, int ProductCategoryId, int ProcessorTypeId, int MemoryDeviceId, int VGADeviceId, int OSId, int StorageDeviceId, double Price, IFormFile ImageFile)
        {
            var existingProductId = _context.Products.Where( x => x.ProductId == ProductId).FirstOrDefault();
            //Check Primary Key
            if (existingProductId != null)
            {
                return null;
            }
            else
            {
                var product = new Products();
                product.ProductId = ProductId;
                product.ProductName = ProductName;
                product.ProductDescription = ProductDescription;
                product.ProductCategoryId = ProductCategoryId;
                product.ProcessorTypeId = ProcessorTypeId;
                product.MemoryDeviceId = MemoryDeviceId;
                product.VGADeviceId = VGADeviceId;
                product.OSId = OSId;
                product.StorageDeviceId = StorageDeviceId;
                product.Price = Price;
                product.CreatedAt = DateTime.Now;

                var thisCategory = _context.ProductCategory.Where(x => x.ProductCategoryId == ProductCategoryId).FirstOrDefault();
                product.ProductCategory = thisCategory;
                var thisProcessor = _context.Processors.Where(x => x.ProcessorTypeId == ProcessorTypeId).FirstOrDefault();
                product.Processors = thisProcessor;
                var thisMemory = _context.MemoryDevices.Where(x => x.MemoryDeviceId == MemoryDeviceId).FirstOrDefault();
                product.MemoryDevices = thisMemory;
                var thisVGA = _context.VGADevices.Where(x => x.VGADeviceId == VGADeviceId).FirstOrDefault();
                product.VGADevices = thisVGA;
                var thisOS = _context.OperatingSytems.Where(x => x.OSId == OSId).FirstOrDefault();
                product.OperatingSytems = thisOS;
                var thisStorage = _context.StorageDevices.Where(x => x.StorageDeviceId == StorageDeviceId).FirstOrDefault();
                product.StorageDevices = thisStorage;

                //product.ImageFileName = "dump";
                _context.Products.Add(product);
                _context.SaveChanges();

                return product;

                //if (Image != null && Image.Length > 0)
                //{
                //    string fileName = Path.GetFileName(Image.FileName);
                //    string filePath = Path.Combine(_env.WebRootPath, "images", fileName);
                //    using (var fileStream = new FileStream(filePath, FileMode.Create))
                //    {
                //        await Image.CopyToAsync(fileStream);
                //    }
                //    product.ImageFileName = fileName;
                //}

                //if (imageFile != null && imageFile.Length > 0)
                //{
                //    string fileName = Path.GetFileName(imageFile.FileName);
                //    string filePath = Path.Combine(_environment.WebRootPath, "images", fileName);
                //    using (var stream = new FileStream(filePath, FileMode.Create))
                //    {
                //        await imageFile.CopyToAsync(stream);
                //    }

                //    product.ImageFileName = fileName;
                //}

                //_context.Products.Add(product);
                //_context.SaveChanges();

                //// retrieve the product from the database
                //var addedProduct = _context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);

                //if (addedProduct != null)
                //{
                    // the product was added successfully
                    //return product;
                //}
                //else
                //{
                //    // the product was not added to the database
                //    return null;
                //}
            }
        }

        public void DeleteProdcut(string? id)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if (product != null)
            {
                product.DeletedAt = DateTime.Now;
                _context.Products.Update(product);
                _context.SaveChanges();
            }
        }

        public void EditProduct(Products model)
        {
            _context.Update(model);
            _context.SaveChangesAsync();
        }

        public List<Products> GetAllProducts()
        {   
            var products = _context.Products.Where(c => c.DeletedAt == null)
                .Include(c => c.ProductCategory)
                .Include(c => c.Processors)
                .Include(c => c.MemoryDevices)
                .Include(c => c.VGADevices)
                .Include(c => c.OperatingSytems)
                .Include(c => c.StorageDevices)
                .ToList();
            return products;
        }

        public Products GetProductById(string? id)
        {
            if (id == null || _context.Products == null)
            {
                return null;
            }

            var product = _context.Products
                .Where(m => m.ProductId == id)
                .Include(c => c.ProductCategory)
                .Include(c => c.Processors)
                .Include(c => c.MemoryDevices)
                .Include(c => c.VGADevices)
                .Include(c => c.OperatingSytems)
                .Include(c => c.StorageDevices)
                .FirstOrDefault();
            if (product == null)
            {
                return null;
            }
            return product;
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
    }
}
