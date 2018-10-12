// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using ElGuerre.Taskin.Api.Data.Entity;
using Microsoft.Extensions.Logging;

namespace ElGuerre.Taskin.Api.Data.Repository
{
    public class TaskRepository : BaseRepository<TaskEntity, int>, ITaskRepository
    {
        public TaskRepository(DataContext dataContext, ILogger<TaskRepository> logger) 
            : base (dataContext, logger)
        {
        }
    }
}
