
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingBasketKantarAPI.Data.Entities
{
    [Table("Discount", Schema = Constants.Schema)]
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }
        [Required]
        public Guid DiscountExternalId { get; set; }
        [Required]
        public short DiscountType { get; set; }
        public int? ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }
        public string? DiscountCode { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Value { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
        public List<DiscountRule>? Rules { get; set; } = [];
    }
}
