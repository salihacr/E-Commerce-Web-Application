using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                products = products.Include(p => p.ProductCategories).ThenInclude(i => i.Category).Where(i => i.ProductCategories.Any(p => p.Category.Url.ToLower() == name.ToLower()));
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

        public async Task<List<Product>> GetHomePageProducts(int page, int pageSize)
        {
            var products = _context.Products.Where(p => p.IsHome == true).AsQueryable();
            return await products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public int GetProductCount() => _context.Products.Where(p => p.IsHome == true).Count();

        public int GetProductCountBySearch(string query)
        {
            var products = _appDbContext.Products
                            .Where(p => p.IsHome &&
                            (p.Name.ToLower().Contains(query)
                            || p.ShortDescription.ToLower().Contains(query)
                            || p.Description.ToLower().Contains(query))).AsQueryable();
            return products.Count();
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

        public async Task<Product> GetProductWithAllColumns(Expression<Func<Product, bool>> predicate)
        {
            return await _appDbContext.Products
                .Include(product => product.ProductColors)
                .ThenInclude(productColor => productColor.Color)
                .Include(product => product.ProductCategories)
                .ThenInclude(productCategory => productCategory.Category)
                .Include(product => product.Images)
                .SingleOrDefaultAsync(predicate);
        }
        public async Task<List<Product>> GetSearchResult(string query, int page, int pageSize)
        {
            query = query.ToLower();
            var products = _appDbContext.Products
                .Where(p => p.IsHome &&
                (p.Name.ToLower().Contains(query)
                || p.ShortDescription.ToLower().Contains(query)
                || p.Description.ToLower().Contains(query))).AsQueryable();

            return await products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
