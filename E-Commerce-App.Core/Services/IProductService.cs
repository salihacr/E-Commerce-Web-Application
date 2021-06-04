using E_Commerce_App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.Services
{
    public interface IProductService : IService<Product>
    {
        public int GetProductCount();
        public int GetProductCountBySearch(string query);
        Task<Product> GetProductWithAllColumns(Expression<Func<Product, bool>> predicate);
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
        /// <param name="query"></param>
        /// <returns></returns>
        Task<List<Product>> GetSearchResult(string query, int page, int pageSize);
        /// <summary>
        /// Get products to display on the home page. 
        /// </summary>
        /// <returns></returns>
        Task<List<Product>> GetHomePageProducts(int page, int pageSize);
        /// <summary>
        /// Get product count by category name
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int GetCountByCategory(string category);

        public void RemoveProduct(Product product);
    }
}
