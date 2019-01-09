// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using AutoMapper;
using ElGuerre.Taskin.Api.Data;
using ElGuerre.Taskin.Api.Data.Entity;
using ElGuerre.Taskin.Api.Data.Repository;
using ElGuerre.Taskin.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElGuerre.Taskin.Api.Services
{
    public class ProjectService : BaseService<ProjectModel, ProjectEntity, int>, IProjectService
    {
        public ProjectService(
            IMapper mapper, 
            IProjectRepository repository, 
            IUnitOfWork unitOfWork, 
            ILogger<ProjectService> logger) 
            : base(mapper, repository, unitOfWork, logger)
        {
        }

        public override async Task<IEnumerable<ProjectModel>> GetAsync()
        {
            Log();

            var entities = await Repository.Get(null, null, "Tasks");
            var model = entities.Select(_mapper.Map<ProjectEntity, ProjectModel>);
            return model;
        }

        public override async Task<ProjectModel> GetAsync(int id)
        {
            Log(args: id);

            var query = await Repository.Get(p => p.Id == id, null, "Tasks");
            if (query != null)
            {
                var model = _mapper.Map<ProjectEntity, ProjectModel>(query.FirstOrDefault());                               
                return model;
            }
            _logger.LogWarning($"{nameof(GetAsync)}({id}) return null. Project not found");
            return null;
        }

    }
}
