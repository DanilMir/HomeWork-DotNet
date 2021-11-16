using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace HW8
{
    public class BasicTests
        : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public BasicTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("1.5", "plus", "3.2", 4.7)]
        [InlineData("1.5", "minus", "3.2", -1.7)]
        [InlineData("1.5", "multiply", "3.2", 4.8)]
        [InlineData("1.5", "divide", "3.2", 0.46875)]
        public async Task PositiveTests(string v1, string op, string v2, decimal expectedResult)
        {
            // Arrange
            var client = _factory.CreateClient();
            var url = $"calculator/calculate?value1={v1}&operation={op}&value2={v2}";

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expectedResult, decimal.Parse(result, CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData("2", "plus", "x", "The value 'x' is not valid for Value2.")]
        [InlineData("x", "plus", "2", "The value 'x' is not valid for Value1.")]
        [InlineData("2", "mod", "2", "The value 'mod' is not valid for Operation.")]
        [InlineData("1", "divide", "0", "Divide by zero.")]
        public async Task NegativeTests(string v1, string op, string v2, string expectedError)
        {
            // Arrange
            var client = _factory.CreateClient();
            var url = $"calculator/calculate?value1={v1}&operation={op}&value2={v2}";

            // Act
            var response = await client.GetAsync(url);

            // Assert
            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expectedError, result);
        }

        [Fact]
        public async Task IndexTest()
        {
            var client = _factory.CreateClient();
            var url = "calculator";

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}