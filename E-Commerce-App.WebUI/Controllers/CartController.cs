using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared;
using E_Commerce_App.WebUI.Helpers;
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
            var model = await CartHelper.GetProductsFromCart(_cartService, _userManager, User);
            return View(model);
        }
        [Route("/GetCartItems")]
        public async Task<IActionResult> GetCartItems()
        {
            var model = await CartHelper.GetProductsFromCart(_cartService, _userManager, User);
            return Json(new { data = model });
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(string productId, string color, int quantity, double price)
        {
            var userId = _userManager.GetUserId(User);
            await _cartService.AddToCart(userId, productId, quantity, price, color);

            return Json(new { success = true, message = "Ürün sepete eklendi." });
        }

        [HttpPost]
        [Route("/RemoveFromCart/{productId}")]
        public async Task<IActionResult> DeleteFromCart(string productId)
        {
            var userId = _userManager.GetUserId(User);
            await _cartService.DeleteProductFromCart(userId, productId);

            return Json(new
            {
                success = true,
                message = Messages.JSON_REMOVE_MESSAGE("Ürün"),
                data = await CartHelper.GetProductsFromCart(_cartService, _userManager, User)
            });
        }
        private async Task ResetCart(int cartId)
        {
            await _cartService.ResetCart(cartId);
        }
    }
}
