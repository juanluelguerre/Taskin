// ---------------------------------------------------------------------------------
// <copyright file="BaseService.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.OneRest.Taskin.Api.Data;
using ElGuerre.OneRest.Taskin.Api.Data.Entity;
using ElGuerre.OneRest.Taskin.Api.Data.Repository;
using ElGuerre.Taskin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElGuerre.OneRest.Taskin.Api.Services
{
    public abstract class BaseService<TModel, TEntity, Tkey> : IBaseService<TModel, Tkey>
        where TModel : class, IModel<Tkey>
        where TEntity : class, IEntity<Tkey>
    {       
        private readonly IEntityRepository<TEntity, Tkey> _repository;
        private readonly IUnitOfWork _unitOfWork;

        protected IUnitOfWork UnityOfWork { get => _unitOfWork; }
        protected IEntityRepository<TEntity, Tkey> Repository { get => _repository; }

        protected BaseService(IEntityRepository<TEntity, Tkey> repository, IUnitOfWork unityOfWork)
        {
            _repository = repository;
            _unitOfWork = unityOfWork;
        }

        public virtual async Task<IEnumerable<TModel>> GetAsync()
        {
            var entities = await _repository.Get();
            var model = entities.Select(x => AutoMapper.Mapper.Map<TEntity, TModel>(x));
            return model.ToList();
        }

        public virtual async Task<TModel> GetAsync(Tkey id)
        {
            var entity = await _repository.FindAsync(id);
            var model = AutoMapper.Mapper.Map<TEntity, TModel>(entity);
            return model;
        }

        public async Task<TModel> AddAsync(TModel model)
        {
            var entity = _repository.Create();
            var entityDest = AutoMapper.Mapper.Map(model, entity);
            await _repository.AddAsync(entityDest);
            _unitOfWork.Commit();
            var savedModel = AutoMapper.Mapper.Map<TEntity, TModel>(entityDest);
            return savedModel;
        }

        public  async Task<TModel> UpdateAsync(TModel model)
        {
            var entity = await _repository.FindAsync(model.Id);
            if (entity == null)
                return null;
            entity = AutoMapper.Mapper.Map(model, entity);
            _repository.Update(entity);
            _unitOfWork.Commit();
            var savedModel = AutoMapper.Mapper.Map<TEntity, TModel>(entity);
            return savedModel;
        }

        public async Task DeleteAsync(TModel model)
        {
            var entity = AutoMapper.Mapper.Map<TModel, TEntity>(model);
            await _repository.DeleteAsync(entity);
            _unitOfWork.Commit();
        }

        public async Task<bool> ExistsAsync(Tkey id)
        {
            return await _repository.FindAsync(id) == null ? false : true;            
        }

        //public int Count()
        //{
        //    return _repository.Count();
        //}

        //public Task<int> CountAsync()
        //{
        //    return _repository.CountAsync();
        //}
    }
}
