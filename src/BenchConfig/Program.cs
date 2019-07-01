using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Horology;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace BenchConfig
{
    [Config(typeof(Config))]
    public class HelloWorld
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                Add(
                    new Job("MySuperJob", RunMode.VeryLong)// EnvMode.RyuJitX64
                    {
                        Environment =
                        {
                            //Platform: x86 or x64
                            Platform = Platform.AnyCpu,
                            //Runtime:
                            //Clr: Full .NET Framework (available only on Windows)
                            //Core: CoreCLR (x-plat)
                            //Mono: Mono (x-plat)
                            Runtime = Runtime.Core,
                            //Jit:
                            //LegacyJit (available only for Runtime.Clr)
                            //RyuJit(available only for Runtime.Clr and Runtime.Core)
                            //Llvm(available only for Runtime.Mono)
                            Jit = Jit.RyuJit,
                            //Affinity: Affinity of a benchmark process
                            //Affinity = ?? 
                            //GcMode: settings of Garbage Collector
                            //Server: true(Server mode) or false(Workstation mode)
                            //Concurrent: true(Concurrent mode) or false(NonConcurrent mode)
                            //CpuGroups: Specifies whether garbage collection supports multiple CPU groups
                            //Force: Specifies whether the BenchmarkDotNet's benchmark runner forces full garbage collection after each benchmark invocation
                            //AllowVeryLargeObjects: On 64 - bit platforms, enables arrays that are greater than 2 gigabytes(GB) in total size
                            //EnvironmentVariables: customized environment variables for target benchmark. See also: Sample: IntroEnvVars
                            
                        },
                        Run =
                        {
                            //LaunchCount = 5, IterationTime = TimeInterval.Millisecond * 200
                            RunStrategy = RunStrategy.Throughput
                            //Throughput: default strategy which allows to get good precision level
                            //ColdStart: should be used only for measuring cold start of the application or testing purpose
                            //Monitoring: A mode without overhead evaluating, with several target iterations


                            //LaunchCount: how many times we should launch process with target benchmark
                            //WarmupCount: how many warmup iterations should be performed
                            //IterationCount: how many target iterations should be performed
                            //(if specified,
                            //BenchmarkDotNet.Jobs.RunMode.MinIterationCount and
                            //BenchmarkDotNet.Jobs.RunMode.MaxIterationCount will be ignored)
                            //,IterationCount = 100
                            //IterationTime: desired time of a single iteration
                            //,IterationTime = 
                            //UnrollFactor: how many times the benchmark method will be invoked per one iteration of a generated loop
                            //InvocationCount: count of invocation in a single iteration(if specified, IterationTime will be ignored), must be a multiple of UnrollFactor
                            //MinIterationCount: Minimum count of target iterations that should be performed, the default value is 15
                            , MinIterationCount = 15
                            //MaxIterationCount: Maximum count of target iterations that should be performed, the default value is 100
                            , MaxIterationCount = 100
                            //MinWarmupIterationCount: Minimum count of warmup iterations that should be performed, the default value is 6
                            , MinWarmupIterationCount = 6
                            //MaxWarmupIterationCount: Maximum count of warmup iterations that should be performed, the default value is 50
                            , MaxWarmupIterationCount = 50
                        },
                        //Accuracy = { MaxStdErrRelative = 0.01 }
                    });

                // The same, using the .With() factory methods:
                //Add(
                //    Job.Dry
                //        .With(Platform.X64)
                //        .With(Jit.RyuJit)
                //        .With(Runtime.Core)
                //        .WithLaunchCount(5)
                //        .WithIterationTime(TimeInterval.Millisecond * 200)
                //        //.WithMaxStdErrRelative(0.01)
                //        .WithId("MySuperJob"));
            }
        }
        //private readonly string HelloWorld = "HelloWorld";
        //private readonly StringBuilder HelloWorldSb = new StringBuilder("HelloWorld");
        public static int Counter = 0;

        [Params("HelloWorld")]
        public string Param { get; set; }

        [Benchmark]
        public string Concat()
        {
            Console.WriteLine(Param + " " + ++Counter);
            return Param;
        }
        //[Benchmark]
        //public string StringBuilder()
        //{
        //    return HelloWorldSb.Append(HelloWorld).ToString();
        //}
    }
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<HelloWorld>();
        }
    }
}
