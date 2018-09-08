// ---------------------------------------------------------------------------------
// <copyright file="TaskService.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
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
    public class TaskService : BaseService<TaskModel, TaskEntity, int>, ITaskService
    {
        private readonly IMapper _mapper;

        public TaskService(IMapper mapper, ITaskRepository repository, IUnitOfWork unitOfWork, ILogProvider logProvider) 
            : base(mapper, repository, unitOfWork, logProvider)
        {
            _mapper = mapper;
        }
        

        public override async Task<IEnumerable<TaskModel>> GetAsync()
        {
            Log();

            var entities = await Repository.Get(/* null, null, "Pomodoros" */);
            var model = entities.Select(_mapper.Map<TaskEntity, TaskModel>);
            return model;
        }

    }
}
