using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
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

            var n = 100;//16777217;
            var list = new List<Dto>();
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
                list.Add(new Dto());
            stopwatch.Stop();
            Console.Write("Capacity: " + list.Capacity + ", Time = ");
            Console.WriteLine("{0:0.00} ns",
                stopwatch.ElapsedMilliseconds * 1000000.0 / n);
        }

        public class Dto
        {

        }
    }
}
