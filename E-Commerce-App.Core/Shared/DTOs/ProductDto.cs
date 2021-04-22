using E_Commerce_App.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Core.Shared.DTOs
{
    public class ProductDto : BaseDto
    {
        public string Id { get; set; }
        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string Name { get; set; }

        [Display(Name = "Ürün Bağlantısı")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string Url { get; set; }

        [Display(Name = "Ürün Fiyatı")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        [Range(1, 1000000, ErrorMessage = "1 ile 1000000 arasında değer girmelisiniz.")]
        public double? Price { get; set; }

        [Display(Name = "Ürün İndirim Oranı")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        [Range(1, 100, ErrorMessage = "1 ile 100 arasında değer girmelisiniz.")]
        public double? Discount { get; set; }

        [Display(Name = "Ürün Açıklaması")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string ShortDescription { get; set; }

        [Display(Name = "Ürün Detaylı Açıklaması")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string Description { get; set; }

        [Display(Name = "Ürün Anasayfada Görünsün mü ?")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public bool IsHome { get; set; }

        [Display(Name = "Ürün Kapak Resmi")]
        [Required(ErrorMessage = Messages.REQUIRED_INPUT)]
        public string MainImage { get; set; }
    }
}
