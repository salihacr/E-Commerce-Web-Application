using E_Commerce_App.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace E_Commerce_App.Data.Seeds
{
    public class CampaignSeed : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            List<Campaign> campaigns = new List<Campaign>
            {
                new Campaign(){Id=1, ImagePath="/images/iphone-kampanya.png", ImageAltTag="iphone kampanya", IsHome=true, CreationDate=DateTime.Now },
                new Campaign(){Id=2, ImagePath="/images/samsung-tv-kampanya.png", ImageAltTag="samsung tv kampanya", IsHome=true, CreationDate=DateTime.Now },
                new Campaign(){Id=3, ImagePath="/images/pc-kampanya.png", ImageAltTag="pc kampanya", IsHome=true, CreationDate=DateTime.Now },
            };
            builder.HasData(campaigns);
        }
    }
}
