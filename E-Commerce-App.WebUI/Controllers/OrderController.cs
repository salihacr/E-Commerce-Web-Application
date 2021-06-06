using AutoMapper;
using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared;
using E_Commerce_App.Core.Shared.DTOs;
using E_Commerce_App.WebUI.Helpers;
using E_Commerce_App.WebUI.Identity;
using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using static E_Commerce_App.WebUI.Helpers.UIHelper;

namespace E_Commerce_App.WebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IService<Rating> _ratingService;
        private readonly ICartService _cartService;
        private readonly IProductService _productService;

        public OrderController(
            IMapper mapper,
            UserManager<User> userManager,
            IOrderService orderService,
            ICartService cartService, IProductService productService, IService<Rating> ratingService, IOrderItemService orderItemService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _userManager = userManager;
            _cartService = cartService;
            _productService = productService;
            _ratingService = ratingService;
            _orderItemService = orderItemService;
        }

        [Route("/my-orders")]
        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(User);
            var orderItems = await _orderService.GetByUserIdAsync(userId);
            var orderDates = new List<string>();
            var ratings = new List<RatingDto>();
            var commented = new List<string>();
            var i = 0;
            foreach (var item in orderItems)
            {
                var date = item.Order.OrderDate.ToString("dd MMMM yyyy | HH:mm", CultureInfo.CreateSpecificCulture("tr"));
                orderDates.Add(date);
                var rating = await _ratingService.SingleOrDefaultAsync(p => p.OrderItemId == item.Id);
                if (rating == null) ratings.Add(new RatingDto());
                else ratings.Add(_mapper.Map<RatingDto>(rating));

                if (ratings.ElementAt(i).ProductId == item.ProductId) commented.Add("commented");
                else commented.Add("not-commented");
                i++;
            }
            var model = new UserOrderViewModel()
            {
                OrderItems = _mapper.Map<List<OrderItemDto>>(orderItems),
                OrderDates = orderDates,
                Ratings = ratings,
                AlreadyCommented = commented
            };

            return View(model);
        }


        [NoDirectAccess]
        public async Task<IActionResult> CommentAddOrEdit(int orderItemId, int id = 0)
        {
            var rating = await _ratingService.GetByIdAsync(id);
            if (id == 0 && rating == null)
                return View(new CommentViewModel() { Rating = new RatingDto { Id = 0 } });
            else
            {
                var orderItem = await _orderItemService.GetByIdAsync(orderItemId);
                var model = new CommentViewModel() { Rating = _mapper.Map<RatingDto>(rating), HasComment = orderItem.HasComment, OrderItemId = orderItem.Id };

                return View(model);

            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CommentAddOrEdit([FromForm] CommentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var orderItem = await _orderItemService.SingleOrDefaultAsync(p => p.Id == model.OrderItemId);
                    model.Rating.ProductId = orderItem.ProductId;
                    model.Rating.OrderItemId = orderItem.Id;
                    // orderitem ın yorum yapıldı durumunu güncelle  => entitystate
                    await _orderItemService.AddComment(model.OrderItemId);
                    if (model.Rating.Id == 0)
                    {
                        model.Rating.CreationDate = DateTime.Now;
                        await _ratingService.AddAsync(_mapper.Map<Rating>(model.Rating));
                    }
                    else
                    {
                        model.Rating.DateOfUpdate = DateTime.Now;
                        _ratingService.Update(_mapper.Map<Rating>(model.Rating));
                    }
                    return Json(new { isValid = true, success = true, message = Messages.JSON_CREATE_MESSAGE("Değerlendirme"), redirectUrl = "/my-orders" });
                }
                return Json(new { isValid = false, success = false, message = Messages.JSON_CREATE_MESSAGE("Değerlendirme", false), redirectUrl = "/my-orders" });
            }
            catch (Exception)
            {
                return Json(new { isValid = false, success = false, message = Messages.JSON_CREATE_MESSAGE("Değerlendirme", false), redirectUrl = "/my-orders" });
            }
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
