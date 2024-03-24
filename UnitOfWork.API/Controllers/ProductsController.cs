using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Domain.Entities;
using UnitOfWork.Services.Interfaces;

namespace UnitOfWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var productList = await _productService.GetAllProducts();
            if (productList == null)
                return NotFound();

            return Ok(productList);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var product = await _productService.GetProductById(productId);
            if (product != null)
                return Ok(product);
            else
                return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var isProductCreated = await _productService.CreateProduct(product);
            if (isProductCreated)
                return Ok(isProductCreated);
            else
                return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            if (product == null)
                return BadRequest();

            var isProductCreated = await _productService.UpdateProduct(product);
            if (isProductCreated)
                return Ok(isProductCreated);
            else
                return BadRequest();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var isProductCreated = await _productService.DeleteProduct(productId);
            if (isProductCreated)
                return Ok(isProductCreated);
            else
                return BadRequest();
        }
    }
}
