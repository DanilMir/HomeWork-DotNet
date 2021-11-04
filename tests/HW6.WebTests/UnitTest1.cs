using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using HW6;

namespace HW6.WebTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("/ping")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = new WebApplicationFactory<Startup>().CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Theory]
        [InlineData(1, "sum", 2, 3)]
        [InlineData(1, "div", 2, 0.5)]
        [InlineData(1, "mult", 2, 2)]
        [InlineData(1, "dif", 2, -1)]
        public async Task Calculate_Good_Request(decimal val1, string operation, decimal val2, decimal expected)
        {
            // Arrange
            var client = new WebApplicationFactory<Startup>().CreateClient();
            string url = $"/calculate?v1={val1}&Operation={operation}&v2={val2}";

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var str = await response.Content.ReadAsStringAsync();
            var res = decimal.TryParse(str, NumberStyles.Any ,CultureInfo.InvariantCulture, out var value);
            Assert.True(res);
            Assert.Equal(expected, value);
        }
        
        
        [Theory]
        [InlineData("/calculate?v1=1&Operation=div&v2=0", "\"Divide by zero\"", HttpStatusCode.BadRequest)]
        [InlineData("/calculate?v1=1&Operation=s&v2=0", "\"Undefined operation\"", HttpStatusCode.BadRequest)]
        [InlineData("/calculate?v1=1&Operation=div", "\"Missing value for required property V2.\"", HttpStatusCode.BadRequest)]
        [InlineData("/calculate?v1=1", "\"Missing value for required property Operation.\"", HttpStatusCode.BadRequest)]
        [InlineData("/calculate?", "\"Missing value for required property V1.\"", HttpStatusCode.BadRequest)]
        public async Task Calculate_BadRequest(string url, string expected, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            var client = new WebApplicationFactory<Startup>().CreateClient();
            
            // Act
            var response = await client.GetAsync(url);

            // Assert
            Assert.Equal(expectedStatusCode, response.StatusCode);

            var str = await response.Content.ReadAsStringAsync();
            Assert.Equal(expected, str);
        }
    }
}