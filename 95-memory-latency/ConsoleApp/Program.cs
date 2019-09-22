using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ConsoleApp {

    [DisassemblyDiagnoser]
    [ShortRunJob]
    public class MemoryLatency {

        class X {
            public int Num1;

        }
        struct Y {
            public int Num1;
        }
        private const int N = 100001;

        [Benchmark (Baseline = true)]
        public int Classes () {
            int a = 0;
            for (int i = 0; i < N; i++) {
                var obj = new X { Num1 = i };
                a += obj.Num1;
            }
            return a;
        }

        [Benchmark]
        public int Structs () {
            int a = 0;
            for (int i = 0; i < N; i++) {
                var obj = new Y { Num1 = i };
                a += obj.Num1;
            }
            return a;
        }
    }
    class Program {
        static void Main (string[] args) {
            BenchmarkSwitcher.FromAssembly (typeof (Program).Assembly).Run (args);
        }
    }
}