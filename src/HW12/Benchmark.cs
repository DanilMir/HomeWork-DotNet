using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace HW12
{
    [MinColumn]
    [MaxColumn]
    public class Benchmark
    {
        private HttpClient _csharpClient;
        private HttpClient _fsharpClient;
        
        [ParamsSource(nameof(ArgumentsParams))]
        public ValueTuple<string, string, string, string> Arguments { get; set; }

        public string CSharpUrl;
        public string FSharpUrl;

        public IEnumerable<ValueTuple<string, string, string, string>> ArgumentsParams =>
            new[]
            {
                ("23", "sum", "121", "+"),
                ("78", "dif", "23", "-"),
                ("114", "mult", "121", "*"),
                ("256", "div", "78", "/")
            };

        [GlobalSetup]
        public void GlobalSetUp()
        {
            _csharpClient = new CustomWebApplicationFactory<HW8.Startup>().CreateDefaultClient();
            _fsharpClient = new CustomWebApplicationFactory<HW6.Startup>().CreateDefaultClient();

            CSharpUrl =
                $"https://localhost:5001/calculate/calc" +
                $"?value1={Arguments.Item1}&operation={Arguments.Item4}&value2={Arguments.Item3}";
            FSharpUrl = 
                $"https://localhost:5001/calculate" +
                $"?V1={Arguments.Item1}&Operation={Arguments.Item2}&V2={Arguments.Item3}";
        }

        [Benchmark]
        public async Task FSharp()
        {
            await _fsharpClient.GetAsync(CSharpUrl);
        }

        [Benchmark]
        public async Task CSharp()
        {
            await _csharpClient.GetAsync(FSharpUrl);
        }
    }
}