using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EveryoneCourses.ClassLibrary.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        public string CourseName { get; set; }


        [ForeignKey("Teacher")]
        [Required]
        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public DateTime CreatedDate { get; set; }
        
        [Column(TypeName = "decimal(2,2)")]
        public decimal Rating { get; set; }
        public int NumberOfStudents { get; set; }
    }
}