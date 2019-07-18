using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;

namespace Benchmarks.Benchmarks {

    //[CoreJob] //output3.txt vs output2.txt = [CoreJob] vs nothing (DefaultJob) -> median? 
    //[DryJob]
    //[DryCoreJob]

    //[ShortRunJob]

    //[
    // SimpleJob,

    // CoreJob,
    // ClrJob,

    // RyuJitX64Job,
    // RyuJitX86Job,
    // LegacyJitX64Job,
    // LegacyJitX86Job,

    // DryJob,
    // DryCoreJob,

    // ShortRunJob, 
    // MediumRunJob,
    // LongRunJob, 
    // VeryLongRunJob, 

    // MonoJob,
    // DryMonoJob,

    // CoreRtJob,

    //]

    //[SimpleJob(
    //        //RunStrategy.ColdStart  //A mode without overhead evaluating and warmup, with single invocation. Perfect for startup time evaluation
    //        //RunStrategy.Monitoring //A mode without overhead evaluating, with several target iterations. Perfect for macrobenchmarks without a steady state with high variance
    //        //RunStrategy.Throughput  //Perfect for microbenchmarking.

    //        //RunStrategy.Throughput,

    //        // Job: DefaultJob -> // Runtime=.NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
    //        // Job: Clr(Runtime=Clr) -> //// Runtime=.NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
    //        // Job: Core(Runtime=Core) -> // Runtime=.NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT

    //        // Runtime=.NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
    //        // Job: Dry(IterationCount=1, LaunchCount=1, RunStrategy=ColdStart, UnrollFactor=1, WarmupCount=1)
    //        // Runtime=.NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
    //        // Job: DryCore(Runtime=Core, IterationCount=1, LaunchCount=1, RunStrategy=ColdStart, UnrollFactor=1, WarmupCount=1)


    //        // Runtime=.NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
    //        // Job: MediumRun(IterationCount=15, LaunchCount=2, WarmupCount=10)
    //        // Job: LongRun(IterationCount=100, LaunchCount=3, WarmupCount=15)
    //        // Job: VeryLongRun(IterationCount=500, LaunchCount=4, WarmupCount=30)

    //        // Job: LegacyJitX64(Jit=LegacyJit, Platform=X64, Runtime=Clr) -> // Runtime=.NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3416.0
    //        // Job: LegacyJitX86(Jit=LegacyJit, Platform=X86, Runtime=Clr) -> // Runtime=.NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3416.0
    //        // Job: RyuJitX64(Jit=RyuJit, Platform=X64) -> // Runtime=.NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT

    //        // FAILED:
    //        // Mono(Runtime=Mono)
    //        // DryMono(Runtime = Mono, IterationCount = 1, LaunchCount = 1, RunStrategy = ColdStart, UnrollFactor = 1, WarmupCount = 1)

    //        // BENCHMARKS WITH ISSUES:
    //        // CoreRT(Runtime = CoreRT)
    //        // RyuJitX86(Jit = RyuJit, Platform = X86)

    //        // i = 400

    //        //launchCount: 1, //,
    //        //warmupCount: 15,
    //        //targetCount: 5, // default 100,
    //        //invocationCount: 10 //,
    //        //id: "MyId"
    //    //baseline: false
    //    )]
    //[DryCoreJob]
    [SimpleJob(
        launchCount:1,
        warmupCount:0,
        targetCount:1,
        invocationCount:1
    )]
    //[MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter, RPlotExporter]
    [RPlotExporter]
    public class SimpleBenchmark {
        //private static int i = 0;
        [Params(10,20)]
        public int Ms { get; set; }

        [Benchmark]
        public void Sleep() {
            Thread.Sleep(Ms);
            //output.txt -> I want to understand static variable inside benchmark execution
            //Console.WriteLine(++i);
            //return ++i;

            //Thread.Sleep(++i);
        }

        [Benchmark]
        public void SleepWell()
        {
            Thread.Sleep(Ms * 2);
            //output.txt -> I want to understand static variable inside benchmark execution
            //Console.WriteLine(++i);
            //return ++i;

            //Thread.Sleep(++i);
        }
    }
}