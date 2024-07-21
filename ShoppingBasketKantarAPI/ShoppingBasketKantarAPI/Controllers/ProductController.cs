using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingBasketKantarAPI.DTO;
using ShoppingBasketKantarAPI.Services.Interfaces;

namespace ShoppingBasketKantarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            return Ok(await _productService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                return BadRequest("You need to have a product in body");
            }

            return Ok(await _productService.CreateAsync(productDTO));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                return BadRequest("You need to have a product in body");
            }

            return Ok(await _productService.UpdateAsync(productDTO));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("You need to provide an id");
            }

            return Ok(await _productService.DeleteAsync(id));
        }
    }
}
