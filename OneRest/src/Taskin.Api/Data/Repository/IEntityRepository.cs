// ---------------------------------------------------------------------------------
// <copyright file="IEntityRepository.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.OneRest.Taskin.Api.Data.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ElGuerre.OneRest.Taskin.Api.Data.Repository
{
    public interface IEntityRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        TEntity Create();
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
        TEntity Find(TKey id);
        Task<TEntity> FindAsync(TKey id);
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter);
        bool Any(Expression<Func<TEntity, bool>> fileter);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);
        int Count();
        Task<int> CountAsync() ;
    }
}
