// ---------------------------------------------------------------------------------
// <copyright file="ProjectService.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProjectService(IMapper mapper, IProjectRepository repository, IUnitOfWork unitOfWork, ILogProvider logProvider) 
            : base(mapper, repository, unitOfWork, logProvider)
        {
            _mapper = mapper;
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

            var query = await Repository.Get(t => t.Id == id, null, "Tasks");
            if (query != null)
            {
                var model = _mapper.Map<ProjectEntity, ProjectModel>(query.FirstOrDefault());                               
                return model;
            }
            _logger.Warning($"{nameof(GetAsync)}({id}) return null. Project not found");
            return null;
        }

    }
}
