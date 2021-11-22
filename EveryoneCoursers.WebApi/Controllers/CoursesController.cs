using EveryoneCourses.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CoursesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
