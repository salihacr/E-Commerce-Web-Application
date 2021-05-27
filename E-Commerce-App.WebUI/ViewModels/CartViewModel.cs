using E_Commerce_App.Core.Shared.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerce_App.WebUI.ViewModels
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
        public double GetTotalPrice() => CartItems.Sum(i => i.CartItemDto.Price * i.CartItemDto.Quantity);
    }
    public class CartItemViewModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public CartItemDto CartItemDto { get; set; }
    }
}
