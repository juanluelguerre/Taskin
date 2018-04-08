// ---------------------------------------------------------------------------------
// <copyright file="ProjectService.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
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
    public class ProjectService : BaseService<ProjectModel, ProjectEntity, int>, IProjectService
    {
        public ProjectService(IProjectRepository repository, IUnitOfWork unitOfWork) 
            : base(repository, unitOfWork)
        {
        }

        public override async Task<IEnumerable<ProjectModel>> GetAsync()
        {
            var entities = await Repository.Get(null, null, "Tasks");
            var model = entities.Select(x => AutoMapper.Mapper.Map<ProjectEntity, ProjectModel>(x));
            return model;
        }

        public override async Task<ProjectModel> GetAsync(int id)
        {
            var query = await Repository.Get(t => t.Id == id, null, "Tasks");
            if (query != null)
            {
                var model = AutoMapper.Mapper.Map<ProjectEntity, ProjectModel>(query.FirstOrDefault());
                return model;
            }
            return null;
        }

    }
}
