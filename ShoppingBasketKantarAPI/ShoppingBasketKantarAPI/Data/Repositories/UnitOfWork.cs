using ShoppingBasketKantarAPI.Data.Repositories.Interfaces;

namespace ShoppingBasketKantarAPI.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        private IProductRepository? _productRepository;
        private IDiscountRepository? _discountRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IProductRepository ProductRepository { get { return _productRepository ??= new ProductRepository(_appDbContext); } }
        public IDiscountRepository DiscountRepository { get { return _discountRepository ??= new DiscountRepository(_appDbContext); } }

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
