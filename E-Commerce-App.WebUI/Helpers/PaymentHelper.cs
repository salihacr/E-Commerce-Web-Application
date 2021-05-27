using AutoMapper;
using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared.DTOs;
using E_Commerce_App.WebUI.ViewModels;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Helpers
{
    public static class PaymentHelper
    {
        public static Payment PaymentProcess(OrderViewModel orderModel)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-iY9pIGOmuPmlY7t0VuNqrQYo7qq81L21";
            options.SecretKey = "sandbox-kTp0CmWJZpsKnZiTIEYx3yR3lPj7L3dH";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";


            CreatePaymentRequest request = new CreatePaymentRequest();

            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(1111111, 9999999) + "__" + Guid.NewGuid().ToString();
            request.Price = orderModel.CartViewModel.GetTotalPrice().ToString();
            request.PaidPrice = orderModel.CartViewModel.GetTotalPrice().ToString();
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard
            {
                CardHolderName = orderModel.CardHolderName,
                CardNumber = "5528790000000008",//orderModel.CardNumber,
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
                Name = orderModel.OrderDto.FirstName,
                Surname = orderModel.OrderDto.LastName,
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
                basketItem.Price = (item.Price * item.Quantity).ToString();
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItems.Add(basketItem);
            }
            request.BasketItems = basketItems;
            Payment payment = Payment.Create(request, options);
            return payment;

        }
        public static async Task SaveOrder(IMapper _mapper, IService<Order> _orderService, OrderViewModel orderModel, Payment payment, string userId)
        {
            var order = new OrderDto();

            order.OrderNumber = new Random().Next(1111111, 9999999) + "__" + Guid.NewGuid().ToString();
            order.OrderState = Core.Entities.EnumOrderState.Paid;
            order.PaymentType = Core.Entities.EnumPaymentType.CreditCard;
            order.PaymentId = payment.PaymentId;
            order.ConversationId = payment.ConversationId;
            order.OrderDate = DateTime.Now;
            order.CreationDate = DateTime.Now;
            order.FirstName = orderModel.OrderDto.FirstName;
            order.LastName = orderModel.OrderDto.LastName;
            order.UserId = userId;
            order.Phone = orderModel.OrderDto.Phone;
            order.Email = orderModel.OrderDto.Email;
            order.City = orderModel.OrderDto.City;
            order.District = orderModel.OrderDto.District;
            order.Address = orderModel.OrderDto.Address;
            order.Note = orderModel.OrderDto.Note;

            order.OrderItems = new List<Core.Shared.DTOs.OrderItemDto>();
            var orderTotalPrice = 0d;
            foreach (var item in orderModel.CartViewModel.CartItems)
            {
                var orderItem = new OrderItemDto()
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
    }
}
