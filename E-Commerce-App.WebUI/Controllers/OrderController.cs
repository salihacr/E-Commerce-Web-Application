using AutoMapper;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared.DTOs;
using E_Commerce_App.WebUI.Helpers;
using E_Commerce_App.WebUI.Identity;
using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;

        public OrderController(
            IMapper mapper,
            UserManager<User> userManager,
            IOrderService orderService,
            ICartService cartService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _userManager = userManager;
            _cartService = cartService;
        }

        [Route("/my-orders")]
        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(User);
            var orderItems = await _orderService.GetByUserIdAsync(userId);
            var orderDates = new List<string>();
            foreach (var item in orderItems)
            {
                var date = item.Order.OrderDate.ToString("dd MMMM yyyy | HH:mm", CultureInfo.CreateSpecificCulture("tr"));
                orderDates.Add(date);
            }
            var model = new UserOrderViewModel() { OrderItems = _mapper.Map<List<OrderItemDto>>(orderItems), OrderDates = orderDates };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var cart = await CartHelper.GetProductsFromCart(_cartService, _userManager, User);
            ViewData["CartItemLength"] = cart.CartItems.Count;
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
                        CartItemDto = new Core.Shared.DTOs.CartItemDto
                        {
                            Id = i.Id,
                            ProductId = i.ProductId,
                            Price = (double)i.Price,
                            Quantity = i.Quantity,
                            Color = i.Color
                        },
                        Name = i.Product.Name,
                        ImageUrl = i.Product.MainImage,
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
