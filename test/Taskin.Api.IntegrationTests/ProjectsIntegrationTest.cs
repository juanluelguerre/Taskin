// ---------------------------------------------------------------------------------
// <copyright file="ProjectsIntegrationTest.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
//
// To run this tests be sure set ASPNETCORE_ENVIRONMENT = Develpment 
// for Environement variables en "Debug" tabs for project properties.
//
// ---------------------------------------------------------------------------------
using ElGuerre.Taskin.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ElGuerre.Taskin.Api.IntegrationTests
{
    public class ProjectsIntegrationTest : BaseTest
    {
        public ProjectsIntegrationTest(CompositionRootFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task GetAllTest()
        {
            var response = await Fixture.Client.GetAsync($"api/projects");
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();

            var projs = JsonConvert.DeserializeObject<IEnumerable<ProjectModel>>(content);
            Assert.NotNull(projs);
            Assert.True(projs.Any());
            Assert.All(projs, item => Assert.True(item.Tasks.Any()));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetTest(int projId)
        {
            var response = await Fixture.Client.GetAsync($"api/projects/{projId}");
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();

            var proj = JsonConvert.DeserializeObject<ProjectModel>(content);
            Assert.NotNull(proj);
            Assert.NotNull(proj.Tasks);
            Assert.True(proj.Tasks.Any());
        }

        [Theory]
        [InlineData(33)]
        public async Task GetNotFoundTest(int projId)
        {
            var response = await Fixture.Client.GetAsync($"api/projects/{projId}");
            Assert.Throws<HttpRequestException>(() => response.EnsureSuccessStatusCode());

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        public async Task GetTasksByProjectIdTest(int projId)
        {
            var response = await Fixture.Client.GetAsync($"api/projects/{projId}");
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();

            var proj = JsonConvert.DeserializeObject<ProjectModel>(content);
            Assert.NotNull(proj);
            Assert.NotNull(proj.Tasks);
            Assert.True(proj.Tasks.Any());
        }

        [Fact]
        public async Task PostTest()
        {
            var content = GetSampleProject(15);

            var response = await Fixture.Client.PostAsync($"api/projects", content);
            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData(15)]
        public async Task DeleteTest(int projId)
        {
            var response = await Fixture.Client.DeleteAsync($"api/projects/{projId}");
            Assert.Throws<HttpRequestException>(() => response.EnsureSuccessStatusCode());
        }

        [Theory]
        [InlineData(15)]
        public async Task PutTest(int projId)
        {
            var content = GetSampleProject(projId);

            var response = await Fixture.Client.PostAsync($"api/projects/{projId}", content);
            response.EnsureSuccessStatusCode();
        }

        private static StringContent GetSampleProject(int projId)
        {
            var proj = new ProjectModel()
            {
                Id = projId,
                Title = "Project 1",
                Detail = "Detail for Project 1",
                ImageUrl = "http://google.com",
                ProjectType = 1,
                Tasks = new List<TaskModel>()
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(proj),
                Encoding.UTF8,
                "application/json");
            return content;
        }
    }
}