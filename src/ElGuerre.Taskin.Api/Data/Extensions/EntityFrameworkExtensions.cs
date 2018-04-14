// ---------------------------------------------------------------------------------
// <copyright file="EntityFrameworkExtensions.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ElGuerre.Taskin.Api.Data
{
    public static class EntityFrameworkExtensions
    {
        public static void AddEntityFramework<TContext>(this IServiceCollection services, 
            Action<DbContextOptionsBuilder> optionsAction = null) where TContext : DbContext
        {
            services.AddDbContext<TContext>(optionsAction, ServiceLifetime.Scoped);
            services.Add(new ServiceDescriptor(typeof(DbContext), typeof(TContext), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IUnitOfWork), typeof(UnitOfWork), ServiceLifetime.Scoped));
        }    
    }
}
