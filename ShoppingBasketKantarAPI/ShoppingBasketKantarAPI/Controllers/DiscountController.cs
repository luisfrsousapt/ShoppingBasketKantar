using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingBasketKantarAPI.DTO;
using ShoppingBasketKantarAPI.Services.Interfaces;

namespace ShoppingBasketKantarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscountDTO>>> GetAllDiscounts()
        {
            return Ok(await _discountService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DiscountDTO discountDTO)
        {
            if (discountDTO == null)
            {
                return BadRequest("You need to have a discount in body");
            }

            return Ok(await _discountService.CreateAsync(discountDTO));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DiscountDTO discountDTO)
        {
            if (discountDTO == null)
            {
                return BadRequest("You need to have a product in body");
            }

            return Ok(await _discountService.UpdateAsync(discountDTO));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("You need to provide an id");
            }

            return Ok(await _discountService.DeleteAsync(id));
        }
    }
}
