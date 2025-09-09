using Back.Models.Entities;
using System.Collections.Generic;

namespace Back.Services.IServices
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product? GetProductById(int id);
        Product AddProduct(Product product);
        Product? UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}
