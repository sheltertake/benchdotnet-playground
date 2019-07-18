using BenchmarkDotNet.Attributes;

namespace Benchmarks.Benchmarks
{
    [MemoryDiagnoser]
    public class LohBenchmarks
    {
        [Benchmark]
        public byte[] Allocate84900()
        {
            return new byte[84900];
        }
        [Benchmark]
        public byte[] Allocate85000()
        {
            return new byte[85000];
        }
    }
}