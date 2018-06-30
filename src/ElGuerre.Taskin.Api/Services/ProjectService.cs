// ---------------------------------------------------------------------------------
// <copyright file="ProjectService.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.ApplicationBlocks.Logging.Providers;
using ElGuerre.Taskin.Api.Data;
using ElGuerre.Taskin.Api.Data.Entity;
using ElGuerre.Taskin.Api.Data.Repository;
using ElGuerre.Taskin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElGuerre.Taskin.Api.Services
{
    public class ProjectService : BaseService<ProjectModel, ProjectEntity, int>, IProjectService
    {
        public ProjectService(IProjectRepository repository, IUnitOfWork unitOfWork, ILogProvider logProvider) 
            : base(repository, unitOfWork, logProvider)
        {
        }

        public override async Task<IEnumerable<ProjectModel>> GetAsync()
        {
            _logger.Trace("GetAsync");

            var entities = await Repository.Get(null, null, "Tasks");
            var model = entities.Select(AutoMapper.Mapper.Map<ProjectEntity, ProjectModel>);
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
