using ShoppingBasketKantarAPI.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingBasketKantarAPI.DTO
{
    public class DiscountRuleDTO
    {
        public short DiscountRuleType { get; set; }
        public Guid? ProductExternalId { get; set; }
        public int? ProductQuantity { get; set; }
        public decimal? BasketTotalValue { get; set; }
    }
}
