using Microsoft.EntityFrameworkCore;
using ShoppingBasketKantarAPI.Data.Entities;

namespace ShoppingBasketKantarAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Discount> Discounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Constants.Schema);
            OnDeleteNoAction(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Price).HasColumnType("decimal(19,4)");
            });


            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(p => p.Value).HasColumnType("decimal(19,4)");
            });

            modelBuilder.Entity<DiscountRule>(entity =>
            {
                entity.Property(p => p.BasketTotalValue).HasColumnType("decimal(19,4)");
            });


            Hist(modelBuilder);
            Seed(modelBuilder);
        }

        private static void OnDeleteNoAction(ModelBuilder modelBuilder)
        {
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>
            {
                new() { ProductId = 1, ProductExternalId = Guid.NewGuid(), Name = "Apple", Description = "Apple", Price = 1, PhotoUrl = "https://media.self.com/photos/5b6b0b0cbb7f036f7f5cbcfa/4:3/w_4116,h_3087,c_limit/apples.jpg", Deleted = false,CreateDate= DateTime.UtcNow, CreateUserId = 1 },
                new() { ProductId = 2, ProductExternalId = Guid.NewGuid(), Name = "Soup", Description = "Soup", Price = 0.65m, PhotoUrl = "https://www.inspiredtaste.net/wp-content/uploads/2022/01/Creamy-Chicken-Noodle-Soup-3-1200-1200x800.jpg", Deleted = false,CreateDate= DateTime.UtcNow, CreateUserId = 1 },
                new() { ProductId = 3, ProductExternalId = Guid.NewGuid(), Name = "Bread", Description = "Loaf of bread", Price = 0.8m, PhotoUrl = "https://www.allrecipes.com/thmb/CjzJwg2pACUzGODdxJL1BJDRx9Y=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/6788-amish-white-bread-DDMFS-4x3-6faa1e552bdb4f6eabdd7791e59b3c84.jpg", Deleted = false,CreateDate= DateTime.UtcNow, CreateUserId = 1 },
                new() { ProductId = 4, ProductExternalId = Guid.NewGuid(), Name = "Milk", Description = "Milk", Price = 1.3m, PhotoUrl = "https://www.thefrozengarden.com/cdn/shop/articles/benefits-of-whole-milk-benefits-of-drinking-whole-milk-blog-frozen-garden_e991a019-eebb-455b-99b2-96041863f037.webp?v=1706546802", Deleted = false,CreateDate= DateTime.UtcNow, CreateUserId = 1 },
                new() { ProductId = 5, ProductExternalId = Guid.NewGuid(), Name = "Watermelon", Description = "Watermelon", Price = 0.79m, PhotoUrl = "https://static.toiimg.com/thumb/msid-109165284,width-1280,height-720,resizemode-4/109165284.jpg", Deleted = false,CreateDate= DateTime.UtcNow, CreateUserId = 1 },
                new() { ProductId = 6, ProductExternalId = Guid.NewGuid(), Name = "Ben & Jerry's Ice Cream", Description = "Ice cream", Price =4.39m, PhotoUrl = "https://i.ytimg.com/vi/PDHjQBQ-GDg/maxresdefault.jpg", Deleted = false,CreateDate= DateTime.UtcNow, CreateUserId = 1 },
                new() { ProductId = 7, ProductExternalId = Guid.NewGuid(), Name = "Orange", Description = "Orange", Price = 0.99m, PhotoUrl = "https://www.allrecipes.com/thmb/y_uvjwXWAuD6T0RxaS19jFvZyFU=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/GettyImages-1205638014-2000-d0fbf9170f2d43eeb046f56eec65319c.jpg", Deleted = false,CreateDate= DateTime.UtcNow, CreateUserId = 1 },
                new() { ProductId = 8, ProductExternalId = Guid.NewGuid(), Name = "Redbull", Description = "Redbull can", Price = 1.5m, PhotoUrl = "https://assets.bwbx.io/images/users/iqjWHBFdfxIU/iIoVzYblObRg/v1/-1x-1.jpg", Deleted = false,CreateDate= DateTime.UtcNow, CreateUserId = 1 },
                new() { ProductId = 9, ProductExternalId = Guid.NewGuid(), Name = "Oreo", Description = "Oreo", Price = 2.39m, PhotoUrl = "https://www.allrecipes.com/thmb/sjK0dcDQO7aQ4kQ1ixfcvZNK7mw=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/ar-oreo-adobe-2x1-3-41049067131d46cda449b40f5b3f6106.jpg", Deleted = false,CreateDate= DateTime.UtcNow, CreateUserId = 1 },

            });

            modelBuilder.Entity<Discount>().HasData(new List<Discount>
            {
                new(){ DiscountId = 1, DiscountExternalId = Guid.NewGuid(), DiscountType = 2, DiscountCode = "WELCOME10", Description= "Welcome discount - 2€", Value=2, CreateDate = DateTime.UtcNow, CreateUserId = 1 },
                new(){ DiscountId = 2, DiscountExternalId = Guid.NewGuid(), DiscountType = 1, ProductId=3, Description= "2 tins of soup and get a loaf of bread for half price", Value=0.5m, CreateDate = DateTime.UtcNow, CreateUserId = 1 },
                new(){ DiscountId = 3, DiscountExternalId = Guid.NewGuid(), DiscountType = 1, ProductId=1, Description= " 10% discount off their normal price this week", Value=0.1m, CreateDate = DateTime.UtcNow, CreateUserId = 1 },
            });

            modelBuilder.Entity<DiscountRule>().HasData(new List<DiscountRule>
            {
                new(){DiscountRuleId = 1, DiscountRuleType = 1, DiscountId=2, ProductId = 2, ProductQuantity = 2}
            });
        }

        private static void Hist(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("Product", Constants.Schema, p => p.IsTemporal());
            modelBuilder.Entity<DiscountRule>()
                .ToTable("DiscountRule", Constants.Schema, p => p.IsTemporal());
            modelBuilder.Entity<Discount>()
                .ToTable("Discount", Constants.Schema, p => p.IsTemporal());
        }
    }
}
