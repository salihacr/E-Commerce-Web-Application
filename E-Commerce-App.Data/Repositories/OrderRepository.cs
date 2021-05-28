using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace E_Commerce_App.Data.Repositories
{
    // TODO eğer bir ürün admin tarafından silinirse tüm sepetlerden silinsin.
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private AppDbContext _appDbContext { get => _context; }
        public OrderRepository(AppDbContext context) : base(context) { }
        
        public async Task<Order> GetOrdersWithItems(object orderId)
        {
            return await _appDbContext.Orders
                       .Include(i => i.OrderItems)
                       .FirstOrDefaultAsync(i => i.Id == Convert.ToInt32(orderId));
        }
    }
}
