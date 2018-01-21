// ---------------------------------------------------------------------------------
// <copyright file="ProjectModel.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElGuerre.OneRest.Taskin.Api.Models
{
    public class ProjectModel : BaseModel<int>
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public string ImageUrl { get; set; }
        public int ProjectType { get; set; }
    }
}
