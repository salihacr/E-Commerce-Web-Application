using AutoMapper;
using E_Commerce_App.Core.Services;
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
    public class OrderController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IService<Core.Entities.Order> _orderService;
        private readonly ICartService _cartService;

        public OrderController(
            IMapper mapper,
            UserManager<User> userManager,
            IService<Core.Entities.Order> orderService,
            ICartService cartService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _userManager = userManager;
            _cartService = cartService;
        }

        [Route("/my-orders")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var cart = await CartHelper.GetProductsFromCart(_cartService, _userManager, User);
            var model = new OrderViewModel() { CartViewModel = cart };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderViewModel orderModel)
        {

            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var cart = await _cartService.GetCartByUserId(userId);


                orderModel.CartViewModel = new CartViewModel()
                {
                    CartId = cart.Id,
                    CartItems = cart.CartItems.Select(i => new CartItemViewModel()
                    {
                        CartItemId = i.Id,
                        ProductId = i.ProductId,
                        Name = i.Product.Name,
                        Price = (double)i.Price,
                        ImageUrl = i.Product.MainImage,
                        Quantity = i.Quantity
                    }).ToList()
                };


                var payment = PaymentHelper.PaymentProcess(orderModel);

                if (payment.Status == "success")
                {
                    await PaymentHelper.SaveOrder(_mapper, _orderService, orderModel, payment, userId);
                    await _cartService.ResetCart(cart.Id);
                    return Json(new { message = "Sipariş başarılı." });
                }
                else
                {
                    return Json(new { message = "Sipariş hatası." });
                }
            }
            return View(orderModel);
        }

    }
}
