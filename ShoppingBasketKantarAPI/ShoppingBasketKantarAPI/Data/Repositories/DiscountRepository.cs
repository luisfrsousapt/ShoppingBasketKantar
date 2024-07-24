using Microsoft.EntityFrameworkCore;
using ShoppingBasketKantarAPI.Data.Entities;
using ShoppingBasketKantarAPI.Data.Repositories.Interfaces;

namespace ShoppingBasketKantarAPI.Data.Repositories
{
    public class DiscountRepository(AppDbContext _dbContext) : IDiscountRepository
    {

        public async Task<IEnumerable<Discount>> GetAllAsync()
        {
            return await _dbContext.Discounts.Where(p => !p.Deleted).Include(p => p.Rules).ToListAsync();
        }

        public async Task<Discount> GetByProductAsync(int productId)
        {
            return await _dbContext.Discounts.Where(p => !p.Deleted && p.ProductId == productId).Include(p => p.Rules).FirstOrDefaultAsync();
        }

        public async Task<Discount> GetByDiscountId(Guid id)
        {
            return await _dbContext.Discounts.Where(p => !p.Deleted && p.DiscountExternalId == id).Include(p => p.Rules).FirstOrDefaultAsync();
        }

        public async Task<Discount> GetByDiscountCodeAsync(string discountCode)
        {
            return await _dbContext.Discounts.Where(p => !p.Deleted && p.DiscountCode.ToLower() == discountCode.ToLower()).Include(p => p.Rules).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Discount discount)
        {
            await _dbContext.Discounts.AddAsync(discount);
        }

        public async Task UpdateAsync(Discount discount)
        {
            _dbContext.Entry(discount).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task<List<Discount>> GetDiscountsByProductsList(List<int> productIds)
        {
           return await _dbContext.Discounts.Include(d => d.Rules)
                .Where(d => d.ProductId.HasValue && productIds.Contains(d.ProductId.Value))
                .ToListAsync();
        }
    }
}
