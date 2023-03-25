using E_Com.Models.Data;
using Microsoft.CodeAnalysis;
using System.Security.Cryptography;

namespace E_Com.Business.Interfaces
{
    public interface IProductService
    {
        //void AddProduct(Products model);
        Products AddProduct(string ProductId, string ProductName, string ProductDescription, int ProductCategoryId, int ProcessorTypeId, int MemoryDeviceId, int VGADeviceId, int OSId, int StorageDeviceId, double Price, IFormFile ImageFile);
        Products CreateProduct(Products products);
        List<Products> GetAllProducts();
        Products GetProductById(string? id);
        void EditProduct(Products model);
        void DeleteProdcut(string? id);
    }
}
