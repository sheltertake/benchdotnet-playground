using System;
using System.Diagnostics;
using System.Linq;

namespace Benchmarks.Benchamarks
{
    public static class Timestamps
    {
        public static void HelloWorld()
        {
            Console.WriteLine("HelloWorld");
        }

        public static void SortBad()
        {
            var list = Enumerable.Range(0, 10000).ToList();
            DateTime start = DateTime.Now;
            list.Sort();
            DateTime end = DateTime.Now;
            TimeSpan elapsedTime = end - start;
            Console.WriteLine(nameof(DateTime) + " " + elapsedTime.TotalMilliseconds);
        }

        public static void SortBetter()
        {
            var list = Enumerable.Range(0, 10000).ToList();
            var stopwatch = Stopwatch.StartNew();
            list.Sort();
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            Console.WriteLine(nameof(Stopwatch) + " " + elapsedTime.TotalMilliseconds);
        }
    }
}
