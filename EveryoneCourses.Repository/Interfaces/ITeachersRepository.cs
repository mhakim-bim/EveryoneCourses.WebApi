using System.Collections.Generic;
using System.Threading.Tasks;
using EveryoneCourses.ClassLibrary.Models;

namespace EveryoneCourses.Repository.Interfaces
{
    public interface ITeachersRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        Task<Teacher> CreateTeacher(Teacher newTeacher);
    }
}