// ---------------------------------------------------------------------------------
// <copyright file="ProjectServiceTest.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
// Currently code coverage need Full pdb for .NETCore
// ---------------------------------------------------------------------------------
using AutoMapper;
using ElGuerre.ApplicationBlocks.Logging.Providers;
using ElGuerre.Taskin.Api.Data;
using ElGuerre.Taskin.Api.Data.Entity;
using ElGuerre.Taskin.Api.Data.Repository;
using ElGuerre.Taskin.Api.Models;
using ElGuerre.Taskin.Api.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ElGuerre.Taskin.Api.Tests.Services
{
    public class ProjectServiceTest
    {
        private readonly IMapper _mapper;

        public ProjectServiceTest()
        {
            // https://stackoverflow.com/questions/40275195/how-to-setup-automapper-in-asp-net-core
            var profile = new ProjectProfile();

            var config = new MapperConfiguration(ex => ex.AddProfile(profile));
            _mapper = new Mapper(config);

            (_mapper as IMapper).ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Fact]
        public async Task GetAllAsyncTest()
        {
            var projId = 1;
            var repository = new Mock<IProjectRepository>();
            repository.Setup(x => x.FindAsync(projId)).ReturnsAsync(GetProjectEntityMock(1, 1));
            repository.Setup(x => x.Get(null, null, "Tasks")).ReturnsAsync(new[] { GetProjectEntityMock(2, 1), GetProjectEntityMock(2, 2) });
            var unitOfWork = new Mock<IUnitOfWork>();
            var logProvider = new Mock<ILogProvider>();


            var service = new ProjectService(_mapper, repository.Object, unitOfWork.Object, logProvider.Object);

            var projs = await service.GetAsync();
            Assert.NotNull(projs);
            Assert.True(projs.Any(), "No projects found!");
            Assert.All(projs, item => Assert.True(item.Tasks.Any(), "Not tasks founds!"));
        }

        private ProjectEntity GetProjectEntityMock(int projId, int taskId)
        {
            return new ProjectEntity()
            {
                Id = projId,
                Title = "Project 1",
                Detail = "Detail for Project 1",
                ImageUrl = "http://google.es",
                ProjectType = new ProjectTypeEntity() { Id = 1, Value = ProjectType.Default },
                Tasks = new List<TaskEntity>()
                {
                    new TaskEntity() {
                        Id = taskId,
                        Priority = TaskPriority.Normal,
                        Effort = 1,
                        Detail = "Task 1",
                        TaskType = new TaskTypeEntity() { Id = 1, Value =  TaskType.ToDo }
                    }
                }
            };
        }

        [Fact(Skip = "Not implemented yet")]
        public async Task GetAsyncTest()
        {
        }
    }
}
