using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_App.Data.Repositories
{
    // TODO eğer bir ürün admin tarafından silinirse tüm sepetlerden silinsin.
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private AppDbContext _appDbContext { get => _context; }
        public OrderRepository(AppDbContext context) : base(context) { }

        public async Task<Order> GetOrderWithItems(object orderId)
        {
            return await _appDbContext.Orders
                       .Include(i => i.OrderItems)
                       .ThenInclude(i => i.Product)
                       .FirstOrDefaultAsync(i => i.Id == Convert.ToInt32(orderId));
        }

        //public async Task<List<Order>> GetByUserIdAsync(string userId)
        //{
        //    return await _appDbContext.Orders.Include(i => i.OrderItems)
        //        .ThenInclude(i => i.Product)
        //        .Where(i => i.UserId == userId).ToListAsync();
        //}
        public async Task<List<OrderItem>> GetByUserIdAsync(string userId)
        {
            var orderItems =  await _appDbContext.OrderItems
                .Include(i=>i.Product).Where(x=>x.Order.UserId == userId).Include(i => i.Order)
                .ToListAsync();
            return orderItems;
        }
    }
}
