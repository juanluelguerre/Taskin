// ---------------------------------------------------------------------------------
// <copyright file="Startup.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.OneRest.Taskin.Api.Core.Mvc.Filters;
using ElGuerre.OneRest.Taskin.Api.Core.Mvc.Middlewares;
using ElGuerre.OneRest.Taskin.Api.Data;
using ElGuerre.OneRest.Taskin.Api.Data.Repository;
using ElGuerre.OneRest.Taskin.Api.Models;
using ElGuerre.OneRest.Taskin.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;
using Swashbuckle.AspNetCore.Swagger;

namespace ElGuerre.OneRest.Taskin.Api
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
            services.AddMvc();
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

            services.AddScoped<IDbContextSeed, DataContext>();

            // Add custom Services, repositories and so on
            // services.AddScoped<IController, XController>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectService, ProjectService>();

            // Add Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Info
                    {
                        Version = "v1",
                        Title = "OneRest API",
                        Description = "API to expose Taskin logic",
                        TermsOfService = "Copyright (c) elGuerre.com. All rights reserved."
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
                app.UseExceptionMiddleware();
                app.UseExceptionHandler();
            }

            loggerFactory.AddNLog();
            // app.AddNLogWeb();

            app.UseMvc();
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod().AllowCredentials());
       
            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "OneRest V1");
               });

            conextSeed.Seed();

            MappingConfig.RegisterMaps();
        }
    }
}
