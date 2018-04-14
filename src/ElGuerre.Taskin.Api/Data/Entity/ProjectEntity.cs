// ---------------------------------------------------------------------------------
// <copyright file="ProjectEntity.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElGuerre.Taskin.Api.Data.Entity
{
    public class ProjectEntity : BaseEntity<int>
    {
        [Required]
        public string Title { get; set; }
        public string Detail { get; set; }
        public string ImageUrl { get; set; }
        public ProjectTypeEntity ProjectType { get; set; }
       
        public ICollection<TaskEntity> Tasks {get; set;}
    }
}
