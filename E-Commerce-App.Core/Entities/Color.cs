using System.Collections.Generic;

namespace E_Commerce_App.Core.Entities
{
    public class Color : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<Product> Products { get; set; }
        public List<ProductColor> ProductColors { get; set; }
    }
}
