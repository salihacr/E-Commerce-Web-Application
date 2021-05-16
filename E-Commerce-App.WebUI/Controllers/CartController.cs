using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared;
using E_Commerce_App.WebUI.Identity;
using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private ICartService _cartService;
        private UserManager<User> _userManager;

        public CartController(ICartService cartService, UserManager<User> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }
        [HttpGet]
        [Route("/cart")]
        public async Task<IActionResult> Index()
        {
            var model = await GetProductsFromCart();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(string productId, string color, int quantity)
        {
            var userId = _userManager.GetUserId(User);
            await _cartService.AddToCart(userId, productId, quantity);

            return Json(new { isValid = true, message = "Ürün sepete eklendi." });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFromCart(string productId)
        {
            var userId = _userManager.GetUserId(User);
            await _cartService.DeleteProductFromCart(userId, productId);

            return Json(new
            {
                isValid = true,
                message = Messages.JSON_REMOVE_MESSAGE("Ürün"),
                html = Helpers.UIHelper.RenderRazorViewToString(this, "_AllProducts", await GetProductsFromCart())
            });
        }

        private async Task<CartViewModel> GetProductsFromCart()
        {
            var cart = await _cartService.GetCartByUserId(_userManager.GetUserId(User));
            var model = new CartViewModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemViewModel()
                {
                    CartItemId = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Price = (double)i.Product.Price,
                    ImageUrl = i.Product.MainImage,
                    Quantity = i.Quantity

                }).ToList()
            };
            return model;
        }

        private async Task ResetCart(int cartId)
        {
            await _cartService.ResetCart(cartId);
        }
    }
}
