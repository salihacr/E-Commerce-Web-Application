using E_Commerce_App.Core.Services;
using E_Commerce_App.WebUI.Identity;
using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Helpers
{
    public class CartHelper
    {
        public static async Task<CartViewModel> GetProductsFromCart(ICartService _cartService, UserManager<User> _userManager, System.Security.Claims.ClaimsPrincipal User)
        {
            var cart = await _cartService.GetCartByUserId(_userManager.GetUserId(User));
            var model = new CartViewModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemViewModel()
                {
                    CartItemDto = new Core.Shared.DTOs.CartItemDto
                    {
                        Id = i.Id,
                        ProductId = i.ProductId,
                        Price = (double)i.Price,
                        Quantity = i.Quantity
                    },
                    Name = i.Product.Name,
                    ImageUrl = i.Product.MainImage,
                }).ToList()
            };
            return model;
        }
    }
}
