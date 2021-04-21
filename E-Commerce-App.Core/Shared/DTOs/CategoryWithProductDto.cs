using System.Collections.Generic;

namespace E_Commerce_App.Core.Shared.DTOs
{
    public class CategoryWithProductDto : CategoryDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
