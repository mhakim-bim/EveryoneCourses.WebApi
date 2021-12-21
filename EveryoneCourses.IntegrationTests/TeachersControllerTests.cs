using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using EveryoneCoursers.WebApi;
using EveryoneCourses.ClassLibrary.Models;
using EveryoneCourses.IntegrationTests.Fakes;
using EveryoneCourses.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
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
            _factory.ClientOptions.BaseAddress = new Uri("http://localhost/api/Teachers/");
        }
        
        [Fact]
        public async Task GetAllTeachers_WhenCalled_ReturnsOkResponse()
        {
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton<ITeachersRepository>(new FakeTeachersRepository());
                    services.AddSingleton<IPolicyEvaluator,FakePolicyEvaluator>();
                });
            }) .CreateClient();

            var model = await client.GetFromJsonAsync<IEnumerable<Teacher>>("getAllTeachers");

            Assert.NotNull(model);
            Assert.True(model.Any());
          
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
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}