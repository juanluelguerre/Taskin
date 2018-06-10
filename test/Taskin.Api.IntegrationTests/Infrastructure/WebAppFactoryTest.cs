// ---------------------------------------------------------------------------------------------------
// <copyright file="WebAppFactoryTest" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------------------------
// Reference: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-2.1
// ---------------------------------------------------------------------------------------------------
using ElGuerre.Taskin.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace ElGuerre.OneRest.Taskin.Api.IntegrationTests
{
    class WebAppFactoryTest : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();


                // TODO: Add more services customization

            });
        }
    }
}
