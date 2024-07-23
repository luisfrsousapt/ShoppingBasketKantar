using AutoMapper;
using ShoppingBasketKantarAPI.Data.Entities;
using ShoppingBasketKantarAPI.Data.Repositories.Interfaces;
using ShoppingBasketKantarAPI.DTO;
using ShoppingBasketKantarAPI.Mapper;
using ShoppingBasketKantarAPI.Services.Interfaces;

namespace ShoppingBasketKantarAPI.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiscountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<DiscountDTO>> GetAllAsync()
        {
            var discounts = await _unitOfWork.DiscountRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DiscountDTO>>(discounts);
        }

        public async Task<DiscountDTO> GetByProductAsync(Guid productExternalId)
        {

            var product = await _unitOfWork.ProductRepository.GetByIdAsync(productExternalId);
            if(product == null)
            {
                throw new Exception("This product is not registered"); //TODO melhorar exceção
            }

            var discount = await _unitOfWork.DiscountRepository.GetByProductAsync(product.ProductId);
            return _mapper.Map<DiscountDTO>(discount);
        }

        public async Task<DiscountDTO> GetByDiscountCodeAsync(string code)
        {
            var discount = await _unitOfWork.DiscountRepository.GetByDiscountCodeAsync(code);
            if (discount == null)
            {
                throw new Exception("This discount is not registered"); //TODO melhorar exceção
            }
            return _mapper.Map<DiscountDTO>(discount);
        }

        public async Task<DiscountDTO> CreateAsync(DiscountDTO discountDTO)
        {
            // await Validate(discountDTO);
     
            Product? product = null;

            if (discountDTO.ProductId.HasValue)
            {
                product = await _unitOfWork.ProductRepository.GetByIdAsync(discountDTO.ProductId.Value);
                if (product == null)
                {
                    throw new Exception("This product is not registered");
                }
            }
            var discountEntity = _mapper.Map<Discount>(discountDTO);
            discountEntity.DiscountExternalId = Guid.NewGuid();
            var utcDate = DateTime.UtcNow;
            discountEntity.CreateDate = utcDate;
            discountEntity.CreateUserId = 1; // TODO USER ID
            discountEntity.ProductId = product?.ProductId;

            discountEntity.Rules = await MapDiscountRulesToEntity(discountDTO.Rules);


            await _unitOfWork.DiscountRepository.AddAsync(discountEntity);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<DiscountDTO>(discountEntity);
        }

        

        public async Task<DiscountDTO> UpdateAsync(DiscountDTO discountDTO)
        {
            if (!discountDTO.DiscountExternalId.HasValue)
            {
                throw new Exception("This discount is not registered");
            }
            var existingDiscount = await _unitOfWork.DiscountRepository.GetByDiscountId(discountDTO.DiscountExternalId.Value);
            if (existingDiscount == null)
            {
                throw new Exception("This discount is not registered"); //TODO MELHORAR EXCEÇÃO
            }

            //await Validate(productDTO)

            _mapper.Map<DiscountDTO, Discount>(discountDTO, existingDiscount);
            var utcDate = DateTime.UtcNow;
            existingDiscount.UpdateDate = utcDate;
            existingDiscount.UpdateUserId = 1; // TODO USER ID

            if(discountDTO.Rules != null)
            {
                existingDiscount.Rules.Clear();
                existingDiscount.Rules = await MapDiscountRulesToEntity(discountDTO.Rules);
            }
            

            await _unitOfWork.DiscountRepository.UpdateAsync(existingDiscount);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<DiscountDTO>(existingDiscount);
        }


        public async Task<DiscountDTO> DeleteAsync(Guid id)
        {
            var existingDiscount = await _unitOfWork.DiscountRepository.GetByDiscountId(id);
            if (existingDiscount == null)
            {
                throw new Exception("This discount is not registered"); //TODO MELHORAR EXCEÇÃO
            }

            //await Validate(productDTO)

            existingDiscount.Deleted = true;
            var utcDate = DateTime.UtcNow;
            existingDiscount.UpdateDate = utcDate;
            existingDiscount.UpdateUserId = 1; // TODO USER ID

            await _unitOfWork.DiscountRepository.UpdateAsync(existingDiscount);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<DiscountDTO>(existingDiscount);
        }

        private async Task<List<DiscountRule>> MapDiscountRulesToEntity(List<DiscountRuleDTO>? rules)
        {

            List<DiscountRule> entityRules = new List<DiscountRule>();
            if (rules != null && rules.Count() > 0)
            {
                foreach (var rule in rules)
                {
                    var ruleEntity = _mapper.Map<DiscountRule>(rule);
                    if (rule.ProductExternalId.HasValue)
                    {
                        var productRule = await _unitOfWork.ProductRepository.GetByIdAsync(rule.ProductExternalId.Value);
                        if (productRule != null)
                        {
                            ruleEntity.ProductId = productRule.ProductId;
                        }
                    }
                    entityRules.Add(ruleEntity);
                }
            }
            return entityRules;
        }

        private async Task Validate(DiscountDTO discountDTO)
        {

        }


    }
}
