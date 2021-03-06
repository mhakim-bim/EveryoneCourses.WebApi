using EveryoneCourses.ClassLibrary;
using EveryoneCourses.ClassLibrary.Models;
using EveryoneCourses.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EveryoneCourses.Repository.Implementation
{
    public class TeachersRepository : ITeachersRepository
    {
        private readonly AppDbContext _appDbContext;

        public TeachersRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            return await _appDbContext.Teachers
                .AsNoTracking()
                .Include(t => t.Courses)
                .ToListAsync();
        }

        public async Task<Teacher> CreateTeacher(Teacher newTeacher)
        {
            var teacher = _appDbContext.Teachers.Add(newTeacher);
            await _appDbContext.SaveChangesAsync();
            return teacher.Entity;
        }
    }
}