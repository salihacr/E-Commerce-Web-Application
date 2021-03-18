using System.Collections.Generic;

namespace E_Commerce_App.Core.Entities
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }
        public bool IsHome { get; set; }
        public string MainImage { get; set; }

        // Product Category Relation
        public IEnumerable<Category> Categories { get; set; }

        // Product Image Relation
        public IEnumerable<Image> Images { get; set; }

        // Product Color Relation
        public IEnumerable<Color> Colors { get; set; }
    }
}
