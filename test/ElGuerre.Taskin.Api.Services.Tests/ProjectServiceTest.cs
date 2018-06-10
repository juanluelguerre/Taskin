// ---------------------------------------------------------------------------------
// <copyright file="ProjectServiceTest.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.Taskin.Api.Data;
using ElGuerre.Taskin.Api.Data.Entity;
using ElGuerre.Taskin.Api.Data.Repository;
using ElGuerre.Taskin.Api.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ElGuerre.Taskin.Api.Services.Tests
{
    public class ProjectServiceTest
    {
        public ProjectServiceTest()
        {
            MappingConfig.RegisterMaps();
        }

        [Fact]
        public async Task GetAllAsyncTest()
        {
            var projId = 1;
            var repository = new Mock<IProjectRepository>();
            repository.Setup(x => x.FindAsync(projId)).ReturnsAsync(GetProjectEntityMock(1, 1));
            repository.Setup(x => x.Get(null, null, "Tasks")).ReturnsAsync(new[] { GetProjectEntityMock(2, 1), GetProjectEntityMock(2, 2) });
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ProjectService(repository.Object, unitOfWork.Object);

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
