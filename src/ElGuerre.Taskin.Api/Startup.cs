<<<<<<< HEAD
﻿// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using AutoMapper;
using ElGuerre.Taskin.Api.Core.Mvc.Filters;
using ElGuerre.Taskin.Api.Core.Mvc.Middlewares;
using ElGuerre.Taskin.Api.Data;
using ElGuerre.Taskin.Api.Data.Repository;
using ElGuerre.Taskin.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace ElGuerre.Taskin.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .WithMethods(
                        "GET",
                        "POST",
                        "PUT",
                        "DELETE",
                        "OPTIONS")
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });


            // Need typeof(Startup) to avoid error on tests executions doubt to no API assemby found.
            services.AddAutoMapper(typeof(Startup));

            // Add bellow statement to use HTTPS o a better option, set environment varibble ASPNETCORE_HTTPS_PORT 
            // services.AddHttpsRedirection(options => options.HttpsPort = 5003);

            //services.AddResponseCompression(options =>
            //{
            //    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
            //    {
            //        MediaTypeNames.Application.Octet,
            //        // WasmMediaTypeNames.Application.Wasm,
            //    });
            //});

            services.AddSingleton(Configuration);
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
            
            //services.AddScoped<ILogProvider>(s => new LogProvider(Configuration));
            //services.AddScoped<ApplicationBlocks.Logging.ILogger, ApplicationBlocks.Logging.Logger>();

            // services.AddSingleton<ILogger, >

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

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseMvc();

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
        }
    }
}
=======
﻿// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using AutoMapper;
using ElGuerre.Taskin.Api.Core.Mvc.Filters;
using ElGuerre.Taskin.Api.Core.Mvc.Middlewares;
using ElGuerre.Taskin.Api.Data;
using ElGuerre.Taskin.Api.Data.Repository;
using ElGuerre.Taskin.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace ElGuerre.Taskin.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .WithMethods(
                        "GET",
                        "POST",
                        "PUT",
                        "DELETE",
                        "OPTIONS")
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });


            // Need typeof(Startup) to avoid error on tests executions doubt to no API assemby found.
            services.AddAutoMapper(typeof(Startup));

            // Add bellow statement to use HTTPS o a better option, set environment varibble ASPNETCORE_HTTPS_PORT 
            // services.AddHttpsRedirection(options => options.HttpsPort = 5003);

            //services.AddResponseCompression(options =>
            //{
            //    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
            //    {
            //        MediaTypeNames.Application.Octet,
            //        // WasmMediaTypeNames.Application.Wasm,
            //    });
            //});

            services.AddSingleton(Configuration);
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
            
            //services.AddScoped<ILogProvider>(s => new LogProvider(Configuration));
            //services.AddScoped<ApplicationBlocks.Logging.ILogger, ApplicationBlocks.Logging.Logger>();

            // services.AddSingleton<ILogger, >

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

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseMvc();

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
        }
    }
}
>>>>>>> develop
