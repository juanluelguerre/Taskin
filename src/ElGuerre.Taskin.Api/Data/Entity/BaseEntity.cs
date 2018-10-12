// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace ElGuerre.Taskin.Api.Data.Entity
{
    public class BaseEntity<Tkey> : IEntity<Tkey>
    {
        [Key]
        public virtual Tkey Id { get; set; }
    }
}
