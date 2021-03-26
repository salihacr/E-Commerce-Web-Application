using E_Commerce_App.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<List<Product>> GetProductsByCategory(string name, int page, int pageSize);
        Task<Product> GetProductWithCategoriesById(string productId);
    }
}
