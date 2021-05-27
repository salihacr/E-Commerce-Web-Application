using E_Commerce_App.Core.Entities;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.Services
{
    public interface ICartService : IService<Cart>
    {

        Task InitializeCart(string userId);

        Task AddToCart(string userId, string productId, int quantity, double price, string color);



        Task<Cart> GetCartByUserId(string userId);

        Task DeleteProductFromCart(string userId, string productId);

        Task ResetCart(int cartId);
    }
}
