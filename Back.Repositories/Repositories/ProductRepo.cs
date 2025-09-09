using Back.Models.Entities;
using Back.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Repositories.Repositories
{
    public class ProductRepo : JsonRepoBase<Product>, IProductRepo
    {
        public ProductRepo() : base("products.json")
        {
        }

        public Product AddProduct(Product product)
        {
            _items.Add(product);
            SaveChanges();
            return product;
        }

        public bool DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _items.Remove(product);
                SaveChanges();
                return true;
            }
            return false;
        }

        public List<Product> GetAllProducts()
        {
            return _items.ToList();
        }

        public Product? GetProductById(int id)
        {
            return _items.FirstOrDefault(p => p.Id == id);
        }

        public Product? UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.Id);
            if (existingProduct != null)
            {
                var index = _items.IndexOf(existingProduct);
                _items[index] = product;
                SaveChanges();
            }
            return existingProduct;
        }
    }
}
