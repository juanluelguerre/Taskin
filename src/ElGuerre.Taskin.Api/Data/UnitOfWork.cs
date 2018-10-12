// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace ElGuerre.Taskin.Api.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IServiceProvider _serviceProviderAccessor;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _serviceProviderAccessor = serviceProvider;
        }

        private DbContext Context => _serviceProviderAccessor.GetService(typeof(DbContext)) as DbContext;

        private IDbContextTransaction Tx => Context.Database.CurrentTransaction;

        public void BeginTransaction()
        {
            if (Tx == null)
            {
                Context.Database.BeginTransaction();
            }
        }

        public virtual void Commit()
        {

            Context.SaveChanges();


            if (Tx != null)
            {
                Tx.Commit();
            }
        }

        public virtual void Rollback()
        {
            if (Tx != null)
            {
                Tx.Rollback();
            }
        }
    }
}