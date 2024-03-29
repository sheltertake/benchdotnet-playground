﻿using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace BenchmarksUnsafe.Benchmarks
{
    [Config(typeof(Config))]
    [MemoryDiagnoser]
    public class UnsafeBenchmarks
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                Add(Job.Default.WithGcServer(true).WithId("Server"));
                Add(Job.Default.WithGcServer(false).WithId("Workstation"));
            }
        }
        [Benchmark]
        public byte[] Heap()
        {
            return new byte[10 * 1024];
        }
        [Benchmark]
        public unsafe void Stackalloc()
        {
            var array = stackalloc byte[10 * 1024];
            Consume(array);
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static unsafe void Consume(byte* input)
        {
        }
    }
}