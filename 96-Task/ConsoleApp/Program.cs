using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ConsoleApp {
    [DisassemblyDiagnoser]
    [ShortRunJob]
    public class AsyncVsSync {

        [Benchmark (Baseline = true)]
        public bool Sync () {
            return IsPrime (2147483647);
        }

        [Benchmark]
        public Task<bool> Async () {
            return Task.FromResult (IsPrime (2147483647));
        }

        // It's not the fastest algorithm,
        // but we will optimize it later.
        public static bool IsPrime (int n) {
            for (int i = 2; i <= n - 1; i++)
                if (n % i == 0)
                    return false;
            return true;
        }

    }
    class Program {
        static void Main (string[] args) {
            BenchmarkSwitcher.FromAssembly (typeof (Program).Assembly).Run (args);
        }
    }
}