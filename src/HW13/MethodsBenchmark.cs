using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace HW13
{
    [MemoryDiagnoser]
    [MinColumn]
    [MaxColumn]
    [MedianColumn]
    [MeanColumn]
    [StdDevColumn]
    public class MethodsBenchmark
    {
        private TestMethods _testMethods;
        private string _testInput;
        private static MethodInfo _methodFromTest;

        [GlobalSetup]
        public void Setup()
        {
            _testMethods = new TestMethods();
            _methodFromTest = typeof(TestMethods).GetMethod("ReflectionMethod");
            _testInput = "aboba";
        }

        [Benchmark(Description = "Method")]
        public void TestMethod() => 
            _testMethods.Method(_testInput);
    

        [Benchmark(Description = "Static method")]
        public void TestStaticMethod() =>
            TestMethods.StaticMethod(_testInput);
    

        [Benchmark(Description = "Virtual method")]
        public void TestVirtualMethod() =>
            _testMethods.VirtualMethod(_testInput);
    

        [Benchmark(Description = "Generic method")]
        public void TestGenericMethod() =>
            _testMethods.GenericMethod<string>(_testInput);
    

        [Benchmark(Description = "Reflection method")]
        public void TestReflectionMethod() =>
            _methodFromTest.Invoke(_testMethods, new object[] {_testInput});
    

        [Benchmark(Description = "Dynamic method")]
        public void TestDynamicMethod() =>
            _testMethods.DynamicMethod(_testInput);
    }
}