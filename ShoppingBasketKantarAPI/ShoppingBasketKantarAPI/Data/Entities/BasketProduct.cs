using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingBasketKantarAPI.Data.Entities
{
    [Table("BasketProduct", Schema = Constants.Schema)]
    [PrimaryKey(nameof(BasketId),nameof(ProductId))]
    public class BasketProduct
    {
        public int BasketId { get; set; }
        [ForeignKey(nameof(BasketId))]
        public Basket Basket { get; set; }

        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateUserId { get; set; }

    }
}
