

namespace ShoppingBasketKantarAPI.DTO
{
    public class DiscountDTO
    {
        public Guid? DiscountExternalId { get; set; }
        public short DiscountType { get; set; }
        public Guid? ProductId { get; set; }
        public string? DiscountCode { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public List<DiscountRuleDTO>? Rules { get; set; } = [];
    }
}
