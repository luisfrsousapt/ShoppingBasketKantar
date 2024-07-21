namespace ShoppingBasketKantarAPI.DTO
{
    public class ProductDTO
    {
        public Guid ProductExternalId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
