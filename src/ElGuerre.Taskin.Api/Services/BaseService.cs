﻿// ---------------------------------------------------------------------------------
// <copyright file="BaseService.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.ApplicationBlocks.Logging;
using ElGuerre.ApplicationBlocks.Logging.Providers;
using ElGuerre.Taskin.Api.Data;
using ElGuerre.Taskin.Api.Data.Entity;
using ElGuerre.Taskin.Api.Data.Repository;
using ElGuerre.Taskin.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ElGuerre.Taskin.Api.Services
{
    /// <summary>
    /// Base service used to business/domain logic. Depend on data reposity to complete operation.
    /// </summary>
    public abstract class BaseService<TModel, TEntity, Tkey> : IBaseService<TModel, Tkey>
        where TModel : class, IModel<Tkey>
        where TEntity : class, IEntity<Tkey>
    {       
        readonly IEntityRepository<TEntity, Tkey> _repository;
        IUnitOfWork _unitOfWork;
        protected readonly ILogger _logger;

        protected IUnitOfWork UnityOfWork { get => _unitOfWork; }
        protected IEntityRepository<TEntity, Tkey> Repository { get => _repository; }

        protected BaseService(IEntityRepository<TEntity, Tkey> repository, IUnitOfWork unityOfWork, ILogProvider logProvider)
        {
            _repository = repository;
            _unitOfWork = unityOfWork;
            _logger = new Logger(logProvider);
        }

        public virtual async Task<IEnumerable<TModel>> GetAsync()
        {
            Log();

            var entities = await _repository.Get();
            var model = entities.Select(AutoMapper.Mapper.Map<TEntity, TModel>);
            return model.ToList();
        }

        public virtual async Task<TModel> GetAsync(Tkey id)
        {
            Log(args: id);

            var entity = await _repository.FindAsync(id);
            var model = AutoMapper.Mapper.Map<TEntity, TModel>(entity);
            return model;
        }

        public async Task<TModel> AddAsync(TModel model)
        {
            Log(model: model);

            var entity = _repository.Create();
            var entityDest = AutoMapper.Mapper.Map(model, entity);

            await _repository.AddAsync(entityDest);
            _unitOfWork.Commit();

            var savedModel = AutoMapper.Mapper.Map<TEntity, TModel>(entityDest);
            return savedModel;
        }

        public  async Task<TModel> UpdateAsync(TModel model)
        {
            Log(model: model);

            var entity = await _repository.FindAsync(model.Id);
            if (entity == null) return null;

            entity = AutoMapper.Mapper.Map(model, entity);
            _repository.Update(entity);
            _unitOfWork.Commit();

            var savedModel = AutoMapper.Mapper.Map<TEntity, TModel>(entity);
            return savedModel;
        }

        public async Task DeleteAsync(TModel model)
        {
            Log(model: model);

            var entity = AutoMapper.Mapper.Map<TModel, TEntity>(model);
            await _repository.DeleteAsync(entity);
            _unitOfWork.Commit();
        }

        public async Task<bool> ExistsAsync(Tkey id)
        {
            Log(args: id);

            return await _repository.FindAsync(id) != null;            
        }

        //public int Count()
        //{
        //    return _repository.Count();
        //}

        //public Task<int> CountAsync()
        //{
        //    return _repository.CountAsync();
        //}


        protected void Log([CallerMemberName] string methodName = "", params object[] args)
        {
            var parameter = (args == null) ? string.Empty : $"{args}";
            Log(methodName, parameter);
        }

        protected void Log([CallerMemberName] string methodName = "", TModel model = null)
        {
            var parameter = (model == null) ? string.Empty : $"{JsonConvert.SerializeObject(model)}";
            Log(methodName, parameter);
        }

        void Log(string methodName, string parameter)
        {
            _logger.Trace($"{GetType().Name}.{methodName}({parameter})");
        }
    }
}