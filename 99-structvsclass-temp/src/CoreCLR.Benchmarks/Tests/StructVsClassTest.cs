using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using StructVsClassLib;

namespace CoreCLR.Benchmarks.Tests
{
    [CoreJob]
    [MemoryDiagnoser]
    [GcForce(false)]
    public class StructVsClassTest
    {

        [Params(1_000, 10_000, 100_000)]
        public int Amount { get; set; }
        private StructVsClass Library = new StructVsClass();

        [GlobalSetup]
        public void Setup()
        {
            // Warm up pool
            var array = ArrayPool<InputDataStruct>.Shared.Rent(Amount);
            ArrayPool<InputDataStruct>.Shared.Return(array);
        }

        [Benchmark]
        public List<string> PeopleEmployeedWithinLocation_Classes()
        {
            var ret = Library.PeopleEmployeedWithinLocation_Classes(Amount);
            return ret;
        }

        [Benchmark]
        public List<string> PeopleEmployeedWithinLocation_Structs()
        {
            var ret = Library.PeopleEmployeedWithinLocation_Structs(Amount);
            return ret;
        }

        [Benchmark]
        public List<string> PeopleEmployeedWithinLocation_ArrayPoolStructs()
        {
            var ret = Library.PeopleEmployeedWithinLocation_ArrayPoolStructs(Amount);
            return ret;
        }

    }


    /*
        BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17134.829 (1803/April2018Update/Redstone4)
        Intel Core i5-5200U CPU 2.20GHz (Broadwell), 1 CPU, 4 logical and 2 physical cores
        .NET Core SDK=2.2.300
          [Host] : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
          Core   : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT

        Job=Core  Runtime=Core

        |                                         Method | Amount |        Mean |        Error |       StdDev |     Gen 0 |    Gen 1 |    Gen 2 |  Allocated |
        |----------------------------------------------- |------- |------------:|-------------:|-------------:|----------:|---------:|---------:|-----------:|
        |          PeopleEmployeedWithinLocation_Classes |   1000 |    564.8 us |     5.362 us |     5.015 us |   40.0391 |        - |        - |    62.6 KB |
        |          PeopleEmployeedWithinLocation_Structs |   1000 |    546.1 us |     8.412 us |     7.457 us |   24.4141 |        - |        - |   39.13 KB |
        | PeopleEmployeedWithinLocation_ArrayPoolStructs |   1000 |    544.6 us |     5.605 us |     4.969 us |         - |        - |        - |    1.35 KB |
        |          PeopleEmployeedWithinLocation_Classes |  10000 |  5,853.6 us |   114.371 us |   131.709 us |  132.8125 |  62.5000 |        - |   625.1 KB |
        |          PeopleEmployeedWithinLocation_Structs |  10000 |  5,773.8 us |    88.909 us |    83.166 us |  117.1875 | 117.1875 | 117.1875 |  390.69 KB |
        | PeopleEmployeedWithinLocation_ArrayPoolStructs |  10000 |  6,422.5 us |   109.107 us |   102.059 us |   54.6875 |  23.4375 |        - |  327.79 KB |
        |          PeopleEmployeedWithinLocation_Classes | 100000 | 67,868.4 us |   714.400 us |   633.297 us | 1000.0000 | 500.0000 | 125.0000 | 6250.11 KB |
        |          PeopleEmployeedWithinLocation_Structs | 100000 | 56,729.0 us |   840.356 us |   744.953 us |  222.2222 | 222.2222 | 222.2222 | 3906.31 KB |
        | PeopleEmployeedWithinLocation_ArrayPoolStructs | 100000 | 59,953.1 us | 1,110.037 us | 1,038.329 us |  222.2222 | 111.1111 |        - | 1483.34 KB |



|                                         Method | Amount |        Mean |       Error |      StdDev |      Median |     Gen 0 |    Gen 1 |    Gen 2 |  Allocated |
|----------------------------------------------- |------- |------------:|------------:|------------:|------------:|----------:|---------:|---------:|-----------:|
|          PeopleEmployeedWithinLocation_Classes |   1000 |    693.7 us |    26.48 us |    75.13 us |    670.7 us |   40.0391 |   0.9766 |        - |    62.6 KB |
|          PeopleEmployeedWithinLocation_Structs |   1000 |    565.0 us |    11.06 us |    20.51 us |    555.6 us |   24.4141 |        - |        - |   39.13 KB |
| PeopleEmployeedWithinLocation_ArrayPoolStructs |   1000 |    547.7 us |    10.31 us |    10.13 us |    549.1 us |         - |        - |        - |    1.35 KB |
|          PeopleEmployeedWithinLocation_Classes |  10000 |  5,782.6 us |    77.40 us |    68.62 us |  5,761.5 us |  140.6250 |  70.3125 |        - |   625.1 KB |
|          PeopleEmployeedWithinLocation_Structs |  10000 |  5,876.3 us |   116.13 us |   102.95 us |  5,875.1 us |  117.1875 | 117.1875 | 117.1875 |  390.69 KB |
| PeopleEmployeedWithinLocation_ArrayPoolStructs |  10000 |  6,574.3 us |   116.77 us |   109.23 us |  6,544.5 us |   54.6875 |  23.4375 |        - |  327.79 KB |
|          PeopleEmployeedWithinLocation_Classes | 100000 | 74,195.9 us | 1,459.72 us | 2,847.07 us | 73,629.3 us | 1000.0000 | 571.4286 | 142.8571 |  6250.1 KB |
|          PeopleEmployeedWithinLocation_Structs | 100000 | 55,691.8 us | 1,101.61 us | 1,081.93 us | 55,419.3 us |  300.0000 | 300.0000 | 300.0000 | 3906.31 KB |
| PeopleEmployeedWithinLocation_ArrayPoolStructs | 100000 | 62,150.5 us | 1,095.20 us | 1,024.45 us | 62,022.8 us |  125.0000 |        - |        - | 1483.34 KB |

     */

}
