using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Repositories;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.UnitOfWorks;
using System.Threading.Tasks;

namespace E_Commerce_App.Business.Services
{
    public class CartService : Service<Cart>, ICartService
    {
        public CartService(IUnitOfWork unitOfWork, IRepository<Cart> repository) : base(unitOfWork, repository) { }

        public async Task AddToCart(string userId, string productId, int quantity)
        {
            var cart = await GetCartByUserId(userId);
            if (cart != null)
            {
                var index = cart.CartItems.FindIndex(i => i.ProductId == productId);
                // eklenmek isteyen ürün sepette yoksa yeni oluştur (ekleme)
                if (index < 0)
                {
                    cart.CartItems.Add(new CartItem()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        CartId = cart.Id
                    });
                }
                // eklenmek isteyen ürün sepette var mı (güncelleme)
                else
                    cart.CartItems[index].Quantity += quantity;

                _unitOfWork.CartRepository.Update(cart);
            }
        }

        public async Task DeleteProductFromCart(string userId, string productId)
        {
            var cart = await GetCartByUserId(userId);
            if (cart != null)
                await _unitOfWork.CartRepository.DeleteProductFromCart(productId, cart.Id);

        }

        public async Task<Cart> GetCartByUserId(string userId)
        {
            return await _unitOfWork.CartRepository.GetCartByUserId(userId);
        }

        public async Task InitializeCart(string userId)
        {
            await _unitOfWork.CartRepository.AddAsync(new Cart() { UserId = userId });
        }

        public async Task ResetCart(int cartId)
        {
            await _unitOfWork.CartRepository.ResetCart(cartId);
        }
    }
}
