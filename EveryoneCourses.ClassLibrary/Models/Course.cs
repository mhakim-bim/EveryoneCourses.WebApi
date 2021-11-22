using System;

namespace EveryoneCourses.ClassLibrary.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public Teacher Teacher { get; set; }

        public DateTime CreatedDate { get; set; }
        public decimal Rating { get; set; }
        public int NumberOfStudents { get; set; }
    }
}