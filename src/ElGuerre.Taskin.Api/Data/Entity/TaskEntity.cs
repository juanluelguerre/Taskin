// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElGuerre.Taskin.Api.Data.Entity
{
    public enum TaskPriority
    {
        Normal = 0,
        Low = -1,
        Hight = 1
    }

    [Table("Tasks")]
    public class TaskEntity : BaseEntity<int>
    {
        //[Required]
        //public int ProjectId { get; set; }

        [ForeignKey("BlogForeignKey")]
        public ProjectEntity Project {get; set; }

        public string Detail { get; set; }
        public TaskPriority Priority { get; set; }
        public int Effort { get; set; }
        [Column("TaskType")]
        public TaskTypeEntity TaskType { get; set; }
        // public ProjectEntity Project { get; set;}
    }
}
