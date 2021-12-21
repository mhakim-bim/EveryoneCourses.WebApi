using System.Threading.Tasks;
using EveryoneCoursers.WebApi;
using EveryoneCourses.IntegrationTests.Fakes;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
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
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                });
            }).CreateClient();
            var response = await client.GetAsync("/health");
            response.EnsureSuccessStatusCode();

        }
    }
}