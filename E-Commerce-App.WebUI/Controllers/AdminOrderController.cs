using AutoMapper;
using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.Shared.DTOs;
using E_Commerce_App.WebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("Admin/Order")]
    public class AdminOrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;

        public AdminOrderController(IMapper mapper, ICartService cartService, IOrderService orderService)
        {
            _mapper = mapper;
            _cartService = cartService;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await GetOrders());
        }
        [Route("{orderId}")]
        [HttpGet]
        public async Task<IActionResult> Detail(int orderId)
        {
            ViewData["OrderId"] = orderId;
            var order = await _orderService.GetOrderWithItems(orderId);
            var model = new OrderViewModel() { OrderDto = _mapper.Map<OrderDto>(order) };

            return View(model);
        }
        [Route("EditOrderState")]
        [HttpPost]
        public async Task<IActionResult> EditOrderState(OrderViewModel model)
        {
            try
            {
                if(model.OrderDto.OrderState<0) return Json(new { success = false, message = "Lütfen bir sipariş durumu seçiniz." });
                await _orderService.EditOrderState(model.OrderDto.Id, model.OrderDto.OrderState);
                return Json(new { success = true, message = "Sipariş durumu güncellendi.", redirectUrl = "/Admin/Order/"+model.OrderDto.Id});
            }
            catch (System.Exception)
            {
                return Json(new { success = false, message = "Sipariş durumu güncellenirken hata meydana geldi." });
            }
        }


        // Get All Orders
        public async Task<IEnumerable<OrderDto>> GetOrders()
            => _mapper.Map<IEnumerable<OrderDto>>(await _orderService.GetAllAsync());
    }
}
