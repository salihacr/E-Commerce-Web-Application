using E_Commerce_App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace E_Commerce_App.Data.Seeds
{
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
}
