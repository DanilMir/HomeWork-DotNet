using System;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace HW10.Tests
{
    
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UnitTest1(WebApplicationFactory<Startup> factor)
        {
            _factory = factor.WithWebHostBuilder(builder =>
                builder.ConfigureServices(services =>
                    services
                        .AddDbContext<HW10.Models.AppContext>(options =>
                            options
                                .UseInMemoryDatabase("dotnetExpr"))));
        }

        private const string ResponseBody = "https://localhost:5001/calc?expr=";

        [Theory, InlineData("1+2+3+4+5", 1, 15), InlineData("2/2", 1, 1), InlineData("(2+1)/2", 1, 1)]
        [InlineData("(2+3)/12*7+8*9", 1, 72), InlineData("1+2+3", 1, 6)]
        [InlineData("1/(2+3)", 1, 0)]
        public async Task TimeTest(string expression, int timeInSeconds, decimal answer)
        {
            var client = _factory.CreateClient();
            var watch = new Stopwatch();
            watch.Start();
            var response = await client.GetAsync($"{ResponseBody}{expression}");
            watch.Stop();
            var result = decimal.Parse(await response.Content.ReadAsStringAsync(), NumberStyles.Any,
                CultureInfo.InvariantCulture);

            Assert.Equal(answer, result);

            Assert.True(timeInSeconds >= (int) Math.Round(watch.ElapsedMilliseconds / 1000.0));
        }
    }
}