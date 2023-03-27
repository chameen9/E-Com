using E_Com.Models.Data;
using Microsoft.CodeAnalysis;
using System.Security.Cryptography;

namespace E_Com.Business.Interfaces
{
    public interface IProductService
    {
        //void AddProduct(Products model);
        
        void UpdateProduct(string ProductId, string ProductName, string ProductDescription, int ProductCategoryId, int ProcessorTypeId, int MemoryDeviceId, int VGADeviceId, int OSId, int StorageDeviceId, double Price);
        Products CreateProduct(Products products);
        List<Products> GetAllProducts();
        Products GetProductById(string? id);
        void DeleteProdcut(string? id);
    }
}
