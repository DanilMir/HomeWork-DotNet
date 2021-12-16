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
            private HttpClient _clientCSharp;
            private HttpClient _clientFSharp;
        
            private const string FSharpUrl = "https://localhost:5001/calculate";
            private const string CSharpUrl = "https://localhost:5001/calculate/calc";

            [GlobalSetup]
            public void GlobalSetUp()
            {
                _clientCSharp = new CustomWebApplicationFactory<HW8.Startup>().CreateDefaultClient();
                _clientFSharp = new CustomWebApplicationFactory<HW6.Startup>().CreateDefaultClient();
            }

            [Benchmark(Description = "F# 2+2")]
            public async Task PlusFSharp() 
                => await _clientFSharp.GetAsync(FSharpUrl + "?V1=2&Operation=sum&V2=2");
        
            [Benchmark(Description = "C# 2+2")]
            public async Task PlusCSharp() 
                => await _clientCSharp.GetAsync(CSharpUrl + 
                                                "?value1=2&operation=+&value2=2");
            
            [Benchmark(Description = "F# 12-2")]
            public async Task MinusFSharp() 
                => await _clientFSharp.GetAsync(FSharpUrl + "?V1=12&Operation=dif&V2=2");
        
            [Benchmark(Description = "C# 12-2")]
            public async Task MinusCSharp() 
                => await _clientCSharp.GetAsync(CSharpUrl + "?value1=12&operation=-&value2=2");
        
            [Benchmark(Description = "F# 12*2")]
            public async Task MultiplicationFSharp() 
                => await _clientFSharp.GetAsync(FSharpUrl + "?V1=12&Operation=mult&V2=2");
        
            [Benchmark(Description = "C# 12*2")]
            public async Task MultiplicationCSharp() 
                => await _clientCSharp.GetAsync(CSharpUrl + "?value1=12&operation=*&value2=2");
            
            [Benchmark(Description = "F# 21/3")]
            public async Task DivisionFSharp() 
                => await _clientFSharp.GetAsync(FSharpUrl + "?V1=21&Operation=div&V2=3");
        
            [Benchmark(Description = "C# 21/3")]
            public async Task DivisionCSharp() 
                => await _clientCSharp.GetAsync(CSharpUrl + "?value1=21&operation=/&value2=3");
    }
}