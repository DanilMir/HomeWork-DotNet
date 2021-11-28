using System;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Xunit.Abstractions;

namespace HW9.Tests
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UnitTest1(WebApplicationFactory<Startup> factor)
        {
            _factory = factor;
        }

        private const string ResponseBody = "https://localhost:5001/calc?expr=";

        [Theory, InlineData("1+2+3+4+5", 2, 15), InlineData("2/2", 2, 1), InlineData("(2+1)/2", 2, 1)]
        [InlineData("(2+3)/12*7+8*9", 6, 72), InlineData("1-2+3", 2, -4)]
        [InlineData("1/(2+3)", 2, 0)]
        public async Task TimeTest(string expression, int timeInSeconds, decimal answer)
        {
            var client = _factory.CreateClient();
            var watch = new Stopwatch();
            watch.Start();
            var response = await client.GetAsync($"{ResponseBody}{expression}");
            watch.Stop();
            var result = decimal.Parse(await response.Content.ReadAsStringAsync(), NumberStyles.Any,
                CultureInfo.InvariantCulture);
            try
            {
                Assert.True(Math.Abs(result - answer) < 0.00001m);
            }
            catch
            {
                Assert.Equal(answer, result);
            }

            Assert.Equal(timeInSeconds, (int) Math.Round(watch.ElapsedMilliseconds / 1000.0));
        }
    }
}