// ---------------------------------------------------------------------------------
// <copyright file="ProjectModel.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using System.Collections.Generic;

namespace ElGuerre.Taskin.Models
{
    public class ProjectModel : BaseModel<int>
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public string ImageUrl { get; set; }
        public int ProjectType { get; set; }
        public ICollection<TaskModel> Tasks {get; set;}
    }
}
