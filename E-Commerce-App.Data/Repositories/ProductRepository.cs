using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Repositories;
using System.Collections.Generic;
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
    }
}
