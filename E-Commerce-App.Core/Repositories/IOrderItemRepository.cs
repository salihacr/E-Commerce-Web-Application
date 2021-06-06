using E_Commerce_App.Core.Entities;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.Repositories
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task AddComment(int orderItemId);
    }
}
