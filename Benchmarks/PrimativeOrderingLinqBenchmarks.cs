namespace Benchmarks;

// Something worth noting, is that in some cases, even though CPU/resource time is
// spent on a method/action, it does not mean over all real life performance issues
// this is because if less memory is used, there can be less time is spent running GC
// TextSort vs. TextOrder as an example

[MemoryDiagnoser(false)]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class PrimativeOrderingLinqBenchmarks
{
    private readonly Random _random = new(420);
    private readonly int _range_start = 1;
    private readonly int _range_count = 120;

    [Benchmark]
    public int[] OrderBy()
    {
        int[] items = Enumerable.Range(_range_start, _range_count).Select(_ => _random.Next()).ToArray();
        return items.OrderBy(x => x).ToArray();
    }

    [Benchmark]
    public int[] Order()
    {
        int[] items = Enumerable.Range(_range_start, _range_count).Select(_ => _random.Next()).ToArray();
        return items.Order().ToArray();
    }

    [Benchmark]
    public int[] OrderByDesc()
    {
        int[] items = Enumerable.Range(_range_start, _range_count).Select(_ => _random.Next()).ToArray();
        return items.OrderByDescending(x => x).ToArray();
    }

    [Benchmark]
    public int[] OrderDesc()
    {
        int[] items = Enumerable.Range(_range_start, _range_count).Select(_ => _random.Next()).ToArray();
        return items.OrderDescending().ToArray();
    }

    [Benchmark]
    public int[] Sort()
    {
        int[] items = Enumerable.Range(_range_start, _range_count).Select(_ => _random.Next()).ToArray();
        Array.Sort(items);
        return items;
    }

    [Benchmark]
    public int[] SpanSort()
    {
        Span<int> items = Enumerable.Range(_range_start, _range_count).Select(_ => _random.Next()).ToArray();
        items.Sort();
        return items.ToArray(); // re-allocates more memory
    }

    [Benchmark]
    public string[] TextOrderBy()
    {
        string[] items = Enumerable.Range(_range_start, _range_count).Select(_ => _random.Next().ToString()).ToArray();
        return items.OrderBy(x => x).ToArray();
    }

    [Benchmark]
    public string[] TextOrder()
    {
        string[] items = Enumerable.Range(_range_start, _range_count).Select(_ => _random.Next().ToString()).ToArray();
        return items.Order().ToArray();
    }

    [Benchmark]
    public string[] TextOrderByDesc()
    {
        string[] items = Enumerable.Range(_range_start, _range_count).Select(_ => _random.Next().ToString()).ToArray();
        return items.OrderByDescending(x => x).ToArray();
    }

    [Benchmark]
    public string[] TextOrderDesc()
    {
        string[] items = Enumerable.Range(_range_start, _range_count).Select(_ => _random.Next().ToString()).ToArray();
        return items.OrderDescending().ToArray();
    }

    [Benchmark]
    public string[] TextSort()
    {
        string[] items = Enumerable.Range(_range_start, _range_count).Select(_ => _random.Next().ToString()).ToArray();
        Array.Sort(items);
        return items;
    }

    [Benchmark]
    public string[] TextSpanSort()
    {
        Span<string> items = Enumerable.Range(_range_start, _range_count).Select(_ => _random.Next().ToString()).ToArray();
        items.Sort();
        return items.ToArray(); // re-allocates more memory
    }
}

// ```md
// |          Method |      Mean |     Error |    StdDev | Rank | Allocated |
// |---------------- |----------:|----------:|----------:|-----:|----------:|
// |            Sort |  2.242 us | 0.0390 us | 0.0449 us |    1 |     416 B |
// |        SpanSort |  2.331 us | 0.0377 us | 0.0353 us |    2 |     680 B |
// |           Order |  5.013 us | 0.0893 us | 0.0835 us |    3 |    1384 B |
// |     OrderByDesc |  5.042 us | 0.0612 us | 0.0511 us |    3 |    1648 B |
// |         OrderBy |  5.113 us | 0.0976 us | 0.2263 us |    3 |    1648 B |
// |       OrderDesc |  5.153 us | 0.0721 us | 0.0674 us |    3 |    1384 B |
// |       TextOrder | 23.461 us | 0.3937 us | 0.3683 us |    4 |    4793 B |
// |     TextOrderBy | 23.841 us | 0.4331 us | 0.3840 us |    4 |    5297 B |
// | TextOrderByDesc | 24.217 us | 0.4812 us | 0.9830 us |    4 |    5296 B |
// |   TextOrderDesc | 25.684 us | 0.6974 us | 1.9898 us |    5 |    4792 B |
// |        TextSort | 31.843 us | 0.7528 us | 2.1356 us |    6 |    3313 B |
// |    TextSpanSort | 34.589 us | 1.1420 us | 3.2766 us |    7 |    3817 B |
// ```