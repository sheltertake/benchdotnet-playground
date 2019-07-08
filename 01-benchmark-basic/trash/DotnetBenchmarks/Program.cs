using System;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MyBenchmarks {
    //public class Md5VsSha256 {
    //    private const int N = 10000;
    //    private readonly byte[] data;

    //    private readonly SHA256 sha256 = SHA256.Create ();
    //    private readonly MD5 md5 = MD5.Create ();

    //    public Md5VsSha256 () {
    //        data = new byte[N];
    //        new Random (42).NextBytes (data);
    //    }

    //    [Benchmark]
    //    public byte[] Sha256 () => sha256.ComputeHash (data);

    //    [Benchmark]
    //    public byte[] Md5 () => md5.ComputeHash (data);
    //}
    public class HelloWorld
    {
        public static int Counter = 0;
        //private readonly string HelloWorld = "HelloWorld";
        //private readonly StringBuilder HelloWorldSb = new StringBuilder("HelloWorld");
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
    public class Program {
        public static void Main (string[] args) {
            //var summary = BenchmarkRunner.Run<Md5VsSha256> ();
            var summary = BenchmarkRunner.Run<HelloWorld> ();
        }
    }
}