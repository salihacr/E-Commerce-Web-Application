using E_Commerce_App.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetOrderWithItems(object orderId);

        Task<List<OrderItem>> GetByUserIdAsync(string userId);
        Task EditOrderState(int orderId, EnumOrderState orderState);
    }
}
