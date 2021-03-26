using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_Commerce_App.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _appDbcontext { get => _context as AppDbContext; }
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            var products = await _appDbcontext.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.Id == categoryId);
            return products;
        }
    }
}
