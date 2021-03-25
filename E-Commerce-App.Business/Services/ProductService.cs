﻿using E_Commerce_App.Core.Entities;
using E_Commerce_App.Core.Repositories;
using E_Commerce_App.Core.Services;
using E_Commerce_App.Core.UnitOfWorks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_App.Business.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository) { }

        public async Task<List<Product>> GetProductsByCategory(string name, int page, int pageSize)
        {
            return await _unitOfWork.ProductRepository.GetProductsByCategory(name, page, pageSize);
        }
    }
}
