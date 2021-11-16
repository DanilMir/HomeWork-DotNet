using System;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace HW8.Tests
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
        [InlineData("1", "-", "3", -2)]
        [InlineData("1", "*", "3", 3)]
        [InlineData("3", "/", "3", 1)]
        public async Task PositiveTests(string v1, string op, string v2, int expectedResult)
        {
            // Arrange
            var client = _factory.CreateClient();
            //Calculate/calc?value1=1&operation=/&value2=0
            var url = $"Calculate/calc?value1={v1}&operation={op}&value2={v2}";

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expectedResult, int.Parse(result, CultureInfo.InvariantCulture));
        }

        [Theory]
        [InlineData("2", "+", "x", "Values is not valid")]
        [InlineData("x", "+", "2", "Values is not valid")]
        [InlineData("2", "mod", "2", "operation is not supported")]
        [InlineData("1", "/", "0", "Divide by zero")]
        public async Task NegativeTests(string v1, string op, string v2, string expectedError)
        {
            // Arrange
            var client = _factory.CreateClient();
            var url = $"Calculate/calc?value1={v1}&operation={op}&value2={v2}";

            // Act
            var response = await client.GetAsync(url);

            // Assert
            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expectedError, result);
        }
    }
}