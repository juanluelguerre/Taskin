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
    public class TaskService : BaseService<TaskModel, TaskEntity, int>, ITaskService
    {
        public TaskService(IMapper mapper, ITaskRepository repository, IUnitOfWork unitOfWork, ILogger<TaskService> logger) 
            : base(mapper, repository, unitOfWork, logger)
        {
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
