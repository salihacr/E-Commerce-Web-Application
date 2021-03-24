using E_Commerce_App.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Core.Common.DTOs
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Bu alanın girilmesi zorunludur")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu alanın girilmesi zorunludur")]
        public string Url { get; set; }
        [Required(ErrorMessage = "Bu alanın girilmesi zorunludur")]
        [Range(1, 1000000, ErrorMessage = "1 ile 1000000 arasında değer girebilirsiniz")]
        public double? Price { get; set; }
        [Required(ErrorMessage = "Bu alanın girilmesi zorunludur")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Bu alanın girilmesi zorunludur")]
        public bool IsHome { get; set; }
        [Required(ErrorMessage = "Bu alanın girilmesi zorunludur")]
        public string MainImage { get; set; }

        // Product Category Relation
        public IEnumerable<Category> Categories { get; set; }

        // Product Image Relation
        public IEnumerable<Image> Images { get; set; }

        // Product Color Relation
        public IEnumerable<Color> Colors { get; set; }
    }
}
