using BasicAPI.Abstract;
using BasicAPI.Entities;
using BasicAPI.Models;
using BasicAPIApp.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;

namespace BasicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : Controller
    {
        
        // dependency injection (bağımlılık enjeksiyonu)
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _productRepository.GetAllAsync();

            var result = new List<ProductModel>();

            foreach (var product in products)
            {
                var productModel = new ProductModel
                {
                    Name = product.Name,
                    Price = product.Price,
                    CategoryId = product.CategoryId
                    //CategoryName = product.Category.Name
                };

                result.Add(productModel);

            }
            return Ok(result);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsById(int id)
        {
           var product =  await _productRepository.GetByIdAsync(id);
            
            if(product == null)
            {
                return NotFound("Ürün Bulunamadı");
            }

            var result = new ProductModel
            {
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId
                //CategoryName =product.Category.Name
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductModel model)
        {
            Product product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                CategoryId = model.CategoryId
            };

            await _productRepository.AddAsync(product);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProduct model)
        {
            var entityToUpdate = await _productRepository.GetByIdAsync(id);
            if (entityToUpdate == null)
            {
                return NotFound("Ürün Bulunamadı");
            }

            entityToUpdate.Name = model.Name;
            entityToUpdate.Price = model.Price;
            entityToUpdate.CategoryId = model.CategoryId;

            await _productRepository.UpdateAsync(entityToUpdate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
             return NotFound("Ürün Bulunamadı"); 

            await _productRepository.DeleteAsync(product);
            return NoContent();
        }


    }
}
