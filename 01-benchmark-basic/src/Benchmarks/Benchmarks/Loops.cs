using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Benchmarks.Benchamarks
{
    public static class Loops
        {
            public static void LoopDeadCodeElimination()
            {
                double x = 0;
                var stopwatch = Stopwatch.StartNew();
                for (int i = 0; i < 100000001; i++)
                    Math.Sqrt(x);
                stopwatch.Stop();
                var stopwatch2 = Stopwatch.StartNew();
                for (int i = 0; i < 100000001; i++) ;
                stopwatch2.Stop();
                var target = stopwatch.ElapsedMilliseconds;
                var overhead = stopwatch2.ElapsedMilliseconds;
                var result = target - overhead;
                Console.WriteLine("Target = " + target + "ms");
                Console.WriteLine("Overhead = " + overhead + "ms");
                Console.WriteLine("Result = " + result + "ms");
            }
            public static void LoopDeadCodeEliminationCollectResult()
            {
                double x = 0, y = 0;
                var stopwatch = Stopwatch.StartNew();
                for (int i = 0; i < 100000001; i++)
                    y += Math.Sqrt(x);
                stopwatch.Stop();
                Console.WriteLine(y);
                var stopwatch2 = Stopwatch.StartNew();
                for (int i = 0; i < 100000001; i++) ;
                stopwatch2.Stop();
                var target = stopwatch.ElapsedMilliseconds;
                var overhead = stopwatch2.ElapsedMilliseconds;
                var result = target - overhead;
                Console.WriteLine("Target = " + target + "ms");
                Console.WriteLine("Overhead = " + overhead + "ms");
                Console.WriteLine("Result = " + result + "ms");
            }
            public static void LoopFindSteadyState()
            {
                int[] x = new int[100000000];
                for (int iter = 0; iter < 5; iter++)
                {
                    var stopwatch = Stopwatch.StartNew();
                    for (int i = 0; i < x.Length; i++)
                        x[i]++;
                    stopwatch.Stop();
                    Console.WriteLine("Warmup - find the steady state:" + stopwatch.ElapsedMilliseconds);
                }

            }

            public static void LoopColdStart()
            {
                int[] x = new int[100000000];
                var stopwatch = Stopwatch.StartNew();
                for (int i = 0; i < x.Length; i++)
                    x[i]++;
                stopwatch.Stop();
                Console.WriteLine("Loop with cold start (cache is un warmed):" + stopwatch.ElapsedMilliseconds);
            }
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

            public static void LoopOneInvocation()
            {
                const int N = 100000;
                for (int iter = 0; iter < 10; iter++)
                {
                    var stopwatch = Stopwatch.StartNew();
                    int counter = 0;
                    for (int i = 1; i <= N; i++)
                        if (N % i == 0)
                            counter++;
                    stopwatch.Stop();
                    var elapsedMs = stopwatch.Elapsed.TotalMilliseconds;
                    Console.WriteLine("Measuring one invocation : " + elapsedMs + " ms");
                }
            }

            public static void LoopManyInvocations()
            {
                const int N = 100000;
                const int Invocations = 3000;
                for (int iter = 0; iter < 10; iter++)
                {
                    var stopwatch = Stopwatch.StartNew();
                    for (int rep = 0; rep < Invocations; rep++)
                    {
                        int counter = 0;
                        for (int i = 1; i <= N; i++)
                            if (N % i == 0)
                                counter++;
                    }
                    stopwatch.Stop();
                    var elapsedMs = stopwatch.Elapsed.TotalMilliseconds
                                    / Invocations;
                    Console.WriteLine($"Measuring {Invocations} invocation : " + elapsedMs + " ms");
                }
            }

            public static void LoopConversion()
            {
                var stopwatch = Stopwatch.StartNew();
                for (int i = 0; i < 100000001; i++)
                    Convert.ToInt32(0.0);
                stopwatch.Stop();
                Console.WriteLine("Conversion x 100000001 times : " + stopwatch.ElapsedMilliseconds);
            }

            public static void LoopConversionWithoutInfra()
            {
                var stopwatchOverhead = Stopwatch.StartNew();
                for (int i = 0; i < 100000001; i++)
                {
                }
                stopwatchOverhead.Stop();
                var stopwatchTarget = Stopwatch.StartNew();
                for (int i = 0; i < 100000001; i++)
                    Convert.ToInt32(0.0);

                stopwatchTarget.Stop();
                var resultOverhead = stopwatchTarget.ElapsedMilliseconds - stopwatchOverhead.ElapsedMilliseconds;
                Console.WriteLine("Loop 100000001 times costs : " + stopwatchOverhead.ElapsedMilliseconds);
                Console.WriteLine("Conversion x 100000001 times without infra cost : " + resultOverhead);
            }

            public static void ItereationUnequal(int n)
            {
                var list = new List<int>();
                var stopwatch = Stopwatch.StartNew();
                for (int i = 0; i < n; i++)
                    list.Add(0);
                stopwatch.Stop();
                Console.Write("Capacity: " + list.Capacity + ", Time = ");
                Console.WriteLine("{0:0.00} ns",
                    stopwatch.ElapsedMilliseconds * 1000000.0 / n);
            }

            public static void LoopAvoidUnrolling(int N1, int N2)
            {
                //int  = 1000000001,  = 1000000002;
                var stopwatch1 = Stopwatch.StartNew();
                for (int i = 0; i < N1; i++)
                {
                }
                stopwatch1.Stop();
                var stopwatch2 = Stopwatch.StartNew();
                for (int i = 0; i < N2; i++)
                {
                }
                stopwatch2.Stop();
                Console.WriteLine("Loop without rolling : " + stopwatch1.ElapsedMilliseconds + " vs. " +
                                  stopwatch2.ElapsedMilliseconds);
            }
            public static void LoopUnrolling()
            {
                var stopwatch1 = Stopwatch.StartNew();
                for (int i = 0; i < 1000000001; i++)
                {
                }
                stopwatch1.Stop();
                var stopwatch2 = Stopwatch.StartNew();
                for (int i = 0; i < 1000000002; i++)
                {
                }
                stopwatch2.Stop();
                Console.WriteLine("Loop with rolling : " + stopwatch1.ElapsedMilliseconds + " vs. " +
                stopwatch2.ElapsedMilliseconds);
            }
        }
    }