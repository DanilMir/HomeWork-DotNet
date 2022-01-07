using System;
using System.Net.Http;
using System.Text;
using HW10;
using JetBrains.dotMemoryUnit;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Xunit.Abstractions;

namespace HW13.CalculatorTests
{
    public class MemoryTest
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly HttpClient _client;
        private static readonly Random Random = new();
        private static readonly string[] Operations = new[] {"+", "-", "/", "*"};
        
        private readonly int _maxValue = Int32.MaxValue;

        public MemoryTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _client = new WebApplicationFactory<Startup>().CreateClient();
            DotMemoryUnitTestOutput.SetOutputMethod(_outputHelper.WriteLine);
        }

        [DotMemoryUnit(CollectAllocations = true, FailIfRunWithoutSupport = false)]
        [Fact]
        public void Test()
        {
            var memoryCheckPoint = dotMemory.Check();
            var alloc = 0;
            
            for (var i = 0; i < 1e5; i++)
            {
                var val1 = Random.Next(_maxValue);
                var val2 = Random.Next(_maxValue);
                var operation = Operations[Random.Next(Operations.Length)];
                
                var expression = $"{val1} {operation} {val2}";
                alloc += Encoding.UTF8.GetBytes(expression).Length;
                _client.GetAsync($"https://localhost:5001/calculate?expression={expression}").GetAwaiter().GetResult();
            }

            dotMemory.Check(memory =>
            {
                _outputHelper.WriteLine(memory.GetTrafficFrom(memoryCheckPoint).CollectedMemory.SizeInBytes.ToString());
                _outputHelper.WriteLine(alloc.ToString());
                Assert.True(memory.GetTrafficFrom(memoryCheckPoint).CollectedMemory.SizeInBytes >= alloc);
            });
        }
    }
}