using EveryoneCourses.ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EveryoneCourses.ClassLibrary
{
    public class AppDbContext : DbContext 
    {

        public DbSet<Course> Courses { get; set; }
        
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
    }
}