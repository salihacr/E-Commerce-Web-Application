using AutoMapper;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared.DTOs;
using E_Commerce_App.WebUI.Identity;
using E_Commerce_App.WebUI.ViewModels;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            return View();
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
                        Price = (double)i.Product.Price,
                        ImageUrl = i.Product.MainImage,
                        Quantity = i.Quantity
                    }).ToList()
                };


                var payment = PaymentProcess(orderModel);

                if (payment.Status == "success")
                {
                    await SaveOrder(orderModel, payment, userId);
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


        private async Task SaveOrder(OrderViewModel orderModel, Payment payment, string userId)
        {
            var order = new OrderDto();

            order.OrderNumber = new Random().Next(1111111, 9999999) + "__" + new Guid() + "";
            order.OrderState = E_Commerce_App.Core.Entities.EnumOrderState.Paid;
            order.PaymentType = E_Commerce_App.Core.Entities.EnumPaymentType.CreditCard;
            order.PaymentId = payment.PaymentId;
            order.ConversationId = payment.ConversationId;
            order.OrderDate = DateTime.Now;
            order.CreationDate = DateTime.Now;
            order.FirstName = orderModel.FirstName;
            order.LastName = orderModel.LastName;
            order.UserId = userId;
            order.Phone = orderModel.Phone;
            order.Email = orderModel.Email;
            order.City = orderModel.City;
            order.District = orderModel.District;
            order.Address = orderModel.Address;
            order.Note = orderModel.Note;

            order.OrderItems = new List<Core.Entities.OrderItem>();
            var orderTotalPrice = 0d;
            foreach (var item in orderModel.CartViewModel.CartItems)
            {
                var orderItem = new Core.Entities.OrderItem()
                {
                    Price = item.Price,
                    Quantity = item.Quantity,
                    ProductId = item.ProductId
                };
                order.OrderItems.Add(orderItem);
                orderTotalPrice += item.Price;
            }
            order.TotalPrice = orderTotalPrice;

            await _orderService.AddAsync(_mapper.Map<OrderDto, Core.Entities.Order>(order));


        }
        private Payment PaymentProcess(OrderViewModel orderModel)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-8D9whfnmFquQoGkeKnFcpxi3j193JNIk";
            options.SecretKey = "sandbox-kiykvNKVqWRw4tzwvD1z8m4QkjbfoTyX";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";


            CreatePaymentRequest request = new CreatePaymentRequest();

            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(1111111, 9999999) + "__" + new Guid() + "";
            request.Price = orderModel.CartViewModel.GetTotalPrice() + "";
            request.PaidPrice = orderModel.CartViewModel.GetTotalPrice() + "";
            request.Currency = Currency.TRY + "";
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB + "";
            request.PaymentGroup = PaymentGroup.PRODUCT + "";

            PaymentCard paymentCard = new PaymentCard
            {
                CardHolderName = orderModel.CardName,
                CardNumber = orderModel.CardNumber,
                ExpireMonth = orderModel.ExpirationMonth,
                ExpireYear = orderModel.ExpirationYear,
                Cvc = orderModel.Cvc,
                RegisterCard = 0,
            };
            request.PaymentCard = paymentCard;

            //  paymentCard.CardNumber = "5528790000000008";
            // paymentCard.ExpireMonth = "12";
            // paymentCard.ExpireYear = "2030";
            // paymentCard.Cvc = "123";


            Buyer buyer = new Buyer
            {
                Id = "BY789",
                Name = orderModel.FirstName,
                Surname = orderModel.LastName,
                GsmNumber = "+905555555555",
                Email = "info@test.com",
                IdentityNumber = "74300864791",
                LastLoginDate = "2015-10-05 12:43:35",
                RegistrationDate = "2013-04-21 15:12:09",
                RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                Ip = "85.34.78.112",
                City = "Istanbul",
                Country = "Turkey",
                ZipCode = "34732"
            };

            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;
            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;

            foreach (var item in orderModel.CartViewModel.CartItems)
            {
                basketItem = new BasketItem();
                basketItem.Id = item.ProductId.ToString();
                basketItem.Name = item.Name;
                basketItem.Category1 = "Telefon";
                basketItem.Price = item.Price.ToString();
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItems.Add(basketItem);
            }
            request.BasketItems = basketItems;
            Payment payment = Payment.Create(request, options);
            return payment;

        }

    }
}
