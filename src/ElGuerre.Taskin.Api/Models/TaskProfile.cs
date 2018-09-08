// ---------------------------------------------------------------------------------
// <copyright file="MappingConfig.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using AutoMapper;
using ElGuerre.Taskin.Api.Data.Entity;
using ElGuerre.Taskin.Models;

namespace ElGuerre.Taskin.Api.Models
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskModel, TaskEntity>();
            CreateMap<TaskEntity, TaskModel>();
        }
    }
}
