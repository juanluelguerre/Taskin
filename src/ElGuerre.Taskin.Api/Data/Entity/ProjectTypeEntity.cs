// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElGuerre.Taskin.Api.Data.Entity
{
    public enum ProjectType
    {
        Default = 0,
        Private = 1,
        Work = 2,
        Sport = 3,
        Travel = 4,

        // Add more if need it
        Others = 9
    }

    [Table("ProjectTypes")]
    public class ProjectTypeEntity : BaseEntity<int>
    {
        [Required]
        public ProjectType Value { get; set; }
    }
}
