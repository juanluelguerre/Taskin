// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using ElGuerre.Taskin.Api;
using Microsoft.AspNetCore.Blazor.Hosting;

namespace ElGuerre.Taskin.Blazor
{
    public class Program
    {
        //static void Main(string[] args)
        //{
        //    var serviceProvider = new BrowserServiceProvider(services =>
        //    {
        //        // TODO: Add any custom services here. 
        //        // Sample: services.Add(ServiceDescriptor.Singleton<IDataAccess, DataAccess>());
        //    });

        //    new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        //}

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }
}
