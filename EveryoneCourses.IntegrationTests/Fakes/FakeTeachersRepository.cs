using System.Collections.Generic;
using System.Threading.Tasks;
using EveryoneCourses.ClassLibrary.Models;
using EveryoneCourses.Repository.Interfaces;

namespace EveryoneCourses.IntegrationTests.Fakes
{
    public class FakeTeachersRepository : ITeachersRepository
    {

        private List<Teacher> _teachers;

        public FakeTeachersRepository()
        {
            _teachers = new List<Teacher>() {
                new Teacher()
                {
                    TeacherId = 1,
                    Name = "Teacher 1",
                    Rating = 4,
                    TotalNumberOfStudents = 27
                },
                new Teacher()
                {
                    TeacherId = 2,
                    Name = "Teacher 2",
                    Rating = 4.5m,
                    TotalNumberOfStudents = 53
                }
            };;
        }

        public Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            
            return Task.FromResult<IEnumerable<Teacher>>(_teachers);
        }

        public Task<Teacher> CreateTeacher(Teacher newTeacher)
        {
            _teachers.Add(newTeacher);
            return Task.FromResult(newTeacher);
        }
    }
}