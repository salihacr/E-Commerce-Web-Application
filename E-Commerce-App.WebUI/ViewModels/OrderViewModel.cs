using E_Commerce_App.Core.Shared.DTOs;

namespace E_Commerce_App.WebUI.ViewModels
{
    public class OrderViewModel
    {
        public OrderDto OrderDto { get; set; }
        public CartViewModel CartViewModel { get; set; }
    }
}
