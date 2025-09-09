using Back.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Repositories.IRepositories
{
    public interface IProductRepo
    {
        

        Product? GetProductById(int id);
        List<Product> GetAllProducts();
        Product AddProduct(Product product);
        Product? UpdateProduct(Product product);
        bool DeleteProduct(int id);
        
        
    }
}
