using System;
using System.Diagnostics;

namespace Benchmarks.Benchamarks
{
    public static class Loops
    {

        public static void LoopEmpty()
        {
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 100000000; i++)
            {
            }
            stopwatch.Stop();
            Console.WriteLine("LoopEmpty 100.000.000: " + stopwatch.ElapsedMilliseconds);
        }

        public static void LoopWithBody()
        {
            var o = 0;
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 100000000; i++)
            {
                o++;
            }
            stopwatch.Stop();
            Console.WriteLine($"LoopWithBody {o}: " + stopwatch.ElapsedMilliseconds);
        }
    }
}