using ShoppingBasketKantarAPI.DTO;

namespace ShoppingBasketKantarAPI.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<ProductDTO> GetByIdAsync(Guid id);
        Task<ProductDTO> CreateAsync(ProductDTO productDTO);
        Task<ProductDTO> UpdateAsync(ProductDTO productDTO);
        Task<ProductDTO> DeleteAsync(Guid id);
    }
}
