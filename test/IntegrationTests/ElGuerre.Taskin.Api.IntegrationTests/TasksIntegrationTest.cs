// ---------------------------------------------------------------------------------
// <copyright file="UnitTest1.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using AutoMapper;
using ElGuerre.Taskin.Api.Models;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ElGuerre.Taskin.Api.IntegrationTests
{
    public class TasksIntegrationTest : BaseTest
    {
        public TasksIntegrationTest(CompositionRootFixture fixture) : base(fixture)
        {
            // AutoMapper.Mapper.AssertConfigurationIsValid();
            // AutoMapper.Mapper.Reset();


            // https://stackoverflow.com/questions/40275195/how-to-setup-automapper-in-asp-net-core
            //var profile = new TaskProfile();

            //var config = new MapperConfiguration(ex => ex.AddProfile(profile));
            //var mapper = new Mapper(config);

            //(mapper as IMapper).ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Fact]
        public async Task GetAllTest()
        {
            int projId = 1;
            var response = await Fixture.Client.GetAsync($"/api/project/{projId}/tasks");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(Skip = "Not implemented yet")]
        public async Task GetTest()
        {
            await Task.CompletedTask;
        }

        [Fact(Skip = "Not implemented yet")]
        public async Task PostTest()
        {
            await Task.CompletedTask;
        }

        [Fact(Skip = "Not implemented yet")]
        public async Task PutTest()
        {
            await Task.CompletedTask;
        }

        [Theory(Skip = "Not implemented yet")]
        [InlineData(15, 15)]
        public async Task DeleteTest(int projectId, int taskId)
        {
            await Task.CompletedTask;
        }
    }
}
