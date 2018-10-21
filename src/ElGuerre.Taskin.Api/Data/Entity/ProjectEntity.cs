// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElGuerre.Taskin.Api.Data.Entity
{
    [Table("Projects")]
    public class ProjectEntity : BaseEntity<int>
    {
        [Required]
        public string Title { get; set; }
        public string Detail { get; set; }
        public string ImageUrl { get; set; }
        [Column("ProyectType")]
        public ProjectTypeEntity ProjectType { get; set; }
       
        public ICollection<TaskEntity> Tasks {get; set;}
    }
}
