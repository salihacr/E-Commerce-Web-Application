using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Repositories;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace E_Commerce_App.Business.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository) { }

        public int GetCountByCategory(string category)
        {
            return _unitOfWork.ProductRepository.GetCountByCategory(category);
        }

        public async Task<List<Product>> GetHomePageProducts()
        {
            return await _unitOfWork.ProductRepository.GetHomePageProducts();
        }

        public async Task<List<Product>> GetProductsByCategory(string name, int page, int pageSize)
        {
            return await _unitOfWork.ProductRepository.GetProductsByCategory(name, page, pageSize);
        }

        public async Task<Product> GetProductWithAllColumns(Expression<Func<Product, bool>> predicate)
        {
            return await _unitOfWork.ProductRepository.GetProductWithAllColumns(predicate);
        }

        public async Task<Product> GetProductWithCategoriesById(string productId)
        {
            return await _unitOfWork.ProductRepository.GetProductWithCategoriesById(productId);
        }

        public async Task<List<Product>> GetSearchResult(string searchString)
        {
            return await _unitOfWork.ProductRepository.GetSearchResult(searchString);
        }
    }
}
