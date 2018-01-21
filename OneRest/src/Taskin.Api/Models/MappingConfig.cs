// ---------------------------------------------------------------------------------
// <copyright file="MappingConfig.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.OneRest.Taskin.Api.Data.Entity;

namespace ElGuerre.OneRest.Taskin.Api.Models
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                //config.AddProfile<MapProfile>();
                config.CreateMap<ProjectModel, ProjectEntity>();
                config.CreateMap<ProjectEntity, ProjectModel>();
            });
        }
    }
}
