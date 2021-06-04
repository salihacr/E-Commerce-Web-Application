using E_Commerce_App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace E_Commerce_App.Data.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            List<Category> categories = new List<Category>
            {
                new Category(){Id=1, Name="Telefon",Url="telefon", CreationDate=DateTime.Now, IsActive=true },
                new Category(){Id=2, Name="Bilgisayar",Url="bilgisayar", CreationDate=DateTime.Now, IsActive=true },
                new Category(){Id=3, Name="Tv, Ev Elektroniği",Url="tv-ev-elektronigi", CreationDate=DateTime.Now, IsActive=true },
                new Category(){Id=4, Name="Bilgisayar Parçaları",Url="bilgisayar-parcalari", CreationDate=DateTime.Now, IsActive=true },
                new Category(){Id=5, Name="Foto, Kamera",Url="foto-kamera", CreationDate=DateTime.Now, IsActive=true },
                new Category(){Id=6, Name="Aksesuar",Url="aksesuar", CreationDate=DateTime.Now, IsActive=true },
                new Category(){Id=7, Name="Oyun, Hobi",Url="oyun-hobi", CreationDate=DateTime.Now, IsActive=true },
                new Category(){Id=8, Name="Ev, Mutfak",Url="ev-mutfak", CreationDate=DateTime.Now, IsActive=true },
            };
            builder.HasData(categories);
        }
    }
}
