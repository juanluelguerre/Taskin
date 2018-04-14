// ---------------------------------------------------------------------------------
// <copyright file="TaskRepository.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.Taskin.Api.Data.Entity;

namespace ElGuerre.Taskin.Api.Data.Repository
{
    public class TaskRepository : BaseRepository<TaskEntity, int>, ITaskRepository
    {
        public TaskRepository(DataContext dataContext) : base (dataContext)
        {
        }
    }
}
