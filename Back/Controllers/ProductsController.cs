using Back.Models;
using Back.Models.Entities;
using Back.Services;
using Back.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace Back.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ProductsController: ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        [Authorize]
        // in real life would be a AddProductDto object 
        public ActionResult<Product> AddProduct([FromBody] Product product)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (userEmail != "admin@admin")
            {
                return Forbid();
            }

            var newProduct = _productService.AddProduct(product);
            return CreatedAtAction(nameof(AddProduct), newProduct);
        }

        [HttpPut("{id}")]
        [Authorize]
        //in real life would be a patch with ProductUpdateDto from body
        public ActionResult<Product> UpdateProduct(int id, [FromBody] Product product)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (userEmail != "admin@admin")
            {
                return Forbid();
            }
            var res = _productService.UpdateProduct(product);
            if (res == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteProduct(int id)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (userEmail != "admin@admin")
            {
                return Forbid();
            }

            var success = _productService.DeleteProduct(id);
            if (!success)
            {
                return NotFound(); 
            }

            return Ok();
        }
    }

}