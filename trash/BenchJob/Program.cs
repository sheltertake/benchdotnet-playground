using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;

namespace MyBenchmarks
{
    
    //[SimpleJob(
    //    RunStrategy.Throughput,
        
    //    id:"MyJob",
    //    invocationCount:1,
    //    launchCount:100,
    //    warmupCount:10,
    //    targetCount: 15 //IterationCount -> MinIterationCount 15 MaxIterationCount 100

    //)]
    //[CoreJob]
    public class HelloWorld
    {
        public static int Counter = 0;
        [Params("HelloWorld")]
        public string Param { get; set; }

        [Benchmark]
        public string Concat()
        {
            Console.WriteLine(Param + " " + ++Counter);
            return Param;
        }
        
    }
    public class Program {
        public static void Main (string[] args) {
            var summary = BenchmarkRunner.Run<HelloWorld> ();
        }
    }
}