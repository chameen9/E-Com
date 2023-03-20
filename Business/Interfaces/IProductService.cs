using E_Com.Models.Data;

namespace E_Com.Business.Interfaces
{
    public interface IProductService
    {
        void AddProduct(Products model);
        List<Products> GetAllProducts();
        Products GetProductById(Guid? id);
        void EditProduct(Products model);
        void DeleteProdcut(Guid? id);
    }
}
