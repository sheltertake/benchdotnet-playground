using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks.Benchmarks
{
    [MediumRunJob] //IterationCount=15, LaunchCount=2, warmupCount=10 // targetCount: 256?
    [RPlotExporter]
    [MemoryDiagnoser]
    public class StringsBenchmark
    {
        //private int n = 1;
        private StringBuilder sb = new StringBuilder();
        //private string str = "";
        //[Benchmark]
        //public void Sb()
        //{
        //    sb.Append((++n).ToString());
        //    //Console.WriteLine("sb: " + sb.Length); //sb: 275623
        //}

        //[Benchmark]
        //public void Str()
        //{
        //    str += (++n).ToString();
        //    //Console.WriteLine("str: " + str.Length); //str: 275623
        //}

        [GlobalCleanup]
        public void GlobalCleanUp()
        {
            Console.WriteLine(sb.Length);
        }

        //[Benchmark(OperationsPerInvoke = 16)]
        //public void SbAppend()
        //{
        //    sb.Clear();

        //    for (int i = 0; i < 1024; i++)
        //        sb.Append('a');
        //}

        [IterationCleanup]
        public void IterationCleanup()
        {
            sb.Clear();
        }

        //[Benchmark(OperationsPerInvoke = Int32.MaxValue)]
        //public void SbSideEffects()
        //{
        //    // This method is growing the buffer to infinity
        //    // because it's executed millions of times
        //    sb.Append('a');
        //}
    }
}