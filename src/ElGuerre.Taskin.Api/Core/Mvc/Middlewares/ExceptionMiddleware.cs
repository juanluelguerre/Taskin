// ---------------------------------------------------------------------------------
// <copyright file="ExceptionMiddleware.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ElGuerre.OneRest.Taskin.Api.Core.Mvc.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostingEnvironment _env;
        // private readonly ObjectResultExecutor _oex;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IHostingEnvironment env)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = loggerFactory?.CreateLogger<ExceptionMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e, _env, _logger);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, IHostingEnvironment env, ILogger logger)
        {
            var message = String.Empty;
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            switch (exception)
            {
                // TODO: Change to correct message
                case ServiceException ex:
                    code = HttpStatusCode.BadRequest;
                    message = $"Service Exception: {ex.Message}";
                    break;
                case DataException ex:
                    code = HttpStatusCode.BadRequest;
                    message = $"Data Exception {ex.Message}"; 
                    break;
                case Exception ex:
                    code = HttpStatusCode.InternalServerError;
                    message = $"Exception: {ex.Message}";
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    message = $"Unexpected Error. {exception.Message}";
                    break;
            }

            // context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            // logger.LogError(exception, message);
            logger.LogError(message);
            if (env.IsDevelopment()) logger.LogDebug(exception.StackTrace);
            //logger.Information(exception, message);

            var result = new ApiResponse()
            {
                IsValid = false,
                ErrorCode = "0000",
                ErrorMessage = env.IsDevelopment() ? $"{message}{exception.StackTrace}" : message
            }.ToJson();

            return context.Response.WriteAsync(result);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
