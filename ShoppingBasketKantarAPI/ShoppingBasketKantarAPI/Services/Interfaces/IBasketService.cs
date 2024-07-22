using ShoppingBasketKantarAPI.DTO;

namespace ShoppingBasketKantarAPI.Services.Interfaces
{
    public interface IBasketService
    {
        Task<BasketDTO> GetBasketAsync(List<BasketProductDTO> productsInBasket);
    }
}
