using System;
using System.Threading.Tasks;
using EveryoneCourses.ClassLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EveryoneCoursers.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        
        
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterUser registerUser)
        {
            try
            {
                var userWithSameEmail = await _userManager.FindByEmailAsync(registerUser.EmailAddress);
                if (userWithSameEmail != null)
                    throw new Exception("User With Same Email does exist");

                var user = new AppUser()
                {
                    Email = registerUser.EmailAddress

                };
                
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}