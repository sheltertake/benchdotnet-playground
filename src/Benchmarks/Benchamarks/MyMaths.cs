using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

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

    public static class FileOperations
    {
        public static void BadWriteTempFile()
        {
            byte[] data = new byte[64 * 1024 * 1024];
            var stopwatch = Stopwatch.StartNew();
            var fileName = Path.GetTempFileName();
            File.WriteAllBytes(fileName, data);
            File.Delete(fileName);
            stopwatch.Stop();
            Console.WriteLine(nameof(BadWriteTempFile) + " " + stopwatch.ElapsedMilliseconds);
        }

        public static void BetterWriteTempFile()
        {
            int N = 10;//1000
            byte[] data = new byte[64 * 1024 * 1024];
            var measurements = new long[N];
            for (int i = 0; i < N; i++)
            {
                var stopwatch = Stopwatch.StartNew();
                var fileName = Path.GetTempFileName();
                File.WriteAllBytes(fileName, data);
                File.Delete(fileName);
                stopwatch.Stop();
                measurements[i] = stopwatch.ElapsedMilliseconds;
                Console.WriteLine(nameof(BetterWriteTempFile) + " " + measurements[i]);
            }
            Console.WriteLine("Minimum = " + measurements.Min());
            Console.WriteLine("Maximum = " + measurements.Max());
            Console.WriteLine("Average = " + measurements.Average());
        }
    }
}