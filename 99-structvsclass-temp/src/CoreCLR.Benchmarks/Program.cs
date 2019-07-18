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
#if DEBUG
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());
#else
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
#endif
            Console.WriteLine("Benchmark finished. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
