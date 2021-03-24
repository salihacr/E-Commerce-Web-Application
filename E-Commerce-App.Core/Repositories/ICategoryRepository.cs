using E_Commerce_App.Core.Entities;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}
