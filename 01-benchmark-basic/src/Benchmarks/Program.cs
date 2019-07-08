using System;
using System.Linq;
using Benchmarks.Benchamarks;
using Benchmarks.Benchmarks;

namespace Benchmarks
{
    enum Scenarios
    {
        InaccurateTimestamping = 1,
        UseRelease = 2,
        NaturalNoise = 3,
        TrickyDistribution = 4,
        ColdStartVSSteadyState = 5,
        InsufficientNumberOfInvocations = 6,
        InfrastructureOverhead = 7,
        UnequalIterations = 8,
        LoopUnrolling = 9,
        DeadCodeElimination = 10,
        Inlining=11
    }
    class Program
    {
        static void Main(string[] args)
        {
            Enum.TryParse(typeof(Scenarios), args[0], out var c);
            switch (c)
            {
                case Scenarios.InaccurateTimestamping:
                    InaccurateTimestamping();
                    break;
                case Scenarios.UseRelease:
                    UseRelease();
                    break;
                case Scenarios.NaturalNoise:
                    NaturalNoise();
                    break;
                case Scenarios.TrickyDistribution:

                    TrickyDistribution();
                    break;
                case Scenarios.ColdStartVSSteadyState:

                    ColdStartVSSteadyState();
                    break;
                case Scenarios.InsufficientNumberOfInvocations:

                    InsufficientNumberOfInvocations();
                    break;

                case Scenarios.InfrastructureOverhead:

                    InfrastructureOverhead();
                    break;

                case Scenarios.UnequalIterations:

                    UnequalIterations();
                    break;
                case Scenarios.LoopUnrolling:
                    LoopUnrolling();
                    break;
                case Scenarios.DeadCodeElimination:
                    DeadCodeElimination();
                    break;
                case Scenarios.Inlining:
                    Inlining();
                    break;
            }



        }
        private static void Inlining()
        {
            Console.WriteLine(".NET-Specific Pitfalls");
            Console.WriteLine("Inlining");
            Console.WriteLine("Sometimes, the runtime can inline method calls, which can be pretty important for microbenchmarks.");
            var obj = new Inlining.Measurements();
            obj.Do();
            var obj2 = new Inlining.Measurements2();
            obj2.Do();
            Console.WriteLine("Advice: control inlining of the benchmarked methods");
        }
        private static void DeadCodeElimination()
        {
            Console.WriteLine(".NET-Specific Pitfalls");
            Console.WriteLine("Dead Code Elimination");
            Console.WriteLine(@"If you don’t use the results of your code, the code can be completely removed.");
            Loops.LoopDeadCodeElimination();
            Loops.LoopDeadCodeEliminationCollectResult();
            Console.WriteLine("Advice: always use results of your calculations");
        }
        private static void UseRelease()
        {
            Console.WriteLine("Executing a Benchmark in the Wrong Way");
            Console.WriteLine(@"Executing a benchmark in the wrong way
                Benchmarks should always be executed with enabled
            optimization(Release mode) without an attached debugger in a
                sterile environment.");
            
            Loops.LoopEmpty();
            Loops.LoopWithBody();
            Console.WriteLine("Advice: use Release and don't use empty loops to benchmark");
        }


        private static void NaturalNoise()
        {
            Console.WriteLine("Natural Noise");
            Console.WriteLine(@"Each benchmark iteration has random errors because of the natural noise.");

            Benchamarks.MyMaths.BenchIsPrime();
            Console.WriteLine("Advice: We can’t prevent natural noise");
        }

        private static void TrickyDistribution()
        {
            Console.WriteLine("Tricky Distributions");

            Console.WriteLine(@"Performance distributions often have a tricky form: they may have
                huge variance or include extremely high values. Such distribution
            should be carefully analyzed");

            Benchamarks.FileOperations.BadWriteTempFile();
            Benchamarks.FileOperations.BetterWriteTempFile();
            Console.WriteLine("Advice: always look at your distribution");
        }

        private static void ColdStartVSSteadyState()
        {
            Console.WriteLine("Measuring Cold Start Instead of Warmed Steady State");
            Console.WriteLine("Do you want to measure the cold start or the warmed steady state ? ");

            Console.WriteLine(@" Measuring cold start instead of warmed steady state
            The first benchmark iterations are “cold” and can take much more
                time than subsequent “warm” iterations.");

           
            Loops.LoopColdStart();
            Loops.LoopColdStart();
            Loops.LoopColdStart();
            Loops.LoopColdStart();
            Loops.LoopFindSteadyState();
            Console.WriteLine("Advice: use different approaches for cold and warm states");
        }

        private static void InsufficientNumberOfInvocations()
        {
            Console.WriteLine("Insufficient Number of Invocations");
            Console.WriteLine(@"In the case of microbenchmarks, the measured code should be
            repeated many times. Otherwise, errors will be huge because
            timestamping is limited on the hardware level and can’t correctly
            measure high-speed operations.");
            
            Loops.LoopOneInvocation();
            Loops.LoopManyInvocations();
            Console.WriteLine("Advice: do many invocations");
        }

        private static void InfrastructureOverhead()
        {
            Console.WriteLine("Benchmark infrastructure overhead");
            Console.WriteLine(@"Each benchmark includes an “infrastructure” part that helps you
            to get reliable and repeatable results. This infrastructure can affect
            results and spoil the measurements.Thus, the overhead should be
            calculated and removed from the final results.");
            
            Loops.LoopConversion();
            Loops.LoopConversionWithoutInfra();
            Console.WriteLine("Advice: always calculate your infrastructure overhead");
        }

        private static void UnequalIterations()
        {
            Console.WriteLine("Unequal iterations");
            Console.WriteLine(@"If you repeat a code several times, you should be sure that all
                repetitions take the same amount of time.
                We also have other kinds of pitfalls because of optimizations in .NET runtimes:");
           
            Loops.ItereationUnequal(16777215);
            Loops.ItereationUnequal(16777215);
            Loops.ItereationUnequal(16777216);
            Loops.ItereationUnequal(16777217);
            Loops.ItereationUnequal(16777218);
            Console.WriteLine("Advice: always calculate your infrastructure overhead");
        }

        private static void LoopUnrolling()
        {
            Console.WriteLine(".NET-Specific Pitfalls");
            Console.WriteLine("Loop Unrolling");
            Loops.LoopUnrolling();
            Loops.LoopAvoidUnrolling(1000000001, 1000000002);
            Console.WriteLine("Advice: use variables instead of constants in loops");
        }
        
        private static void InaccurateTimestamping()
        {

            

           Console.WriteLine("Inaccurate Timestamping");
            Console.WriteLine(@"DateTime - based benchmarks have many problems like pur
                resolution, so it’s better to use Stopwatch for time measurements.");
            Timestamps.SortBad(10000);
            Timestamps.SortBad(10000);
            Timestamps.SortBad(10000);
            Timestamps.SortBetter(10000);
            Timestamps.SortBetter(10000);
            Timestamps.SortBetter(10000);

            Timestamps.SortBad(10);
            Timestamps.SortBad(10);
            Timestamps.SortBad(10);
            Timestamps.SortBetter(10);
            Timestamps.SortBetter(10);
            Timestamps.SortBetter(10);

            Timestamps.SortBad(2);
            Timestamps.SortBad(2);
            Timestamps.SortBad(2);
            Timestamps.SortBetter(2);
            Timestamps.SortBetter(2);
            Timestamps.SortBetter(2);
            Console.WriteLine("Advice: prefer Stopwatch over DateTime");
        }
    }
}
