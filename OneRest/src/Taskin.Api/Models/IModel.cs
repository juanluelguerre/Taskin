// ---------------------------------------------------------------------------------
// <copyright file="IModel.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
namespace ElGuerre.OneRest.Taskin.Api.Models
{
    public interface IModel<Tkey>
    {
        Tkey Id { get; set; }
    }
}
