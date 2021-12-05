using Microsoft.AspNetCore.Identity;
using System;

namespace EveryoneCourses.ClassLibrary.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime JoinDate { get; set; }



    }
}