using System;
using System.Diagnostics;

namespace Benchmarks.Benchamarks
{
    public static class MyMaths
    {
        // It's not the fastest algorithm,
        // but we will optimize it later.
        public static bool IsPrime(int n)
        {
            for (int i = 2; i <= n - 1; i++)
                if (n % i == 0)
                    return false;
            return true;
        }

        public static void BenchIsPrime()
        {
            var stopwatch1 = Stopwatch.StartNew();
            IsPrime(2147483647);
            stopwatch1.Stop();
            var stopwatch2 = Stopwatch.StartNew();
            IsPrime(2147483647);
            stopwatch2.Stop();
            Console.WriteLine(stopwatch1.ElapsedMilliseconds + " vs. " +
                              stopwatch2.ElapsedMilliseconds);

            //BAD
            Console.WriteLine("Bad benchmark");
            if (stopwatch1.ElapsedMilliseconds < stopwatch2.ElapsedMilliseconds)
                Console.WriteLine("The first method is faster");
            else
                Console.WriteLine("The second method is faster");

            //BETTER
            Console.WriteLine("Better benchmark");
            var error = ((stopwatch1.ElapsedMilliseconds +
                          stopwatch2.ElapsedMilliseconds) / 2) * 0.20;
            if (Math.Abs(stopwatch1.ElapsedMilliseconds -
                         stopwatch2.ElapsedMilliseconds) < error)
                Console.WriteLine("There is no significant difference between methods");
            else if (stopwatch1.ElapsedMilliseconds < stopwatch2.ElapsedMilliseconds)
                Console.WriteLine("The first method is faster");
            else
                Console.WriteLine("The second method is faster");
        }

    }
}