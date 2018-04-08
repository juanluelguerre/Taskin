// ---------------------------------------------------------------------------------
// <copyright file="ITaskRepository.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.OneRest.Taskin.Api.Data.Entity;

namespace ElGuerre.OneRest.Taskin.Api.Data.Repository
{
    public interface ITaskRepository : IEntityRepository<TaskEntity, int>
    {
    }
}
