using ShoppingBasketKantarAPI.Data.Entities;

namespace ShoppingBasketKantarAPI.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetTrendingProducts();
        Task<Product> GetByIdAsync(Guid id);
        Task<List<Product>> GetProductsListByIdAsync(List<Guid> ids);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);

    }
}
