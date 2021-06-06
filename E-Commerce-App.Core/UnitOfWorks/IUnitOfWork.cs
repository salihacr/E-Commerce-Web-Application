using E_Commerce_App.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        // Repositories
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        ICartRepository CartRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }

        Task CommitAsync();
        void Commit();
    }
}
