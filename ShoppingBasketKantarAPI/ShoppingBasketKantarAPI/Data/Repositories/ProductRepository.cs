using Microsoft.EntityFrameworkCore;
using ShoppingBasketKantarAPI.Data.Entities;
using ShoppingBasketKantarAPI.Data.Repositories.Interfaces;

namespace ShoppingBasketKantarAPI.Data.Repositories
{
    public class ProductRepository(AppDbContext _dbContext) : IProductRepository
    {

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.Where(p => !p.Deleted).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetTrendingProducts()
        {
            return await _dbContext.Products.Where(p => !p.Deleted).Take(3).ToListAsync();
        }
        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _dbContext.Products.Where(p => !p.Deleted && p.ProductExternalId == id).FirstOrDefaultAsync();
        }
        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
        }
        public async Task UpdateAsync(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            await Task.CompletedTask;
        }

    }
}
