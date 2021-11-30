using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EveryoneCourses.ClassLibrary.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public int TotalNumberOfStudents { get; set; }



        public virtual ICollection<Course> Courses { get; set; }

    }
}