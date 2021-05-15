using E_Commerce_App.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Core.Shared.DTOs
{
    public class ProductDto : BaseDto
    {
        public string Id { get; set; }
        [Display(Name = "Ad")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        [MinLength(2, ErrorMessage ="Ürün adı en az 2 harften oluşabilir.")]
        [MaxLength(50, ErrorMessage = "Ürün adı en fazla 50 harften oluşabilir.")]
        public string Name { get; set; }

        [Display(Name = "Bağlantı")]
        [MinLength(2, ErrorMessage = "Ürün bağlantısı en az 2 harften oluşabilir.")]
        [MaxLength(80, ErrorMessage = "Ürün bağlantısı en fazla 80 harften oluşabilir.")]
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
