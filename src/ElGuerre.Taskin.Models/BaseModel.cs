// ---------------------------------------------------------------------------------
// <copyright file="BaseModel.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using Newtonsoft.Json;

namespace ElGuerre.Taskin.Models
{
    public class BaseModel<Tkey> : IModel<Tkey>
    {
        [JsonProperty]
        public virtual Tkey Id { get; set; }
    }
}
