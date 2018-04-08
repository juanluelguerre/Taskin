// ---------------------------------------------------------------------------------
// <copyright file="IEntity.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
namespace ElGuerre.OneRest.Taskin.Api.Data.Entity
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}