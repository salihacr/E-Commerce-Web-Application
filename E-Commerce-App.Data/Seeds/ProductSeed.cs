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
                new Product(){Id="1", Name="Ürün 1", CreationDate=DateTime.Now,
                    Description="aciklama 1", Price=1000, Discount=5,
                    Url="product1", IsHome=true, MainImage="none", ShortDescription="lorem ipsum dat color...", IsActive=true,
                },
                new Product(){Id="2", Name="Ürün 2", CreationDate=DateTime.Now,
                    Description="aciklama 2", Price=1200, Discount=5,
                    Url="product2", IsHome=true, MainImage="none", ShortDescription="lorem ipsum dat color...", IsActive=true,
                },
                new Product(){Id="3", Name="Ürün 3", CreationDate=DateTime.Now,
                    Description="aciklama 3", Price=1300, Discount=5,
                    Url="product3", IsHome=true, MainImage="none", ShortDescription="lorem ipsum dat color...", IsActive=true,
                },
                new Product(){Id="4", Name="Ürün 4", CreationDate=DateTime.Now,
                    Description="aciklama 4", Price=1400, Discount=5,
                    Url="product4", IsHome=true, MainImage="none", ShortDescription="lorem ipsum dat color...", IsActive=true,
                },
                new Product(){Id="5", Name="Ürün 5", CreationDate=DateTime.Now,
                    Description="aciklama 5", Price=1500, Discount=10,
                    Url="product5", IsHome=true, MainImage="none", ShortDescription="lorem ipsum dat color...", IsActive=true,
                },
                new Product(){Id="6", Name="Ürün 6", CreationDate=DateTime.Now,
                    Description="aciklama 6", Price=2000, Discount=20,
                    Url="product6", IsHome=true, MainImage="none", ShortDescription="lorem ipsum dat color...", IsActive=true,
                },
            };
            builder.HasData(products);
        }
    }
}
