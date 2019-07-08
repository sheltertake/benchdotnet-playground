using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using CoreCLR.Benchmarks.Tests;

namespace CoreCLR.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            //var benchmark = BenchmarkRunner.Run<StructVsClassTest>();
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.WriteLine("Benchmark finished. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
