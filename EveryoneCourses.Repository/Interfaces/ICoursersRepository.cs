using System.Collections.Generic;
using System.Threading.Tasks;
using EveryoneCourses.ClassLibrary.Models;

namespace EveryoneCourses.Repository.Interfaces
{
    public interface ICoursersRepository
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
    }
}