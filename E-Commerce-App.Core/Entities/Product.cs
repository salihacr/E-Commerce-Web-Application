using System.Collections.Generic;

namespace E_Commerce_App.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public double? Price { get; set; }
        public double? Discount { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool IsHome { get; set; }
        public string MainImage { get; set; }

        // Product Category Relation
        public ICollection<Category> Categories { get; set; }
        // n to n relationship
        public List<ProductCategory> ProductCategories { get; set; }

        // Product Color Relation
        public ICollection<Color> Colors { get; set; }
        // n to n relationship
        public ICollection<ProductColor> ProductColors { get; set; }

        // Product Image Relation
        public ICollection<Image> Images { get; set; }
    }
}
