using E_Commerce_App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_App.Data.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
            .HasMany(p => p.Categories)
            .WithMany(p => p.Products)
            .UsingEntity<ProductCategory>(
                j => j
                    .HasOne(pc => pc.Category)
                    .WithMany(pc => pc.ProductCategories)
                    .HasForeignKey(pc => pc.CategoryId),
                j => j
                    .HasOne(pc => pc.Product)
                    .WithMany(pc => pc.ProductCategories)
                    .HasForeignKey(pc => pc.ProductId),
                j =>
                {
                    j.HasKey(t => new { t.ProductId, t.CategoryId });
                });
        }
    }
}
