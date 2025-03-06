using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWorm_Dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeMasterController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeMasterController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        // GET: api/ProductTypeMaster
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTypeMaster>>> GetAllProductTypes()
        {
            var types = await _productTypeService.GetAllProductTypes();
            return Ok(types);
        }

        // GET: api/ProductTypeMaster/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTypeMaster>> GetProductTypeById(int id)
        {
            var type = await _productTypeService.GetProductTypeById(id);
            if (type == null)
            {
                return NotFound(new { message = "Product type not found" });
            }
            return Ok(type);
        }

        // POST: api/ProductTypeMaster
        [HttpPost]
        public async Task<ActionResult<ProductTypeMaster>> AddProductType(ProductTypeMaster type)
        {
            if (type == null)
            {
                return BadRequest(new { message = "Invalid product type data" });
            }

            var newType = await _productTypeService.AddProductType(type);
            return CreatedAtAction(nameof(GetProductTypeById), new { id = newType.TypeId }, newType);
        }
    }
}
