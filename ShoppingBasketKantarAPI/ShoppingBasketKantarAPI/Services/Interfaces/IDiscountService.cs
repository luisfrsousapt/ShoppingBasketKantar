using ShoppingBasketKantarAPI.Data.Entities;
using ShoppingBasketKantarAPI.DTO;

namespace ShoppingBasketKantarAPI.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<IEnumerable<DiscountDTO>> GetAllAsync();
        Task<DiscountDTO> GetByProductAsync(Guid productExternalId);
        Task<DiscountDTO> GetByDiscountCodeAsync(string code);
        Task<DiscountDTO> CreateAsync(DiscountDTO discountDTO);
        Task<DiscountDTO> UpdateAsync(DiscountDTO discountDTO);
        Task<DiscountDTO> DeleteAsync(Guid id);

    }
}
