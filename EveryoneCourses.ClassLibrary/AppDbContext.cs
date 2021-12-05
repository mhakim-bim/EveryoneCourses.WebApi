using EveryoneCourses.ClassLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace EveryoneCourses.ClassLibrary
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<Course> Courses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>().HasData(
                new Course()
                {
                    CourseId = 1,
                    CourseName = "C# Basics",
                    NumberOfStudents = 0,
                    Rating = 0,
                    CreatedDate = DateTime.Today,
                    TeacherId = 1,

                }, new Course()
                {
                    CourseId = 2,
                    CourseName = "C# Advanced",
                    NumberOfStudents = 0,
                    Rating = 0,
                    CreatedDate = DateTime.Today,
                    TeacherId = 2
                });

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher()
                {
                    TeacherId = 1,
                    Name = "Mohamed Elhakim",
                    Rating = 0,
                    TotalNumberOfStudents = 0
                }, new Teacher()
                {
                    TeacherId = 2,
                    Name = "Mohamed Nasser",
                    Rating = 0,
                    TotalNumberOfStudents = 0
                });
        }
    }
}