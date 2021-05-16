using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_Commerce_App.Data.Repositories
{


    // TODO eğer bir ürün admin tarafından silinirse tüm sepetlerden silinsin.

    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private AppDbContext _appDbContext { get => _context; }
        public CartRepository(AppDbContext context) : base(context) { }


        public async Task DeleteProductFromCart(string productId, int cartId)
        {
            var command = @"Delete From CartItems Where ProductId=@productId and CartId=@cartId";
            await _appDbContext.Database.ExecuteSqlRawAsync(command, productId, cartId);
        }

        public async Task<Cart> GetCartByUserId(string userId)
        {
            return await _appDbContext.Carts
               .Include(i => i.CartItems)
               .ThenInclude(i => i.Product)
               .FirstOrDefaultAsync(i => i.UserId == userId);
        }

        public async Task ResetCart(int cartId)
        {
            var command = @"Delete From CartItems Where CartId=@cartId";
            await _appDbContext.Database.ExecuteSqlRawAsync(command, cartId);
        }
    }
}
