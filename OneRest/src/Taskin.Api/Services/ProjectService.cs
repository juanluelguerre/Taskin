// ---------------------------------------------------------------------------------
// <copyright file="ProjectService.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.OneRest.Taskin.Api.Data;
using ElGuerre.OneRest.Taskin.Api.Data.Entity;
using ElGuerre.OneRest.Taskin.Api.Data.Repository;
using ElGuerre.OneRest.Taskin.Api.Models;

namespace ElGuerre.OneRest.Taskin.Api.Services
{
    public class ProjectService : BaseService<ProjectModel, ProjectEntity, int>, IProjectService
    {
        public ProjectService(IProjectRepository repository, IUnitOfWork unitOfWork) 
            : base(repository, unitOfWork)
        {
        }
    }
}
