using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Benchmarks.Benchamarks
{
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
            Console.WriteLine("Writing 64Mega file in temp and delete it:" + stopwatch.ElapsedMilliseconds);
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
                Console.WriteLine("Writing 64Mega file in temp and delete it in a loop:" + measurements[i]);
            }
            Console.WriteLine("Minimum = " + measurements.Min());
            Console.WriteLine("Maximum = " + measurements.Max());
            Console.WriteLine("Average = " + measurements.Average());
        }
    }
}