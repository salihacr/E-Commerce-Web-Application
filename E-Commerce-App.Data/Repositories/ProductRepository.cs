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
        private AppDbContext _appDbContext { get => _context; }
        public ProductRepository(AppDbContext context) : base(context) { }

        public Task<List<Product>> GetProductsByCategory(string name, int page, int pageSize)
        {
            throw new System.Exception();
        }

        public async Task<Product> GetProductWithCategoriesById(string productId)
        {
            var product = await _context
                .Products
                .Include(product => product.ProductCategories)
                .ThenInclude(productCategory => productCategory.Category)
                .SingleOrDefaultAsync(x => x.Id == productId);


            return product;
        }
    }
}
