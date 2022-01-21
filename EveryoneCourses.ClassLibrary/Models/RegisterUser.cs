using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EveryoneCourses.ClassLibrary.Models
{
    public class RegisterUser
    {

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        
        [EmailAddress]
        public string EmailAddress { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }
    }
}