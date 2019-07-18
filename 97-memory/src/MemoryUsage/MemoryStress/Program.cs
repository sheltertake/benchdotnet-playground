using System;

namespace MemoryStress
{
    class Program
    {
        private static byte[] data;
        static void Main(string[] args)
        {
            Console.WriteLine("press exit|Rnum|Vnum");
            //https://stackoverflow.com/questions/32363719/how-to-loop-a-console-readline
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var type = input[0];
                var isNum = int.TryParse(input.Substring(1), out var num);
                if (isNum)
                {
                    if (type == 'R')
                    {
                        data = new byte[num * 1024 * 1024];
                        Console.WriteLine(data.Length);

                    }
                    else
                    {
                        byte[] volat = new byte[num * 1024 * 1024];
                        Console.WriteLine(volat.Length);

                    }
                }
                else
                {
                    Console.WriteLine("press exit|num");
                }
            }

        }
    }

}
