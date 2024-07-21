using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingBasketKantarAPI.Data.Entities
{
    [Table("Product", Schema = Constants.Schema)]
    public class Product
    {
        [Key] 
        public int ProductId { get; set; }
        [Required]
        public Guid ProductExternalId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; } 
        public decimal Price { get; set; }
        public string? PhotoUrl { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }
    }
}
