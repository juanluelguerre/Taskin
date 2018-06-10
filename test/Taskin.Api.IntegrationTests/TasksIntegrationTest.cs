// ---------------------------------------------------------------------------------
// <copyright file="UnitTest1.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ElGuerre.Taskin.Api.IntegrationTests
{
    public class TasksIntegrationTest : BaseTest
    {
        public TasksIntegrationTest(CompositionRootFixture fixture) : base(fixture)
        {
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

        }

        [Fact(Skip = "Not implemented yet")]
        public async Task PostTest()
        {

        }

        [Fact(Skip = "Not implemented yet")]
        public async Task PutTest()
        {

        }

        [Theory(Skip = "Not implemented yet")]
        [InlineData(15, 15)]
        public async Task DeleteTest(int projectId, int taskId)
        {

        }
    }
}
