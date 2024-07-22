namespace ShoppingBasketKantarAPI.DTO
{
    public class BasketProductDiscountDTO
    {
        public ProductDTO Product { get; set; }
        public List<DiscountDTO> Discounts { get; set; } = new List<DiscountDTO>();
    }
}
