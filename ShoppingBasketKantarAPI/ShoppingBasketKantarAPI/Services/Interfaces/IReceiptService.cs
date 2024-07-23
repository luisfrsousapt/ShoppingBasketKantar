using ShoppingBasketKantarAPI.DTO;

namespace ShoppingBasketKantarAPI.Services.Interfaces
{
    public interface IReceiptService
    {

        Stream GetReceiptAsync(BasketDTO basket);
    }
}
