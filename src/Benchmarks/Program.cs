using System;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            Benchamarks.Timestamps.HelloWorld();
            Benchamarks.Timestamps.SortBad();
            Benchamarks.Timestamps.SortBetter();
            Benchamarks.Timestamps.SortBad();
            Benchamarks.Timestamps.SortBetter();
            Console.WriteLine("Advice: prefer Stopwatch over DateTime");
           
            Benchamarks.Loops.BadLoop();
            Console.WriteLine("Advice: use Release");
           
            //Benchamarks.MyMaths.BenchIsPrime();
            Console.WriteLine("Advice: We can’t prevent natural noise");

            Benchamarks.FileOperations.BadWriteTempFile();
            Benchamarks.FileOperations.BetterWriteTempFile();
            Console.WriteLine("Advice: always look at your distribution");
        }
    }
}
