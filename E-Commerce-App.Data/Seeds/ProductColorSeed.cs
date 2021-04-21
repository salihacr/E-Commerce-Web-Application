using E_Commerce_App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace E_Commerce_App.Data.Seeds
{
    public class ProductColorSeed : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            List<ProductColor> productColors = new List<ProductColor>
            {
                new ProductColor(){ ProductId="1", ColorId=1 },
                new ProductColor(){ ProductId="1", ColorId=2 },
                new ProductColor(){ ProductId="1", ColorId=3 },
                new ProductColor(){ ProductId="2", ColorId=1 },
                new ProductColor(){ ProductId="2", ColorId=2 },
                new ProductColor(){ ProductId="3", ColorId=1 },
                new ProductColor(){ ProductId="4", ColorId=2 },
                new ProductColor(){ ProductId="5", ColorId=3 },
                new ProductColor(){ ProductId="6", ColorId=4 },
            };
            builder.HasData(productColors);
        }
    }
}
