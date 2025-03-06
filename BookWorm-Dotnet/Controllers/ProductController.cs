using BookWorm_Dotnet.DTOs;
using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_Dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("addbulk")]
        public async Task<ActionResult<List<ProductMaster>>> AddProductsInBulk([FromBody] List<ProductMaster> products)
        {
            if (products == null || products.Count == 0) return BadRequest(new { Message = "Empty List Recieved" });
            var addedproducts = await _productService.AddProductsInBulk(products);
            return Ok(new { Products = addedproducts,Message ="Products added successfully" });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductMaster>> GetProductByIdAsync(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ProductMaster>>> GetAllProductsAsync()
        {
            return await _productService.GetAllProductsAsync();
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<FilteredProductsDTO>>> FilterProducts(
       [FromQuery] string? genreDesc,
       [FromQuery] string? languageDesc,
       [FromQuery] string? productType)
        {
            var filteredProducts = await _productService.GetFilteredProducts(genreDesc, languageDesc, productType);

            if (filteredProducts == null || filteredProducts.Count == 0)
            {
                return NotFound("No products found with the given filters.");
            }

            return Ok(filteredProducts);
        }
    }
}
