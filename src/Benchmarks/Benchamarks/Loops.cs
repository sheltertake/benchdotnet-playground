using System;
using System.Diagnostics;

namespace Benchmarks.Benchamarks
{
    public static class Loops
    {

        public static void BadLoop()
        {
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 100000000; i++)
            {
            }
            stopwatch.Stop();
            Console.WriteLine(nameof(BadLoop) + " " + stopwatch.ElapsedMilliseconds);
        }
    }
}