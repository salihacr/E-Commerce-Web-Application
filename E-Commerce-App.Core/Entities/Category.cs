using System.Collections;
using System.Collections.Generic;

namespace E_Commerce_App.Core.Entities
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}