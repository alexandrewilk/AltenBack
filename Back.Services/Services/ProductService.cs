using Back.Models.Entities;
using Back.Repositories.IRepositories;
using Back.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Services.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepo _productRepo;
        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public List<Product> GetAllProducts()
        {
            return _productRepo.GetAllProducts();
        }
        public Product? GetProductById(int id)
        {
            return _productRepo.GetProductById(id);
        }
        public Product AddProduct(Product product)
        {
            // In real life all those add operations would check for a product with same primary key and return a T? not T
            product.CreatedAt = DateTime.Now;
            _productRepo.AddProduct(product);
            return product;
        }
        public Product? UpdateProduct(Product product)
        {
            product.UpdatedAt= DateTime.Now;
            return _productRepo.UpdateProduct(product);
        }
        public bool DeleteProduct(int id)
        {
            return _productRepo.DeleteProduct(id);  
        }

    }
}
