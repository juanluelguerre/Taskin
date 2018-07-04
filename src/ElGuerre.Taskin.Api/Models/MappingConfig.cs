// ---------------------------------------------------------------------------------
// <copyright file="MappingConfig.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.Taskin.Api.Data.Entity;
using ElGuerre.Taskin.Models;

namespace ElGuerre.Taskin.Api.Models
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                //config.AddProfile<MapProfile>();

                config.CreateMap<TaskModel, TaskEntity>();
                config.CreateMap<TaskEntity, TaskModel>();

                config.CreateMap<ProjectModel, ProjectEntity>();
                config.CreateMap<ProjectEntity, ProjectModel>();
            });
        }
    }
}
