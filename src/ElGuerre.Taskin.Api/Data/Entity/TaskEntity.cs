// ---------------------------------------------------------------------------------
// <copyright file="TaskEntity.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace ElGuerre.OneRest.Taskin.Api.Data.Entity
{
    public enum TaskPriority
    {
        Normal = 0,
        Low = -1,
        Hight = 1
    }

    public class TaskEntity : BaseEntity<int>
    {
        [Required]
        public string Detail { get; set; }
        public TaskPriority Priority { get; set; }
        public int Effort { get; set; }
        public TaskTypeEntity TaskType { get; set; }
        // public ProjectEntity Project { get; set;}
    }
}
