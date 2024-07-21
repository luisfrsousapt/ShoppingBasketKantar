using AutoMapper;
using ShoppingBasketKantarAPI.Data.Entities;
using ShoppingBasketKantarAPI.Data.Repositories.Interfaces;
using ShoppingBasketKantarAPI.DTO;
using ShoppingBasketKantarAPI.Services.Interfaces;

namespace ShoppingBasketKantarAPI.Services
{
    public class ProductService : IProductService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetByIdAsync(Guid id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> CreateAsync(ProductDTO productDTO)
        {
           // await Validate(productDTO);

            var productEntity = _mapper.Map<Product>(productDTO);
            productEntity.ProductExternalId = Guid.NewGuid();
            var utcDate = DateTime.UtcNow;
            productEntity.CreateDate = utcDate;
            productEntity.CreateUserId = 1; // TODO USER ID

            await _unitOfWork.ProductRepository.AddAsync(productEntity);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ProductDTO>(productEntity);
        }
        public async Task<ProductDTO> UpdateAsync(ProductDTO productDTO)
        {
            var existingProduct = await _unitOfWork.ProductRepository.GetByIdAsync(productDTO.ProductExternalId);
            if (existingProduct == null)
            {
                throw new Exception("This product is not registered"); //TODO MELHORAR EXCEÇÃO
            }

            //await Validate(productDTO)

            _mapper.Map<ProductDTO, Product>(productDTO, existingProduct);
            var utcDate = DateTime.UtcNow;
            existingProduct.UpdateDate = utcDate;
            existingProduct.UpdateUserId = 1; // TODO USER ID

            await _unitOfWork.ProductRepository.UpdateAsync(existingProduct);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ProductDTO>(existingProduct);
        }

        public async Task<ProductDTO> DeleteAsync(Guid id)
        {
            var existingProduct = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                throw new Exception("Não existe este produto na DB"); //TODO MELHORAR EXCEÇÃO
            }

            //await Validate(productDTO)

            existingProduct.Deleted = true;
            var utcDate = DateTime.UtcNow;
            existingProduct.UpdateDate = utcDate;
            existingProduct.UpdateUserId = 1; // TODO USER ID

            await _unitOfWork.ProductRepository.UpdateAsync(existingProduct);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ProductDTO>(existingProduct);
        }


        private async Task Validate(ProductDTO product)
        {

        }

    }
}
