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
                new ProductCategory(){ ProductId="2", CategoryId=1 },
                new ProductCategory(){ ProductId="3", CategoryId=1 },
                new ProductCategory(){ ProductId="4", CategoryId=1 },
                new ProductCategory(){ ProductId="5", CategoryId=1 },
                new ProductCategory(){ ProductId="6", CategoryId=1 },
                new ProductCategory(){ ProductId="7", CategoryId=1 },
                new ProductCategory(){ ProductId="8", CategoryId=1 },
                new ProductCategory(){ ProductId="9", CategoryId=1 },
                new ProductCategory(){ ProductId="10", CategoryId=1 },
                new ProductCategory(){ ProductId="11", CategoryId=1 },
                new ProductCategory(){ ProductId="12", CategoryId=2 },
                new ProductCategory(){ ProductId="13", CategoryId=2 },
                new ProductCategory(){ ProductId="14", CategoryId=2 },
                new ProductCategory(){ ProductId="15", CategoryId=1 },
                new ProductCategory(){ ProductId="16", CategoryId=2 },
                new ProductCategory(){ ProductId="17", CategoryId=2 },
                new ProductCategory(){ ProductId="18", CategoryId=2 },
                new ProductCategory(){ ProductId="19", CategoryId=8 },
                new ProductCategory(){ ProductId="20", CategoryId=8 },
                new ProductCategory(){ ProductId="21", CategoryId=5 },
                new ProductCategory(){ ProductId="22", CategoryId=5 },
                new ProductCategory(){ ProductId="23", CategoryId=3 },
                new ProductCategory(){ ProductId="24", CategoryId=3 },
                new ProductCategory(){ ProductId="25", CategoryId=6 },
                new ProductCategory(){ ProductId="26", CategoryId=6 },
                new ProductCategory(){ ProductId="27", CategoryId=4 },
                new ProductCategory(){ ProductId="28", CategoryId=4 },
                new ProductCategory(){ ProductId="29", CategoryId=4 },
                new ProductCategory(){ ProductId="30", CategoryId=6 },
                new ProductCategory(){ ProductId="31", CategoryId=7 },
                new ProductCategory(){ ProductId="32", CategoryId=7 },
                new ProductCategory(){ ProductId="29", CategoryId=6 },
            };
            builder.HasData(productCategories);
        }
    }
}
