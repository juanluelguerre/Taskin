// ---------------------------------------------------------------------------------
// <copyright file="TaskTypeEntity.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace ElGuerre.Taskin.Api.Data.Entity
{
    public enum TaskType
    {
        ToDo = 0,
        CallTo = 1,
        EmailTo = 2,
        TalkTo = 3,
        LunchWith = 4,
        Holidays = 5,
        Travel = 6,
        Read = 7,
        Sport = 8,
        LinkTo = 9,

        // Add more if need it

        Others = 20
    }

    public class TaskTypeEntity : BaseEntity<int>
    {
        [Required]
        public TaskType Value { get; set; }
    }
}
