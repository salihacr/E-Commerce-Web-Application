using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace E_Commerce_App.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Update(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
