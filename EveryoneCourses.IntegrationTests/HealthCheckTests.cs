using System.Threading.Tasks;
using EveryoneCoursers.WebApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace EveryoneCourses.IntegrationTests
{
    public class HealthCheckTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public HealthCheckTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }


        [Fact]
        public async Task HealthCheck()
        {
            var client = _factory.CreateDefaultClient();
            var response = await client.GetAsync("/health");
            response.EnsureSuccessStatusCode();

        }
    }
}