using E_Commerce_App.Core.Entities;
using System.Collections.Generic;

namespace E_Commerce_App.WebUI.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public int[] categoryIds { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Image> Images { get; set; }
        // TODO comments tablosu eklenecek
        public IEnumerable<Color> Colors { get; set; }
    }
}
