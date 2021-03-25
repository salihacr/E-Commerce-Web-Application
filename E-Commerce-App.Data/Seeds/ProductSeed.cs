using E_Commerce_App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace E_Commerce_App.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            List<Product> products = new List<Product>
            {
                new Product(){Id=1, Name="Product2", CreationDate=DateTime.Now,
                    Description="test desc1", Price=11,
                    Url="product1", IsHome=true, MainImage="none"
                },
                new Product(){Id=2, Name="Product2", CreationDate=DateTime.Now,
                    Description="test desc2", Price=12,
                    Url="product2", IsHome=true, MainImage="none"
                },
                new Product(){Id=3, Name="Product3", CreationDate=DateTime.Now,
                    Description="test desc3", Price=13,
                    Url="product3", IsHome=true, MainImage="none"
                },
                new Product(){Id=4, Name="Product3", CreationDate=DateTime.Now,
                    Description="test desc4", Price=13,
                    Url="product4", IsHome=true, MainImage="none"
                },
                new Product(){Id=5, Name="Product5", CreationDate=DateTime.Now,
                    Description="test desc5", Price=15,
                    Url="product5", IsHome=true, MainImage="none"
                },
            };
            builder.HasData(products);
        }
    }
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            List<Category> categories = new List<Category>
            {
                new Category(){Id=1, Name="Category1" },
                new Category(){Id=2, Name="Category2" },
                new Category(){Id=3, Name="Category3" },
            };
            builder.HasData(categories);
        }
    }
    public class ColorSeed : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            List<Color> colors = new List<Color>
            {
                new Color(){Id=1, Name="Black", Code="#111111" },
                new Color(){Id=2, Name="White", Code="#ffffff" },
                new Color(){Id=3, Name="Test", Code="#test" },
            };
            builder.HasData(colors);
        }
    }
    public class ProductCategorySeed : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            List<ProductCategory> productCategories = new List<ProductCategory>
            {
                new ProductCategory(){ ProductId=1, CategoryId=1 },
                new ProductCategory(){ ProductId=1, CategoryId=2 },
                new ProductCategory(){ ProductId=1, CategoryId=3 },
                new ProductCategory(){ ProductId=2, CategoryId=1 },
                new ProductCategory(){ ProductId=2, CategoryId=2 },
                new ProductCategory(){ ProductId=3, CategoryId=1 },
                new ProductCategory(){ ProductId=4, CategoryId=2 },
                new ProductCategory(){ ProductId=5, CategoryId=3 },
            };
            builder.HasData(productCategories);
        }
    }
}
