using AutoMapper;
using ShoppingBasketKantarAPI.Data.Entities;
using ShoppingBasketKantarAPI.DTO;

namespace ShoppingBasketKantarAPI.Mapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            MapProducts();
            MapDiscounts();
        }

        private void MapProducts()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
        private void MapDiscounts()
        {

            CreateMap<DiscountDTO, Discount>()
                .ForMember(dest => dest.DiscountId, opt => opt.Ignore())
                .ForMember(dest => dest.ProductId, opt => opt.Ignore())
                .ForMember(dest => dest.Rules,opt => opt.Ignore());

            CreateMap<Discount, DiscountDTO>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product != null ? src.Product.ProductExternalId : (Guid?)null));


            CreateMap<DiscountRule, DiscountRuleDTO>();
            CreateMap<DiscountRuleDTO, DiscountRule>();
        }
    }
}
