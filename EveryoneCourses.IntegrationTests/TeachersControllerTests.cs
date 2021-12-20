using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using EveryoneCoursers.WebApi;
using EveryoneCourses.ClassLibrary.Models;
using Newtonsoft.Json;
using Xunit;

namespace EveryoneCourses.IntegrationTests
{
    public class TeachersControllerTests  : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public TeachersControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Fact]
        public async Task GetAllTeachers_WhenCalled_ReturnsOkResponse()
        {
            var client = _factory.CreateClient();

            var url = "/api/Teachers/getAllTeachers";
            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
        
        [Fact]
        public async Task Create_WhenCalled_ReturnsOkResponse()
        {
            var client = _factory.CreateClient();

            var url = "/api/Teachers/Create";
            // Act
            var teacher = new Teacher()
            {
                TotalNumberOfStudents = 0,
                Rating = 0,
                Name = "Test Name",
            };
            
            var teacherJson = new StringContent(
                JsonConvert.SerializeObject(teacher),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            
            var response = await client.PostAsync(url,teacherJson);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}