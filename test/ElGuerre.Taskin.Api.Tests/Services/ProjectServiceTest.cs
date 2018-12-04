// ---------------------------------------------------------------------------------
// <copyright file="ProjectServiceTest.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
// Currently code coverage need Full pdb for .NETCore
// ---------------------------------------------------------------------------------
using AutoMapper;
using ElGuerre.Taskin.Api.Data;
using ElGuerre.Taskin.Api.Data.Entity;
using ElGuerre.Taskin.Api.Data.Repository;
using ElGuerre.Taskin.Api.Models;
using ElGuerre.Taskin.Api.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace ElGuerre.Taskin.Api.Tests.Services
{
    // [ExcludeFromCodeCoverage]
    public class ProjectServiceTest
    {
        private readonly ProjectService _service;
        private readonly Mock<IProjectRepository> _repository;
        private readonly IMapper _mapper;

        public ProjectServiceTest()
        {
            // https://stackoverflow.com/questions/40275195/how-to-setup-automapper-in-asp-net-core
            var profile = new ProjectProfile();

            var config = new MapperConfiguration(ex => ex.AddProfile(profile));
            _mapper = new Mapper(config);

            (_mapper as IMapper).ConfigurationProvider.AssertConfigurationIsValid();

            _repository = new Mock<IProjectRepository>();
            _repository.Setup(x => x.FindAsync(1)).ReturnsAsync(GetProjectEntityMock(1, 1));
            _repository.Setup(x => x.Get(null, null, "Tasks"))
                .ReturnsAsync(new[] { GetProjectEntityMock(1, 1), GetProjectEntityMock(2, 1) });
            var unitOfWork = new Mock<IUnitOfWork>();
            var logProvider = new Mock<ILogger<ProjectService>>();


            _service = new ProjectService(_mapper, _repository.Object, unitOfWork.Object, logProvider.Object);
        }

        [Fact]
        public async Task GetAllAsyncTest()
        {
            var projs = await _service.GetAsync();
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

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetAsyncTest(int id)
        {
            _repository.Setup(x => x.Get(It.IsAny<Expression<Func<ProjectEntity, bool>>>(), null, "Tasks"))
                .ReturnsAsync(new[] { GetProjectEntityMock(1, 1), GetProjectEntityMock(2, 1) });

            var proj = await _service.GetAsync(id);
            Assert.NotNull(proj);
            var expected = _mapper.Map<ProjectEntity, Taskin.Models.ProjectModel>(GetProjectEntityMock(id, 1));
            Assert.NotEqual(expected, proj);
        }

        [Theory]
        [InlineData(1)]
        public async Task DeleteAsyncTest(int id)
        {
            _repository.Setup(x => x.Delete(It.IsAny<ProjectEntity>()));
            await _service.DeleteAsync(new Taskin.Models.ProjectModel() { Id = id });
        }

        [Theory]
        [InlineData(1)]
        public async Task ExistsAsyncTest(int id)
        {
            var exists = await _service.ExistsAsync(id);
            Assert.True(exists, $"Project with id '{id}' not found.");
        }

        [Theory]
        [InlineData(1)]
        public async Task UpdateAsyncTest(int id)
        {
            var newProj = _mapper.Map<ProjectEntity, Taskin.Models.ProjectModel>(GetProjectEntityMock(id, 1));

            var proj = await _service.UpdateAsync(newProj);
            Assert.NotNull(proj);
            Assert.NotEqual(newProj, proj);
        }

        [Fact]
        public async Task AddAsyncTest()
        {
            var newProj = _mapper.Map<ProjectEntity, Taskin.Models.ProjectModel>(GetProjectEntityMock(1, 1));

            var proj = await _service.AddAsync(newProj);
            Assert.NotNull(proj);
            Assert.NotEqual(newProj, proj);
        }
    }
}
