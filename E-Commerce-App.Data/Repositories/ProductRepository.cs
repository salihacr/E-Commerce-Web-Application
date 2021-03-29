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

        public async Task<List<Product>> GetProductsByCategory(string name, int page, int pageSize)
        {
            var products = _context.Products.Where(p => p.IsHome).AsQueryable();
            if (string.IsNullOrEmpty(name))
            {
                products = products.Include(p => p.ProductCategories).ThenInclude(i => i.Category).Where(i => i.ProductCategories.Any(p => p.Category.Name.ToLower() == name.ToLower()));
            }
            return await products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
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

        public async Task<List<Product>> GetSearchResult(string searchString)
        {
            var products = _context
                     .Products
                     .Where(i => i.IsHome && (i.Name.ToLower().Contains(searchString.ToLower()) || i.Description.ToLower().Contains(searchString.ToLower())))
                     .AsQueryable();

            return await products.ToListAsync();
        }

        public async Task<List<Product>> GetHomePageProducts()
        {
            return await _context.Products.Where(p => p.IsHome == true).ToListAsync();
        }

        public int GetCountByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                var products = _context.Products
                .Include(product => product.ProductCategories)
                .ThenInclude(productCategory => productCategory.Category)
                .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                return products.Count();
            }
            return -1;
        }
    }
}
