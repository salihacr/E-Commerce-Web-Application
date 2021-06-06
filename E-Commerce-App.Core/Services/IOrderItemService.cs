using E_Commerce_App.Core.Entities;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.Services
{
    public interface IOrderItemService : IService<OrderItem>
    {
        Task AddComment(int orderItemId);
    }
}
