using E_Com.Models.Data;

namespace E_Com.Business.Interfaces
{
    public interface IProductCategoryService
    {
        public List<ProductCategory> GetAllProductCategories();
        void UpdateCategory(int ProductCategoryId, string ProductCategoryName, string ProductCategoryDescription);
        ProductCategory CreateProductCategory(ProductCategory productCategory);
    }
}
