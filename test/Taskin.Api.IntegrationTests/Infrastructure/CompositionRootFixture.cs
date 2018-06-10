﻿// ---------------------------------------------------------------------------------
// <copyright file="CompositionRootFixture.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.Taskin.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace ElGuerre.Taskin.Api.IntegrationTests
{
    public class CompositionRootFixture
    {
        private readonly TestServer _server;
        public HttpClient Client { get; }

        public CompositionRootFixture()
        {
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