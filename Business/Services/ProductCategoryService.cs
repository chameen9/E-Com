using E_Com.Business.Interfaces;
using E_Com.Data;
using E_Com.Models.Data;

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
    }
}
