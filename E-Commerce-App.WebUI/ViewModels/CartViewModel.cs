using System.Collections.Generic;
using System.Linq;

namespace E_Commerce_App.WebUI.ViewModels
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }

        public double GetTotalPrice() => CartItems.Sum(i => i.Price * i.Quantity);
    }
    public class CartItemViewModel
    {
        public int CartItemId { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
    }
}
