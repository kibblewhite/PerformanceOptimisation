using BenchmarkDotNet.Configs;

namespace Benchmarks;

internal class Program
{

    static readonly ManualConfig custom_config = DefaultConfig.Instance.WithArtifactsPath(@"Benchmarks/BenchmarkDotNet.Artifacts");

    /// <summary>
    /// dotnet run --project Benchmarks -c Release <benchmark-name-here>..<space-seperated-another-benchmark-name-here>
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case Benchmarks.HeapVsStackBenchmarks:
                    BenchmarkRunner.Run<HeapVsStackBenchmarks>(custom_config);
                    break;
                case Benchmarks.GcOnTheHeapBenchmarks:
                    BenchmarkRunner.Run<GcOnTheHeapBenchmarks>(custom_config);
                    break;
                case Benchmarks.CpuBenchmarks:
                    BenchmarkRunner.Run<CpuBenchmarks>(custom_config);
                    break;
                case Benchmarks.DictionaryPerfBenchmarks:
                    BenchmarkRunner.Run<DictionaryPerfBenchmarks>(custom_config);
                    break;
                case Benchmarks.CastingBenchmarks:
                    BenchmarkRunner.Run<CastingBenchmarks>(custom_config);
                    break;
                case Benchmarks.SealedBenchmarks:
                    BenchmarkRunner.Run<SealedBenchmarks>(custom_config);
                    break;
            }
        }

        Console.WriteLine("Completed Benchmarking");
    }
}
