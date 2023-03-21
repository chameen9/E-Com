using E_Com.Models.Data;

namespace E_Com.Business.Interfaces
{
    public interface IProductService
    {
        void AddProduct(Products model);
        List<Products> GetAllProducts();
        Products GetProductById(string? id);
        void EditProduct(Products model);
        void DeleteProdcut(string? id);
    }
}
