using E_Com.Business.Interfaces;
using E_Com.Data;
using E_Com.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Com.Business.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        public ApplicationDbContext _context;
        public ProductCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ProductCategory> GetAllProductCategories()
        {
            return _context.ProductCategory.ToList();
        }

        public void UpdateCategory(int ProductCategoryId, string ProductCategoryName, string ProductCategoryDescription)
        {
            var existingCategory = _context.ProductCategory.Where(x => x.ProductCategoryId == ProductCategoryId).FirstOrDefault();
            if (existingCategory != null)
            {
                existingCategory.ProductCategoryName = ProductCategoryName;
                existingCategory.ProductCategoryDescription = ProductCategoryDescription;
                existingCategory.ModifiedAt = DateTime.Now;
                _context.Entry(existingCategory).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public ProductCategory CreateProductCategory(ProductCategory productCategory)
        {
            productCategory.CreatedAt = DateTime.Now;

            _context.ProductCategory.Add(productCategory);
            _context.SaveChanges();

            return productCategory;
        }
    }
}
