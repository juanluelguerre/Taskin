// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
// https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
//
using ElGuerre.Taskin.Api.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ElGuerre.Taskin.Api.Data.Repository
{
    public abstract class BaseRepository<TEntity, Tkey> : IEntityRepository<TEntity, Tkey>
            where TEntity : class, IEntity<Tkey>, new()
    {
        private readonly DataContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual TEntity Find(Tkey id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<TEntity> FindAsync(Tkey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var prop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual TEntity Create()
        {
            return Activator.CreateInstance<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            var result = _dbSet.Add(entity);
            Save();
            return result.Entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = _dbSet.Add(entity);
            await SaveAsync();
            return result.Entity;
        }

        public virtual void Update(TEntity entity)
        {
            InternalUpdate(entity);
            Save();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            InternalUpdate(entity);
            await SaveAsync();
        }

        public virtual void Delete(Tkey id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
            Save();
        }

        public virtual async Task DeleteAsync(Tkey id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
            await SaveAsync();
        }

        public virtual void Delete(TEntity entity)
        {
            InternalDelete(entity);
            Save();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            InternalDelete(entity);
            await SaveAsync();
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Any(filter);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.AnyAsync(filter);
        }

        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter);
        }

        public virtual int Count()
        {
            return _dbSet.Count();
        }

        public virtual Task<int> CountAsync()
        {
            return _dbSet.CountAsync();
        }

        private void InternalUpdate(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        private void InternalDelete(TEntity entity)
        {
            var entityFound = Find(entity.Id);
            if (entityFound != null)
            {
                //if (_context.Entry(entityFound).State == EntityState.Detached)
                //{
                //    _dbSet.Attach(entityFound);
                //}
                _dbSet.Remove(entityFound);
            }
        }

        private void Save()
        {
            _context.SaveChanges();
        }

        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}