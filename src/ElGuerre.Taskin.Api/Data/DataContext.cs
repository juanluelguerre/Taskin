// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using ElGuerre.Taskin.Api.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ElGuerre.Taskin.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        // public DbSet<ProjectEntity> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProjectEntity>();
            modelBuilder.Entity<TaskEntity>();
            modelBuilder.Entity<TaskTypeEntity>();
            modelBuilder.Entity<ProjectTypeEntity>();

            modelBuilder.Entity<ProjectEntity>().HasMany(p => p.Tasks);


            //modelBuilder.Entity<ProjectEntity>()
            //    .OwnsOne(p => p.ProjectType)
            //    .HasForeignKey(p => p.Id)
            //    .HasConstraintName("FK_Project_ProjectType");

            //modelBuilder.Entity<TaskEntity>()
            //    .OwnsOne(t => t.TaskType)
            //    .HasForeignKey(t => t.Id)
            //    .HasConstraintName("FK_Task_TaskType");


            Seed(modelBuilder);

        }

        void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectTypeEntity>().HasData(
                new ProjectTypeEntity() { Id = 1, Value = ProjectType.Default },
                new ProjectTypeEntity() { Id = 2,  Value = ProjectType.Private },
                new ProjectTypeEntity() { Id = 3, Value = ProjectType.Work },
                new ProjectTypeEntity() { Id = 4, Value = ProjectType.Sport },
                new ProjectTypeEntity() { Id = 5, Value = ProjectType.Travel },
                new ProjectTypeEntity() { Id = 6, Value = ProjectType.Others }
            );

            modelBuilder.Entity<TaskTypeEntity>().HasData( 
                new TaskTypeEntity() { Id = 1, Value = TaskType.ToDo },
                new TaskTypeEntity() { Id = 2, Value = TaskType.CallTo },
                new TaskTypeEntity() { Id = 3, Value = TaskType.EmailTo },
                new TaskTypeEntity() { Id = 4, Value = TaskType.Holidays },
                new TaskTypeEntity() { Id = 5, Value = TaskType.LinkTo },
                new TaskTypeEntity() { Id = 6, Value = TaskType.LunchWith },
                new TaskTypeEntity() { Id = 7, Value = TaskType.Read },
                new TaskTypeEntity() { Id = 8, Value = TaskType.Sport },
                new TaskTypeEntity() { Id = 9, Value = TaskType.TalkTo },
                new TaskTypeEntity() { Id = 10, Value = TaskType.Travel },
                new TaskTypeEntity() { Id = 11, Value = TaskType.Others }
            );

            var defaultProjectType = new ProjectTypeEntity() { Id = 1, Value = ProjectType.Default };
            // Use Anonymous type to relate with ProjectId.
            modelBuilder.Entity<ProjectEntity>().HasData(
                new { Id = 1, Title = "Project 1", Detail = "Detail for Project 1", ProjectTypeId = 1 },
                new { Id = 2, Title = "Project 2", Detail = "Detail for Project 2", ProjectTypeId = 1 },
                new { Id = 3, Title = "Project 3", Detail = "Detail for Project 3", ProjectTypeId = 1 }
            );
                
            var defaultTaskType = new TaskTypeEntity() { Id = 1, Value = TaskType.ToDo };

            // Use Anonymous type to relate with ProjectId.
            modelBuilder.Entity<TaskEntity>().HasData(
                new { Id = 1, ProjectId = 1, Detail = "Task 1", Priority = TaskPriority.Normal, TaskTypeId = 1, Effort = 0 },
                new { Id = 2, ProjectId = 1, Detail = "Task 2", Priority = TaskPriority.Low,    TaskTypeId = 1, Effort = 1 },
                new { Id = 3, ProjectId = 1, Detail = "Task 3", Priority = TaskPriority.Hight,  TaskTypeId = 1, Effort = 3 },
                new { Id = 4, ProjectId = 2, Detail = "Task 4", Priority = TaskPriority.Normal, TaskTypeId = 1, Effort = 0 },
                new { Id = 5, ProjectId = 2, Detail = "Task 5", Priority = TaskPriority.Low,    TaskTypeId = 1, Effort = 1 },
                new { Id = 6, ProjectId = 2, Detail = "Task 6", Priority = TaskPriority.Hight,  TaskTypeId = 1, Effort = 3 }
               );

            // SaveChanges();
        }
    }
}
