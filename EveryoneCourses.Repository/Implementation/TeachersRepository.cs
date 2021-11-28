using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EveryoneCourses.ClassLibrary;
using EveryoneCourses.ClassLibrary.Models;
using EveryoneCourses.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            return await _appDbContext.Teachers.ToListAsync();
        }

        public async Task<Teacher> CreateTeacher(Teacher newTeacher)
        {
            var teacher =  _appDbContext.Teachers.Add(newTeacher);
            await _appDbContext.SaveChangesAsync();
            return teacher.Entity;
        }
    }
}