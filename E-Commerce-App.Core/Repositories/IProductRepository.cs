using E_Commerce_App.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        /// <summary>
        /// For pagination
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<List<Product>> GetProductsByCategory(string name, int page, int pageSize);
        /// <summary>
        /// Get products with categories
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<Product> GetProductWithCategoriesById(string productId);
        /// <summary>
        /// Get products by search text.
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        Task<List<Product>> GetSearchResult(string searchString);
        /// <summary>
        /// Get products to display on the home page. 
        /// </summary>
        /// <returns></returns>
        Task<List<Product>> GetHomePageProducts();
        /// <summary>
        /// Get product count by category name
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int GetCountByCategory(string category);
    }
}
