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
