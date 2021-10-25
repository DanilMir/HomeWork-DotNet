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
        [Fact]
        public void Test1()
        {
            //var client = new WebApplicationFactory<Startup>().CreateClient();
            
        }
        
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
    }
}