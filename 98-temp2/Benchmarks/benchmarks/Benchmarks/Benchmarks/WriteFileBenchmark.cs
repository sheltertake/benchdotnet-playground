using System;
using System.Collections.Generic;
using System.IO;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Benchmarks
{
    //[SimpleJob(
    //    warmupCount: 1,
    //    invocationCount: 2,
    //    targetCount: 3,
    //    launchCount: 1
    //    )]
    [MediumRunJob] //IterationCount=15, LaunchCount=2, warmupCount=10 // targetCount: 256?

    [RPlotExporter]
    public class WriteFileBenchmark
    {
        //[Params(1024, 2048, 4096)]
        //public int Kb { get; set; }

        [Benchmark]
        public void Write64Mb()
        {
            byte[] data = new byte[64 * 1024 * 1024];//64 * 1024 * 1024
            var fileName = Path.GetTempFileName();
            File.WriteAllBytes(fileName, data);
            File.Delete(fileName);
        }
    }
}
