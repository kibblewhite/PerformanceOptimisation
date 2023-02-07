namespace Benchmarks;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class HeapVsStackBenchmarks
{
    [Benchmark]
    public HeapOfStructs InstantiateHeapOfStructs() => new()
    {
        StringValue = "some string",
        IntegerValue = 123,
        BooleanValue = true
    };

    [Benchmark]
    public StackOfStructs InstantiateStackOfStructs() => new()
    {
        StringValue = "some string",
        IntegerValue = 123,
        BooleanValue = true
    };
}