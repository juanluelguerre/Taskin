// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using ElGuerre.Taskin.Api.Data.Entity;
using Microsoft.Extensions.Logging;

namespace ElGuerre.Taskin.Api.Data.Repository
{
    public class ProjectRepository : BaseRepository<ProjectEntity, int>, IProjectRepository
    {
        public ProjectRepository(DataContext dataContext, ILogger<ProjectRepository> logger) 
            : base (dataContext, logger)
        {
        }   
    }
}
