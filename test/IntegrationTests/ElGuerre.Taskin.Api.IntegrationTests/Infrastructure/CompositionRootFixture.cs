// ---------------------------------------------------------------------------------
// <copyright file="CompositionRootFixture.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using AutoMapper;
using ElGuerre.Taskin.Api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace ElGuerre.Taskin.Api.IntegrationTests
{
    public class CompositionRootFixture
    {
        protected readonly IMapper _mapper;
        private readonly TestServer _server;
        public HttpClient Client { get; }

        public CompositionRootFixture()
        {
            //ServiceCollectionExtensions.UseStaticRegistration = false;

            //// Initialize mapper
            //_mapper = new Mapper(
            //    new MapperConfiguration(
            //        configure => {
            //            configure.AddProfile<ProjectProfile>();
            //            configure.AddProfile<TaskProfile>();
            //        }
            //    ));


            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();
        }

        ~CompositionRootFixture()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}
