// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using ElGuerre.Taskin.Blazor;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;

namespace ElGuerre.Taskin.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddResponseCompression(options =>
            //{
            //    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
            //    {
            //        MediaTypeNames.Application.Octet,
            //        WasmMediaTypeNames.Application.Wasm,
            //    });
            //});

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials());
            //});
        }

        public void Configure(IBlazorApplicationBuilder app)
        //public void Configure(IApplicationBuilder app)
        {
            // app.UseCors("CorsPolicy");
            app.AddComponent<App>("app");
        }
    }
}
