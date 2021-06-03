using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Repositories;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.UnitOfWorks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App.Business.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        public OrderService(IUnitOfWork unitOfWork, IRepository<Order> repository) : base(unitOfWork, repository) { }

        public async Task<Order> GetOrderWithItems(object orderId)
        {
            return await _unitOfWork.OrderRepository.GetOrderWithItems(orderId);
        }

        public async Task<List<OrderItem>> GetByUserIdAsync(string userId)
        {
            return await _unitOfWork.OrderRepository.GetByUserIdAsync(userId);
        }
    }
}
