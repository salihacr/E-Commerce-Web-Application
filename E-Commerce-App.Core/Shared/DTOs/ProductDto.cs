using E_Commerce_App.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Core.Shared.DTOs
{
    public class ColorDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
    public class ImageDto : BaseDto
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string ProductId { get; set; }
    }
    public class ProductColorDto : BaseDto
    {
        public int ColorId { get; set; }
        public string ProductId { get; set; }
    }
    public class ProductCategoryDto : BaseDto
    {
        public int CategoryId { get; set; }
        public string ProductId { get; set; }
    }
    public class ProductDto : BaseDto
    {
        public string Id { get; set; }
        [Display(Name = "Ad")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string Name { get; set; }

        [Display(Name = "Bağlantı")]
        public string Url { get; set; }

        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        [Range(1, 1000000, ErrorMessage = "1 ile 1000000 arasında değer girmelisiniz.")]
        public double? Price { get; set; }

        [Display(Name = "İndirim Oranı")]
        [Range(1, 100, ErrorMessage = "1 ile 100 arasında değer girmelisiniz.")]
        public double? Discount { get; set; }

        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string ShortDescription { get; set; }

        [Display(Name = "Detaylı Açıklama")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string Description { get; set; }

        [Display(Name = "Ürün Anasayfada Görünsün mü ?")]
        public bool IsHome { get; set; }

        [Display(Name = "Kapak Resmi")]
        public string MainImage { get; set; }


        public ICollection<ImageDto> Images { get; set; }
        public ICollection<ProductColorDto> ProductColors { get; set; }
        public ICollection<ProductCategoryDto> ProductCategories { get; set; }
    }
}
