using System;
using System.Diagnostics;
using System.Linq;

namespace Benchmarks.Benchmarks
{
    public static class Timestamps
    {

        public static void SortBad(int count)
        {
            var list = Enumerable.Range(0, count).ToList();
            DateTime start = DateTime.Now;
            list.Sort();
            DateTime end = DateTime.Now;
            TimeSpan elapsedTime = end - start;
            Console.WriteLine($"Benchmark sort {count} elements with DateTime :" + elapsedTime.TotalMilliseconds);
        }

        public static void SortBetter(int count)
        {
            var list = Enumerable.Range(0, count).ToList();
            var stopwatch = Stopwatch.StartNew();
            list.Sort();
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            Console.WriteLine($"Benchmark sort {count} elements with StopWatch :" + elapsedTime.TotalMilliseconds);
        }
    }
}
