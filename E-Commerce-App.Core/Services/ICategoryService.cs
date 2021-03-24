using E_Commerce_App.Core.Entities;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}
