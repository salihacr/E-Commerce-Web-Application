using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_App.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext _context { get => _context as AppDbContext; }
        public ProductRepository(AppDbContext context) : base(context) { }

        public Task<List<Product>> GetProductsByCategory(string name, int page, int pageSize)
        {
            throw new System.Exception();
        }

        public async Task<Product> GetProductWithCategoriesById(int productId)
        {
            var product = await _context.Products
                .Where(p => p.Id == productId)
                .Include(p => p.ProductCategories)
                .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync();

            return product;
        }
    }
}
