using E_Commerce_App.Core.Entities;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<Cart> GetCartByUserId(string userId);

        Task DeleteProductFromCart(string productId, int cartId);

        Task ResetCart(int cartId);
    }
}
