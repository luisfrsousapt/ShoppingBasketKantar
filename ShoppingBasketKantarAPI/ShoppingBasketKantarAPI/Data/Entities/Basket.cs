using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingBasketKantarAPI.Data.Entities
{
    [Table("Basket", Schema = Constants.Schema)]
    public class Basket
    {
        [Key]
        public int BasketId { get; set; }
        [Required]
        public Guid BasketExternalId { get; set; }
        public Guid? UserAzureAdId { get; set; }
        public List<BasketProduct>? Products { get; set; } = [];
        public List<Discount>? Discounts { get; set; } = [];

        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
    }
}
