using E_Commerce_App.Core.Entities;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetOrdersWithItems(object orderId);
    }
}
