﻿// ---------------------------------------------------------------------------------
// <copyright file="ProjectRepository.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.Taskin.Api.Data.Entity;

namespace ElGuerre.Taskin.Api.Data.Repository
{
    public class ProjectRepository : BaseRepository<ProjectEntity, int>, IProjectRepository
    {
        public ProjectRepository(DataContext dataContext) : base (dataContext)
        {
        }
    }
}