namespace ShoppingBasketKantarAPI.DTO
{
    public class BasketDTO
    {
        public decimal TotalValue { get; set; }
        public decimal SubtotalValue { get; set; }
        public decimal DiscountsValue { get; set; }
        public List<BasketProductDiscountDTO> ProductDiscounts { get; set; } = new List<BasketProductDiscountDTO>();
    }
}
