using EveryoneCourses.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EveryoneCourses.ClassLibrary.Models;
using Microsoft.AspNetCore.Authorization;


namespace EveryoneCoursers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeachersRepository _teachersRepository;

        public TeachersController(ITeachersRepository teachersRepository)
        {
            _teachersRepository = teachersRepository;
        }


        [HttpGet("getAllTeachers")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllTeachers()
        {
            try
            {
                var result = await _teachersRepository.GetAllTeachersAsync();
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        
        [HttpPost("Create")]
        public async Task<ActionResult> CreateTeacher([FromBody]Teacher teacher)
        {
            try
            {
                var result = await _teachersRepository.CreateTeacher(teacher);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
