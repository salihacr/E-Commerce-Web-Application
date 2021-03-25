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
                new Product(){Id=1, Name="Ürün 1", CreationDate=DateTime.Now,
                    Description="aciklama 1", Price=11,
                    Url="product1", IsHome=true, MainImage="none"
                },
                new Product(){Id=2, Name="Ürün 2", CreationDate=DateTime.Now,
                    Description="aciklama 2", Price=12,
                    Url="product2", IsHome=true, MainImage="none"
                },
                new Product(){Id=3, Name="Ürün 3", CreationDate=DateTime.Now,
                    Description="aciklama 3", Price=13,
                    Url="product3", IsHome=true, MainImage="none"
                },
                new Product(){Id=4, Name="Ürün 4", CreationDate=DateTime.Now,
                    Description="aciklama 4", Price=14,
                    Url="product4", IsHome=true, MainImage="none"
                },
                new Product(){Id=5, Name="Ürün 5", CreationDate=DateTime.Now,
                    Description="aciklama 5", Price=15,
                    Url="product5", IsHome=true, MainImage="none"
                },
                new Product(){Id=6, Name="Ürün 6", CreationDate=DateTime.Now,
                    Description="aciklama 6", Price=16,
                    Url="product6", IsHome=true, MainImage="none"
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
                new Category(){Id=1, Name="Telefon" },
                new Category(){Id=2, Name="Bilgisayar" },
                new Category(){Id=3, Name="Tv, Ev Elektroniği" },
                new Category(){Id=4, Name="Bilgisayar Parçaları" },
                new Category(){Id=5, Name="Foto, Kamera" },
                new Category(){Id=6, Name="Aksesuar" },
                new Category(){Id=7, Name="Oyun, Hobi" },
                new Category(){Id=8, Name="Ev, Mutfak" },
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
                new Color(){Id=1, Name="Beyaz", Code="#f9f6ef" },
                new Color(){Id=2, Name="Siyah", Code="#202020" },
                new Color(){Id=3, Name="Kırmızı", Code="#ba0c2f" },
                new Color(){Id=4, Name="Sarı", Code="#FECB2E" },
                new Color(){Id=5, Name="Mavi", Code="#147EFB" },
                new Color(){Id=6, Name="Yeşil", Code="#53D769" },
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
                new ProductCategory(){ ProductId=6, CategoryId=4 },
            };
            builder.HasData(productCategories);
        }
    }
}
