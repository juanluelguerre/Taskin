﻿// ---------------------------------------------------------------------------------
// <copyright file="TaskService.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
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
    public class TaskService : BaseService<TaskModel, TaskEntity, int>, ITaskService
    {
        public TaskService(ITaskRepository repository, IUnitOfWork unitOfWork, ILogProvider logProvider) 
            : base(repository, unitOfWork, logProvider)
        {
        }

        public override async Task<IEnumerable<TaskModel>> GetAsync()
        {
            Log();

            var entities = await Repository.Get(/* null, null, "Pomodoros" */);
            var model = entities.Select(AutoMapper.Mapper.Map<TaskEntity, TaskModel>);
            return model;
        }

    }
}
