using EveryoneCourses.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EveryoneCourses.ClassLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EveryoneCoursers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursersRepository _coursersRepository;

        public CoursesController(ICoursersRepository coursersRepository)
        {
            _coursersRepository = coursersRepository;
        }


        [HttpGet("getAllCourses")]
        public async Task<ActionResult> GetAllCourses()
        {
            try
            {
                var result = await _coursersRepository.GetAllCoursesAsync();
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        
        [HttpPost("Create")]
        public async Task<ActionResult> CreateCourse([FromBody]Course course)
        {
            try
            {
                var result = await _coursersRepository.CreateCourseAsync(course);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
