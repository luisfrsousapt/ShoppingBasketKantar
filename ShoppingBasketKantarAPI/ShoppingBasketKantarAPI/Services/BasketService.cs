using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ShoppingBasketKantarAPI.Data.Entities;
using ShoppingBasketKantarAPI.Data.Repositories.Interfaces;
using ShoppingBasketKantarAPI.DTO;
using ShoppingBasketKantarAPI.Enums;
using ShoppingBasketKantarAPI.Services.Interfaces;

namespace ShoppingBasketKantarAPI.Services
{
    public class BasketService : IBasketService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IDiscountService _discountService;

        public BasketService(IUnitOfWork unitOfWork, IMapper mapper, IProductService productService, IDiscountService discountService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productService = productService;
            _discountService = discountService;
        }


        public async Task<BasketDTO> GetBasketAsync(List<BasketProductDTO> productsInBasket)
        {
            if (productsInBasket == null || !productsInBasket.Any())
            {
                throw new Exception("Basket can't be empty");
            }

            var productsExternalIds = productsInBasket.Select(p => p.ProductId).ToList();
            var products = await GetProductsByIdsAsync(productsExternalIds);
            var productIds = products.Select(p => p.ProductId).ToList();
            var discounts = await GetDiscountsByProductIdsAsync(productIds);

            return CreateBasketDTO(products, discounts, productsInBasket);
        }

        private BasketDTO CreateBasketDTO(List<Product> products, List<Discount> discounts, List<BasketProductDTO> productsInBasket)
        {
            var basket = new BasketDTO
            {
                SubtotalValue = productsInBasket.Sum(p => p.ProductQuantity * products.First(prod => prod.ProductExternalId == p.ProductId).Price)
            };

            foreach (var product in products)
            {
                var productDiscounts = discounts
                    .Where(d => d.ProductId.HasValue && d.ProductId.Value == product.ProductId)
                    .ToList();
                var productDiscountDTOs = productDiscounts.Select(d => _mapper.Map<DiscountDTO>(d)).ToList();

                var productDiscount = new BasketProductDiscountDTO
                {
                    Product = _mapper.Map<ProductDTO>(product),
                    Discounts = productDiscountDTOs
                };
                basket.ProductDiscounts.Add(productDiscount);

                basket.DiscountsValue += CalculateDiscountValue(product, productDiscounts, products, basket.SubtotalValue, productsInBasket);
            }

            basket.TotalValue = basket.SubtotalValue - basket.DiscountsValue;

            return basket;
        }

        private decimal CalculateDiscountValue(Product product, List<Discount> productDiscounts, List<Product> products, decimal subTotal, List<BasketProductDTO> productQuantityBasket)
        {
            decimal totalDiscountValue = 0;
            var basketProduct = productQuantityBasket.FirstOrDefault(bp => bp.ProductId == product.ProductExternalId);

            foreach (var discount in productDiscounts)
            {


                if (ValidateDiscountRules(discount, products, subTotal, productQuantityBasket))
                {
                    if ((DiscountTypeEnum)discount.DiscountType == DiscountTypeEnum.Percentage)
                    {
                        totalDiscountValue += discount.Value * (product.Price * (basketProduct?.ProductQuantity ?? 1));
                    }

                    else if ((DiscountTypeEnum)discount.DiscountType == DiscountTypeEnum.FixedValue)
                    {
                        totalDiscountValue += discount.Value * (basketProduct?.ProductQuantity ?? 1);
                    }

                }
            }

            return totalDiscountValue;
        }

        private bool ValidateDiscountRules(Discount discount, List<Product> products, decimal subTotal, List<BasketProductDTO> productQuantityBasket)
        {
            if (discount.Rules == null || !discount.Rules.Any())
            {
                return true;
            }

            foreach (var discountRule in discount.Rules)
            {
                if ((DiscountRuleTypeEnum)discountRule.DiscountRuleType == DiscountRuleTypeEnum.Product)
                {
                    var basketProductEntity = products.FirstOrDefault(p => p.ProductId == discountRule.ProductId);

                    if (basketProductEntity != null)
                    {


                        var basketProduct = productQuantityBasket.FirstOrDefault(bp => bp.ProductId == basketProductEntity.ProductExternalId);
                        if (basketProduct != null && basketProduct.ProductQuantity >= discountRule.ProductQuantity)
                        {
                            return true;
                        }
                    }
                }
                else if ((DiscountRuleTypeEnum)discountRule.DiscountRuleType == DiscountRuleTypeEnum.Basket)
                {
                    if (subTotal >= discountRule.BasketTotalValue)
                    {
                        return true;
                 
                    }
                }
            }
            return false;
        }

        private async Task<List<Product>> GetProductsByIdsAsync(List<Guid> productsExternalIds)
        {
            return await _productService.GetProductsListByIdAsync(productsExternalIds);
        }

        private async Task<List<Discount>> GetDiscountsByProductIdsAsync(List<int> productIds)
        {
            return await _discountService.GetDiscountsByProductsList(productIds);
        }

    }
}
