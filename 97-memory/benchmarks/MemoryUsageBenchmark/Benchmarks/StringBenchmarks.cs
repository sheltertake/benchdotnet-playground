using BenchmarkDotNet.Attributes;
using MemoryUsage;

namespace MemoryUsageBenchmark.Benchmarks
{
    [MemoryDiagnoser]
    [ShortRunJob]
    public class StringBenchmarks
    {
        [Benchmark]
        public string GetString()
        {
            return MemoryUsageHelper.GetString();
        }
       
    }
}