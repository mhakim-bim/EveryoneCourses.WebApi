using System;
using System.Threading.Tasks;
using EveryoneCoursers.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace EveryoneCourses.IntegrationTests
{
    public class TeachersControllerTests  : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public TeachersControllerTests(WebApplicationFactory<Startup> factory)
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
    }
}