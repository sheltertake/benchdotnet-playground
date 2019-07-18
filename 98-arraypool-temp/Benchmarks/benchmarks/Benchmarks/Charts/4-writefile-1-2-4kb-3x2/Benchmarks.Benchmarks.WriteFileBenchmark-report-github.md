``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.885 (1803/April2018Update/Redstone4)
Intel Core i5-5200U CPU 2.20GHz (Broadwell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.2.301
  [Host]     : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
  Job-GHLQKE : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT

InvocationCount=2  IterationCount=3  LaunchCount=1  
UnrollFactor=1  WarmupCount=1  

```
|   Method |   Kb |     Mean |    Error |    StdDev |
|--------- |----- |---------:|---------:|----------:|
| **Write1Kb** | **1024** | **2.858 ms** | **3.617 ms** | **0.1983 ms** |
| **Write1Kb** | **2048** | **2.522 ms** | **1.065 ms** | **0.0584 ms** |
| **Write1Kb** | **4096** | **3.021 ms** | **2.368 ms** | **0.1298 ms** |
