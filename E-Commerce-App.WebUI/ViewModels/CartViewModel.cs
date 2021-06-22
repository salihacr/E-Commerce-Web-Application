using E_Commerce_App.Core.Shared.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerce_App.WebUI.ViewModels
{
    public class CommentViewModel
    {
        // orderın yorumunu güncelle
        // 
        public int OrderItemId { get; set; }
        public bool HasComment { get; set; }
        public RatingDto Rating { get; set; }
    }
    public class CartViewModel
    {
        public int CartId { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
        public int GetTotalPrice() => (int)CartItems.Sum(i => i.CartItemDto.Price * i.CartItemDto.Quantity);
    }
    public class CartItemViewModel
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public CartItemDto CartItemDto { get; set; }
    }
}
