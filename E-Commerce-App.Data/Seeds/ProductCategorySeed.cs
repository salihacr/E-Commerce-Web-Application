using E_Commerce_App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace E_Commerce_App.Data.Seeds
{
    public class ProductCategorySeed : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            List<ProductCategory> productCategories = new List<ProductCategory>
            {
                new ProductCategory(){ ProductId="1", CategoryId=1 },
                new ProductCategory(){ ProductId="1", CategoryId=2 },
                new ProductCategory(){ ProductId="1", CategoryId=3 },
                new ProductCategory(){ ProductId="2", CategoryId=1 },
                new ProductCategory(){ ProductId="2", CategoryId=2 },
                new ProductCategory(){ ProductId="3", CategoryId=1 },
                new ProductCategory(){ ProductId="4", CategoryId=2 },
                new ProductCategory(){ ProductId="5", CategoryId=3 },
                new ProductCategory(){ ProductId="6", CategoryId=4 },
            };
            builder.HasData(productCategories);
        }
    }
}
