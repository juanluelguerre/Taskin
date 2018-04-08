// ---------------------------------------------------------------------------------
// <copyright file="IModel.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
namespace ElGuerre.Taskin.Models
{
    public interface IModel<Tkey>
    {
        Tkey Id { get; set; }
    }
}
