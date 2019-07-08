using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = new int[100_000_000];//4 bytes * 100_000_000 = 400_000_000
            //a = null;
            //Thread.Sleep(10);
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            //GC.Collect();
            //Thread.Sleep(10);
            //var b = new int[100_000_000];
            //b = null;
            //Thread.Sleep(10);
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            //GC.Collect();
            //Thread.Sleep(10);
            //var c = new int[100_000_000];
            //c = null;
            //Thread.Sleep(10);
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            //GC.Collect();
            //Thread.Sleep(10);

            //int[] x = new int[100000000];
            //var stopwatch = Stopwatch.StartNew();
            //for (int i = 0; i < x.Length; i++)
            //    x[i]++;
            //stopwatch.Stop();
            //Console.WriteLine("Loop with cold start (cache is un warmed):" + stopwatch.ElapsedMilliseconds);
            //var n = 16777217;
            //var list = new List<int>();
            //var stopwatch = Stopwatch.StartNew();
            //for (int i = 0; i < n; i++)
            //    list.Add(0);
            //stopwatch.Stop();
            //Console.Write("Capacity: " + list.Capacity + ", Time = ");
            //Console.WriteLine("{0:0.00} ns",
            //    stopwatch.ElapsedMilliseconds * 1000000.0 / n);

            //var n = 100;//16777217;
            //var list = new List<Dto>();
            //var stopwatch = Stopwatch.StartNew();
            //for (int i = 0; i < n; i++)
            //    list.Add(new Dto());
            //stopwatch.Stop();
            //Console.Write("Capacity: " + list.Capacity + ", Time = ");
            //Console.WriteLine("{0:0.00} ns",
            //    stopwatch.ElapsedMilliseconds * 1000000.0 / n);
        }

        public class Dto
        {

        }
    }
}
