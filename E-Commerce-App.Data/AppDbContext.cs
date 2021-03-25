using E_Commerce_App.Core.Entities;
using E_Commerce_App.Data.Configurations;
using E_Commerce_App.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SALIH; Initial Catalog=my-e-commerce-db;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColorSeed());
            modelBuilder.ApplyConfiguration(new ProductSeed());
            modelBuilder.ApplyConfiguration(new CategorySeed());
            modelBuilder.ApplyConfiguration(new ProductCategorySeed());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
