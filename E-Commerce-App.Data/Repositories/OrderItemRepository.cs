using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_Commerce_App.Data.Repositories
{
    // TODO eğer bir ürün admin tarafından silinirse tüm sepetlerden silinsin.
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        private AppDbContext _appDbContext { get => _context; }
        public OrderItemRepository(AppDbContext context) : base(context) { }

        public async Task AddComment(int orderItemId)
        {
            var orderItem = await _appDbContext.OrderItems.SingleOrDefaultAsync(p => p.Id == orderItemId);
            if (orderItem != null)
                orderItem.HasComment = true;
        }

    }
}
