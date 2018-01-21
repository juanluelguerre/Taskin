// ---------------------------------------------------------------------------------
// <copyright file="TaskModel.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.OneRest.Taskin.Api.Models;

namespace ElGuerre.OneRest.Taskin.Api.Data.Entity
{
    public class TaskModel : BaseModel<int>
    {
        public string Detail { get; set; }
        public int Priority { get; set; }
        public int Effort { get; set; }
        public int TaskType { get; set; }
    }
}
