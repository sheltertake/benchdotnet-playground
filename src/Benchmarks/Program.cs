using System;
using Benchmarks.Benchmarks;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            Timestamps.IntroTimestamp();
            Timestamps.SortBad(10000);
            Timestamps.SortBad(10000);
            Timestamps.SortBad(10000);
            Timestamps.SortBetter(10000);
            Timestamps.SortBetter(10000);
            Timestamps.SortBetter(10000);

            Timestamps.SortBad(10);
            Timestamps.SortBad(10);
            Timestamps.SortBad(10);
            Timestamps.SortBetter(10);
            Timestamps.SortBetter(10);
            Timestamps.SortBetter(10);

            Timestamps.SortBad(2);
            Timestamps.SortBad(2);
            Timestamps.SortBad(2);
            Timestamps.SortBetter(2);
            Timestamps.SortBetter(2);
            Timestamps.SortBetter(2);

            Console.WriteLine("Advice: use Release and don't use empty loops to benchmark");
            Benchamarks.Loops.LoopEmpty();
            Benchamarks.Loops.LoopWithBody();
            
           
            Console.WriteLine("Advice: We can’t prevent natural noise");
            Benchamarks.FileOperations.BadWriteTempFile();
            Benchamarks.FileOperations.BetterWriteTempFile();
            Console.WriteLine("Advice: always look at your distribution");

            Benchamarks.MyMaths.BenchIsPrime();

        }
    }
}
