using ShoppingBasketKantarAPI.Data.Entities;

namespace ShoppingBasketKantarAPI.Data.Repositories.Interfaces
{
    public interface IDiscountRepository
    {
        Task<IEnumerable<Discount>> GetAllAsync();
        Task<Discount> GetByDiscountId(Guid id);
        Task<Discount> GetByProductAsync(int productId);
        Task<Discount> GetByDiscountCodeAsync(string discountCode);
        Task AddAsync(Discount discount);
        Task UpdateAsync(Discount discount);

    }
}
