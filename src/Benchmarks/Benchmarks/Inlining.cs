using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Benchmarks.Benchamarks
{
    public static class Inlining
    {
        public class Measurements2
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            double A(double x)
            {
                return x * x;
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            double B(double x)
            {
                if (x < 0)
                    throw new ArgumentOutOfRangeException("x");
                return x * x;
            }

            public void Do()
            {
                double sum = 0;
                var stopwatchA = Stopwatch.StartNew();
                for (int i = 0; i < 1000000001; i++)
                    sum += A(i);
                stopwatchA.Stop();
                var stopwatchB = Stopwatch.StartNew();
                for (int i = 0; i < 1000000001; i++)
                    sum += B(i);
                stopwatchB.Stop();
                Console.WriteLine(
                    stopwatchA.ElapsedMilliseconds + " vs. " +
                    stopwatchB.ElapsedMilliseconds);
            }
        }

        public class Measurements
        {
            double A(double x)
            {
                return x * x;
            }

            double B(double x)
            {

                if (x < 0)
                    throw new ArgumentOutOfRangeException("x");
                return x * x;
            }

            public void Do()
            {
                double sum = 0;
                var stopwatchA = Stopwatch.StartNew();
                for (int i = 0; i < 1000000001; i++)
                    sum += A(i);
                stopwatchA.Stop();
                var stopwatchB = Stopwatch.StartNew();
                for (int i = 0; i < 1000000001; i++)
                    sum += B(i);
                stopwatchB.Stop();
                Console.WriteLine(
                    stopwatchA.ElapsedMilliseconds + " vs. " +
                    stopwatchB.ElapsedMilliseconds);
            }
        }
    }
}