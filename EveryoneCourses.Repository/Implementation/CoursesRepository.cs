using System.Collections.Generic;
using System.Threading.Tasks;
using EveryoneCourses.ClassLibrary;
using EveryoneCourses.ClassLibrary.Models;
using EveryoneCourses.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EveryoneCourses.Repository.Implementation
{
    public class CoursesRepository : ICoursersRepository
    {
        private readonly AppDbContext _appDbContext;

        public CoursesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _appDbContext.Courses.ToListAsync();
        }
    }
}