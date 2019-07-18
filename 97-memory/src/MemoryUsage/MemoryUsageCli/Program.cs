using System;
using System.Diagnostics;

namespace MemoryUsageCli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("press exit|1 - bench|2 - str|3 - 64|4 - 128|5 - 16|6 - while16");
            //https://stackoverflow.com/questions/32363719/how-to-loop-a-console-readline
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                switch (input[0])
                {
                    case '1':
                        BenchIsPrime();
                        break;
                    case '2':
                        var str = MemoryUsage.MemoryUsageHelper.GetString();
                        Console.WriteLine(str.Length);
                        break;
                    case '3':
                        byte[] data = new byte[64 * 1024 * 1024];
                        Console.WriteLine(data.Length);
                        break;
                    case '4':
                        byte[] data2 = new byte[64 * 1024 * 1024 * 2];
                        Console.WriteLine(data2.Length);
                        break;
                    case '5':
                        byte[] data3 = new byte[16 * 1024 * 1024];
                        Console.WriteLine(data3.Length);
                        break;
                    case '6':
                        for (int i = 0; i < 100; i++)
                        {
                            byte[] data4 = new byte[16 * 1024 * 1024 + i * 1024 * 1024]; //16Mb + 1|99
                            Console.WriteLine(data4.Length);
                        }
                        break;
                }
                
            }
        }

        static void BenchIsPrime()
        {
            var stopwatch1 = Stopwatch.StartNew();
            IsPrime(2147483647);
            stopwatch1.Stop();
            Console.WriteLine(stopwatch1.ElapsedMilliseconds);

        }

        // It's not the fastest algorithm,
        // but we will optimize it later.
        static bool IsPrime(int n)
        {
            for (int i = 2; i <= n - 1; i++)
                if (n % i == 0)
                    return false;
            return true;
        }
    }
}
