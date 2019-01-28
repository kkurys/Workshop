using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Workshop.Integration.Tests
{
    public class LoggingApiTests : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly WebApplicationFactory<Api.Startup> _factory;

        public LoggingApiTests(WebApplicationFactory<Api.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/Logging/GetLogs")]
        public async Task GetLogs_ReturnSuccess(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }
    }
}