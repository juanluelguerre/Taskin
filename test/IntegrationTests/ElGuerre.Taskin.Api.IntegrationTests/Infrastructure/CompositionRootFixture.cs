// ---------------------------------------------------------------------------------
// <copyright file="CompositionRootFixture.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
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
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Test")
                .ConfigureAppConfiguration((context, configBuilder) =>
                {
                    configBuilder
                        .SetBasePath(context.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddEnvironmentVariables();
                })
                .UseStartup<Startup>()); 
            
            Client = _server.CreateClient();
        }

        ~CompositionRootFixture()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}
