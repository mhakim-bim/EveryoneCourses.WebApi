using EveryoneCourses.ClassLibrary;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;


namespace EveryoneCourses.UnitTests
{
    public class TeacherRepositoryTests
    {
        private DbContext _context;

        [SetUp]
        public void Setup()
        {
            var connectionString = "server=.; database=TestEveryoneDb;Trusted_Connection=True;";
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(connectionString);
            var options = builder.Options;

            _context = new DbContext(options);
            
            _context.Database.EnsureCreated(); 
        }

        [Test]
        public void Test1()
        {
            
        }
    }
}