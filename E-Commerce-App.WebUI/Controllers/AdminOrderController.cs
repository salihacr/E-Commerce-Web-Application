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
        private readonly IService<Order> _orderService;

        public AdminOrderController(IMapper mapper, ICartService cartService, IService<Order> orderService)
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
        [Route("/edit/{orderId}")]
        [HttpGet]
        public async Task<IActionResult> EditOrderState(int orderId)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditOrderState(OrderViewModel orderModel)
        {
            return View();
        }


        // Get All Orders
        public async Task<IEnumerable<OrderDto>> GetOrders()
            => _mapper.Map<IEnumerable<OrderDto>>(await _orderService.GetAllAsync());
    }
}
