// ---------------------------------------------------------------------------------
// <copyright file="ITaskService.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.Taskin.Models;

namespace ElGuerre.OneRest.Taskin.Api.Services
{
    public interface ITaskService : IBaseService<TaskModel, int>
    {
    }
}
