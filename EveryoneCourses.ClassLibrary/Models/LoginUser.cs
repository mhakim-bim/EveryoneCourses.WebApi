using System.ComponentModel.DataAnnotations;

namespace EveryoneCourses.ClassLibrary.Models
{
    public class LoginUser
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}