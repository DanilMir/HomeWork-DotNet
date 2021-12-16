using System;
using BenchmarkDotNet.Running;

namespace HW12
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }
}