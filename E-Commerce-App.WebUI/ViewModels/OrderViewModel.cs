using E_Commerce_App.Core.Shared.DTOs;

namespace E_Commerce_App.WebUI.ViewModels
{
    public class OrderViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public string Email { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Cvc { get; set; }

        public OrderDto OrderDto { get; set; }
        public CartViewModel CartViewModel { get; set; }
    }
}
