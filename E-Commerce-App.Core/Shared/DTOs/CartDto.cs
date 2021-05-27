using System.Collections.Generic;

namespace E_Commerce_App.Core.Shared.DTOs
{

    public class CartDto : BaseDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public List<CartItemDto> CartItems { get; set; }
    }
}
