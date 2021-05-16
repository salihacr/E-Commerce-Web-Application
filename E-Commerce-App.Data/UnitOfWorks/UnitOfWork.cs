using E_Commerce_App.Core.Repositories;
using E_Commerce_App.Core.UnitOfWorks;
using E_Commerce_App.Data.Repositories;
using System.Threading.Tasks;

namespace E_Commerce_App.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        // Repositories
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;
        private CartRepository _cartRepository;

        public ICategoryRepository CategoryRepository => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public IProductRepository ProductRepository => _productRepository = _productRepository ?? new ProductRepository(_context);

        public ICartRepository CartRepository => _cartRepository = _cartRepository ?? new CartRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
