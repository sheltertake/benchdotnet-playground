``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.885 (1803/April2018Update/Redstone4)
Intel Core i5-5200U CPU 2.20GHz (Broadwell), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.2.301
  [Host]    : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
  MediumRun : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|   Method |   Kb |     Mean |     Error |    StdDev |
|--------- |----- |---------:|----------:|----------:|
| **WriteNKb** | **1024** | **2.538 ms** | **0.1008 ms** | **0.1477 ms** |
| **WriteNKb** | **2048** | **2.562 ms** | **0.1291 ms** | **0.1893 ms** |
| **WriteNKb** | **4096** | **2.520 ms** | **0.2169 ms** | **0.3180 ms** |
