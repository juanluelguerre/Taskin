// ---------------------------------------------------------------------------------
// <copyright file="BaseModel.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
namespace ElGuerre.Taskin.Models
{
    public class BaseModel<Tkey> : IModel<Tkey>
    {
        public virtual Tkey Id { get; set; }
    }
}
