using E_Commerce_App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_App.Data.Configurations
{
    public class ProductColorConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
            .HasMany(p => p.Colors)
            .WithMany(p => p.Products)
            .UsingEntity<ProductColor>(
                j => j
                    .HasOne(pc => pc.Color)
                    .WithMany(pc => pc.ProductColors)
                    .HasForeignKey(pc => pc.ColorId),
                j => j
                    .HasOne(pc => pc.Product)
                    .WithMany(pc => pc.ProductColors)
                    .HasForeignKey(pc => pc.ProductId),
                j =>
                {
                    j.HasKey(t => new { t.ProductId, t.ColorId });
                });
        }
    }
}
