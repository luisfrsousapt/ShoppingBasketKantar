using Microsoft.AspNetCore.Mvc;
using ShoppingBasketKantarAPI.DTO;
using ShoppingBasketKantarAPI.Services.Interfaces;

namespace ShoppingBasketKantarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost]
        public async Task<ActionResult<BasketDTO>> GetBasket([FromBody] List<BasketProductDTO> productsInBasket)
        {
            return Ok(await _basketService.GetBasketAsync(productsInBasket));
        }
    }
}
