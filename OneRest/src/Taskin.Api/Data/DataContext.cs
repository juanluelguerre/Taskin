﻿// ---------------------------------------------------------------------------------
// <copyright file="DataContext.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.OneRest.Taskin.Api.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace ElGuerre.OneRest.Taskin.Api.Data
{
    public class DataContext : DbContext, IDbContextSeed
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        // public DbSet<ProjectEntity> ProjectEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProjectEntity>();
            modelBuilder.Entity<TaskEntity>();
            modelBuilder.Entity<TaskTypeEntity>();
            modelBuilder.Entity<ProjectTypeEntity>();

            modelBuilder.Entity<ProjectEntity>().HasMany(p => p.Tasks);

            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.Id)
                .HasConstraintName("FK_Project_Task");

            //modelBuilder.Entity<ProjectEntity>()
            //    .OwnsOne(p => p.ProjectType)
            //    .HasForeignKey(p => p.Id)
            //    .HasConstraintName("FK_Project_ProjectType");

            //modelBuilder.Entity<TaskEntity>()
            //    .OwnsOne(t => t.TaskType)
            //    .HasForeignKey(t => t.Id)
            //    .HasConstraintName("FK_Task_TaskType");
        }

        public void Seed()
        {
            var defaultProjectType = new ProjectTypeEntity() { Value = ProjectType.Default };
            Add(defaultProjectType); // Default
            Add(new ProjectTypeEntity() { Value = ProjectType.Private });
            Add(new ProjectTypeEntity() { Value = ProjectType.Work });
            Add(new ProjectTypeEntity() { Value = ProjectType.Sport });
            Add(new ProjectTypeEntity() { Value = ProjectType.Travel });
            Add(new ProjectTypeEntity() { Value = ProjectType.Others });

            var defaultTaskType = new TaskTypeEntity() { Value = TaskType.ToDo };
            Add(defaultTaskType);
            Add(new TaskTypeEntity() { Value = TaskType.CallTo });
            Add(new TaskTypeEntity() { Value = TaskType.EmailTo });
            Add(new TaskTypeEntity() { Value = TaskType.Holidays });
            Add(new TaskTypeEntity() { Value = TaskType.LinkTo });
            Add(new TaskTypeEntity() { Value = TaskType.LunchWith });
            Add(new TaskTypeEntity() { Value = TaskType.Read });
            Add(new TaskTypeEntity() { Value = TaskType.Sport });
            Add(new TaskTypeEntity() { Value = TaskType.TalkTo });
            Add(new TaskTypeEntity() { Value = TaskType.Travel });
            Add(new TaskTypeEntity() { Value = TaskType.Others });

            ProjectEntity p1 = new ProjectEntity() { Title = "Project 1", Detail = "Detail for Project 1", ProjectType = defaultProjectType };
            var tasks = new TaskEntity[]
            {
                new TaskEntity() { Project = p1, Detail = "Task 1", Priority = TaskPriority.Normal, TaskType = defaultTaskType, Effort = 0 },
                //new TaskEntity() { Project = p1, Detail = "Task 2", Priority = TaskPriority.Low, TaskType = defaultTaskType, Effort = 0 },
                //new TaskEntity() { Project = p1, Detail = "Task 3", Priority = TaskPriority.Hight, TaskType = defaultTaskType, Effort = 0 }

            };

           // AttachRange(tasks);

            p1.Tasks = tasks;
            Add(p1);

            SaveChanges();




            // TODO: Pendiente inluir: http://localhost:5002/api/projects/1/tasks


        }
    }
}
