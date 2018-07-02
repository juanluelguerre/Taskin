// ---------------------------------------------------------------------------------
// <copyright file="Startup.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.ApplicationBlocks.Logging.Providers;
using ElGuerre.Taskin.Api.Core.Mvc.Filters;
using ElGuerre.Taskin.Api.Core.Mvc.Middlewares;
using ElGuerre.Taskin.Api.Data;
using ElGuerre.Taskin.Api.Data.Repository;
using ElGuerre.Taskin.Api.Models;
using ElGuerre.Taskin.Api.Services;
using Microsoft.AspNetCore.Blazor.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Linq;
using System.Net.Mime;

namespace ElGuerre.Taskin.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

            // Add bellow statement to use HTTPS o a better option, set environment varibble ASPNETCORE_HTTPS_PORT 
            //  services.AddHttpsRedirection(options => options.HttpsPort = 5003);

            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    MediaTypeNames.Application.Octet,
                    WasmMediaTypeNames.Application.Wasm,
                });
            });

            services.AddSingleton(Configuration);
            services.AddCors();
            services.Configure<AppSettings>(Configuration);

            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            if (Configuration.GetValue<bool>("UseTest"))
            {
                services.AddEntityFramework<DataContext>(
                  opt => opt.UseInMemoryDatabase("Taskin")
                            .ConfigureWarnings(cw => cw.Ignore(InMemoryEventId.TransactionIgnoredWarning)));
            }
            else
            {
                services.AddEntityFramework<DataContext>(
                    opt => opt.UseSqlServer(Configuration.GetConnectionString("Taskin")));
            }

            // services.AddScoped<IDbContextSeed, DataContext>();
            services.AddScoped<DataContext>();


            // services.AddScoped<ILogProvider>(s => new FileProvider(Path.Combine(Directory.GetCurrentDirectory(), "trace.log")));
            services.AddScoped<ILogProvider>(s => new LogProvider(Configuration));
            services.AddScoped<ApplicationBlocks.Logging.ILogger, ApplicationBlocks.Logging.Logger>();

            // Add custom Services, repositories and so on
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskService, TaskService>();

            // Add Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Info
                    {
                        Version = "v1",
                        Title = "Taskin API",
                        Description = "API to expose Taskin logic",
                        TermsOfService = "https://github.com/juanluelguerre/Taskin/blob/master/LICENSE"
                    }
                );
                // Generate Tags document sections in Swagger .json
                options.DocumentFilter<ApplySwaggerDocumentFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseExceptionMiddleware();
            }
            else
            {
                app.UseHsts();
                // app.UseExceptionHandler();
            }

            // loggerFactory.AddNLog();
            // app.AddNLogWeb();

            app.UseHttpsRedirection();
            app.UseMvc();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(name: "default", template: "{controller}/{action}/{id?}");
            //});

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "Taskin V1");
               });

            if (Configuration.GetValue<bool>("UseTest"))
            {
                var context = app.ApplicationServices.GetService<DataContext>();
                context.Seed();
            }

            MappingConfig.RegisterMaps();
            
            // app.UseBlazor<ElGuerre.Taskin.Blazor.Program>();
        }
    }
}
