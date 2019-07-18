1) output.txt
DefaultJob + Console.Writeline static i
i increment 110593 times

2) output2 vs output3
DefaultJob vs CoreJob -> differences Median?

3) output-all-writeline
dotnet run -c Release -f netcoreapp2.2 --filter *SimpleBenchmark* > Outputs/output-all-writeline.txt

DryMono (DryMonoJob), Mono (MonoJob) -> Mono is not installed or added to PATH

// Validating benchmarks:
// ***** BenchmarkRunner: Start   *****
// ***** Found 13 benchmark(s) in total *****
// ***** Building 7 exe(s) in Parallel: Start   *****
// ***** Done, took 00:01:15 (75.31 sec)   *****
// ***** Failed to build in Parallel, switching to sequential build..   *****

// Found 13 benchmarks:
//   SimpleBenchmark.Write: DefaultJob

//   SimpleBenchmark.Write: Clr(Runtime=Clr)
//   SimpleBenchmark.Write: Core(Runtime=Core)
//   SimpleBenchmark.Write: CoreRT(Runtime=CoreRT)



//   SimpleBenchmark.Write: 

    DryCore(
        Runtime=Core, 
        IterationCount=1, 
        LaunchCount=1, 
        RunStrategy=ColdStart, 
        UnrollFactor=1, 
        WarmupCount=1
    )

//   SimpleBenchmark.Write: 

    LegacyJitX64(
        Jit=LegacyJit, 
        Platform=X64, 
        Runtime=Clr
        )

//   SimpleBenchmark.Write: 
    
    LegacyJitX86(
        Jit=LegacyJit, 
        Platform=X86, 
        Runtime=Clr
    )

//   SimpleBenchmark.Write: 
    RyuJitX64(
        Jit=RyuJit, 
        Platform=X64
    )
//   SimpleBenchmark.Write: 
    RyuJitX86(
        Jit=RyuJit, 
        Platform=X86
    )

    
//   SimpleBenchmark.Write: 

    Dry(
        IterationCount=1, 
        LaunchCount=1, 
        RunStrategy=ColdStart, 
        UnrollFactor=1, 
        WarmupCount=1
    )

//   SimpleBenchmark.Write: 
    
    ShortRun(
        IterationCount=3, 
        LaunchCount=1, 
        WarmupCount=3
    )

//   SimpleBenchmark.Write: 
    
    MediumRun(
        IterationCount=15, 
        LaunchCount=2, 
        WarmupCount=10
    )

//   SimpleBenchmark.Write: 

    LongRun(
        IterationCount=100, 
        LaunchCount=3, 
        WarmupCount=15
    )

//   SimpleBenchmark.Write: 
    VeryLongRun(
        IterationCount=500, 
        LaunchCount=4,
        WarmupCount=30
        )
