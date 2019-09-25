using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ConsoleApp
{
    [ShortRunJob]
    [MemoryDiagnoser]
    [DisassemblyDiagnoser]
    public class Benchmark
    {

        private const int N = 1_000_000;

        [Benchmark]
        public int ClassP()
        {
            var responses = new List<ClassWithProps>(N);
            for (int i = 0; i < N; i++)
            {
                responses.Add(CalcReturnClassWithProps());
            }
            return responses.Count;
        }
        [Benchmark]
        public int ClassF()
        {
            var responses = new List<ClassWithFields>(N);
            for (int i = 0; i < N; i++)
            {
                responses.Add(CalcReturnClassWithFields());
            }
            return responses.Count;
        }
        [Benchmark]
        public int StructP()
        {
            var responses = new List<StructWithProps>(N);
            for (int i = 0; i < N; i++)
            {
                var calcReturnStructWithProps = CalcReturnStructWithProps();
                responses.Add(calcReturnStructWithProps);
            }
            return responses.Count;
        }
        [Benchmark]
        public int StructF()
        {
            var responses = new List<StructWithFields>(N);
            for (int i = 0; i < N; i++)
            {
                responses.Add(CalcReturnStructWithFields());
            }
            return responses.Count;
        }
        [Benchmark]
        public int Tuple()
        {
            var responses = new List<Tuple<int, string>>(N);
            for (int i = 0; i < N; i++)
            {
                responses.Add(CalcReturnTuple());
            }
            return responses.Count;
        }
        [Benchmark]
        public int Integer()
        {
            var responses = new List<int>(N);
            for (int i = 0; i < N; i++)
            {
                responses.Add(CalcReturnInt());
            }
            return responses.Count;
        }
        public ClassWithProps CalcReturnClassWithProps()
        {
            return new ClassWithProps()
            {
                Code = 1,
                Message = "Error Message"
            };
        }
        public ClassWithFields CalcReturnClassWithFields()
        {
            return new ClassWithFields()
            {
                Code = 1,
                Message = "Error Message"
            };
        }
        public StructWithProps CalcReturnStructWithProps()
        {
            return new StructWithProps()
            {
                Code = 1,
                Message = "Error Message"
            };
        }
        public StructWithFields CalcReturnStructWithFields()
        {
            return new StructWithFields()
            {
                Code = 1,
                Message = "Error Message"
            };
        }
        public Tuple<int,string> CalcReturnTuple()
        {
            return new Tuple<int, string>(1, "ErrorMessage");
        }
        public int CalcReturnInt()
        {
            return 1;
        }
        public class ClassWithProps
        {
            public int Code { get; set; }
            public string Message { get; set; }
        }
        public class ClassWithFields
        {
            public int Code;
            public string Message;
        }

        public struct StructWithFields
        {
            public int Code;
            public string Message;
        }

        public struct StructWithProps
        {
            public int Code { get; set; }
            public string Message { get; set; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }
}
