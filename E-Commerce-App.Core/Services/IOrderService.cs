using E_Commerce_App.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.Services
{
    public interface IOrderService : IService<Order>
    {
        Task<Order> GetOrderWithItems(object orderId);

        Task<List<OrderItem>> GetByUserIdAsync(string userId);
    }
}
