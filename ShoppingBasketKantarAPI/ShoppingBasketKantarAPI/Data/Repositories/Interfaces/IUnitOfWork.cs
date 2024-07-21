namespace ShoppingBasketKantarAPI.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
        IProductRepository ProductRepository { get; }
        IDiscountRepository DiscountRepository { get; }
    }
}
