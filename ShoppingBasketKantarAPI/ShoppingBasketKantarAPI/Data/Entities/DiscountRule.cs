using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingBasketKantarAPI.Data.Entities
{
    [Table("DiscountRule", Schema = Constants.Schema)]
    public class DiscountRule
    {
        [Key]
        public int DiscountRuleId { get; set; }
        [Required]
        public short DiscountRuleType { get; set; }
        [Required]
        public int? DiscountId { get; set; }
        [ForeignKey(nameof(DiscountId))]
        public Discount? Discount { get; set; }
        public int? ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }
        public int? ProductQuantity { get; set; }
        public decimal? BasketTotalValue { get; set; }
    }
}
