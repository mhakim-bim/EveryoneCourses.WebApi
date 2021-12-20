using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EveryoneCourses.ClassLibrary.Models
{
    public class RegisterUser
    {
        public string FullName { get; set; }
        
        [EmailAddress]
        public string EmailAddress { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }
    }
}