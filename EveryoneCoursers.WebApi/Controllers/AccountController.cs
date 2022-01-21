using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EveryoneCourses.ClassLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace EveryoneCoursers.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private IConfiguration _config;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
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
                    Email = registerUser.EmailAddress,
                    EmailConfirmed = false,
                    JoinDate = DateTime.Now,
                    UserName = registerUser.EmailAddress,
                    FirstName = registerUser.FirstName,
                    LastName = registerUser.LastName,
                    NormalizedUserName = registerUser.FullName
                };
                
                var result = await _userManager.CreateAsync(user, registerUser.Password);
                return Ok(result.Succeeded);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
            var user = await _userManager.FindByEmailAsync(loginUser.Email);
            if (user == null)
                throw new Exception("User With given email not found");
            var signInResult = await _signInManager.PasswordSignInAsync(user,loginUser.Password,true,false);
            if (!signInResult.Succeeded)
                return BadRequest();
            
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                this._config["Tokens:Issuer"],
                this._config["Tokens:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: credentials                            
            );
 
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
            

        }
    }
}