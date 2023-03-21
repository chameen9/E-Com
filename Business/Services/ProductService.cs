using E_Com.Business.Interfaces;
using E_Com.Data;
using E_Com.Models.Data;

namespace E_Com.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Products model)
        {
            //model.ProductId = Guid.NewGuid();
            model.CreatedAt = DateTime.Now;
            _context.Products.Add(model);
            _context.SaveChanges();
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
            var products = _context.Products.Where(c => c.DeletedAt == null).ToList();
            return products;
        }

        public Products GetProductById(string? id)
        {
            if (id == null || _context.Products == null)
            {
                return null;
            }

            var product = _context.Products
                .FirstOrDefault(m => m.ProductId == id);
            if (product == null)
            {
                return null;
            }
            return product;
        }
    }
}
