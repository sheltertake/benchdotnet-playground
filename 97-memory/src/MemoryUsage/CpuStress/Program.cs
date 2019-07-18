using System;
using System.Diagnostics;

namespace CpuStress
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    // Do something
                    BenchIsPrime();
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        static void BenchIsPrime()
        {
            var stopwatch1 = Stopwatch.StartNew();
            IsPrime(2147483647);
            stopwatch1.Stop();
            Console.WriteLine(stopwatch1.ElapsedMilliseconds);

        }

        // It's not the fastest algorithm,
        // but we will optimize it later.
        static bool IsPrime(int n)
        {
            for (int i = 2; i <= n - 1; i++)
                if (n % i == 0)
                    return false;
            return true;
        }
    }
}
