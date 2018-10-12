// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.IO;

namespace ElGuerre.Taskin.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseIISIntegration()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((context, configBuilder) =>
                {
                    configBuilder
                        .SetBasePath(context.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true)
                        .AddEnvironmentVariables();

                    Log.Logger = new LoggerConfiguration()
                       .ReadFrom.Configuration(configBuilder.Build())
                       .CreateLogger();
                })
                .ConfigureLogging((context, loggingBuilder) =>
                {
                    //loggingBuilder.ClearProviders();
                    //loggingBuilder.AddDebug();
                    //loggingBuilder.AddConsole();
                   
                    loggingBuilder.AddSerilog(dispose: true);

                    //loggingBuilder.AddSerilog
                    //(
                    //    new LoggerConfiguration()
                    //        .MinimumLevel.Warning()
                    //        .WriteTo.Console()
                    //        .CreateLogger()

                    //);
                })
                //.UseSerilog((context, config) =>
                //{
                //    var section = context.Configuration.GetSection("Serilog");
                //    config.ReadFrom.ConfigurationSection(section);
                //})
                // .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
