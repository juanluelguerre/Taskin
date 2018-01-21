﻿// ---------------------------------------------------------------------------------
// <copyright file="ProjectTypeEntity.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace ElGuerre.OneRest.Taskin.Api.Data.Entity
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

    public class ProjectTypeEntity : BaseEntity<int>
    {
         [Required]
        public ProjectType Value { get; set; }
    }
}
