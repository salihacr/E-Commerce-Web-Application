﻿using E_Commerce_App.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        // Repositories
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }

        Task CommitAsync();
        void Commit();
    }
}
