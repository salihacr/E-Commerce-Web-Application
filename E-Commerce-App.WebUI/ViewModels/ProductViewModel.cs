using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Shared.DTOs;
using System.Collections.Generic;

namespace E_Commerce_App.WebUI.ViewModels
{
    public class ProductViewModel
    {
        public ProductDto ProductDto { get; set; }
        public int[] categoryIds { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
        public IEnumerable<ProductCategoryDto> SelectedCategories { get; set; }
        public IEnumerable<ImageDto> Images { get; set; }
        // TODO comments tablosu eklenecek
        public IEnumerable<ColorDto> Colors { get; set; }
        public IEnumerable<ColorDto> SelectedColors { get; set; }
        public List<RatingDto> Ratings { get; set; }
    }
}
