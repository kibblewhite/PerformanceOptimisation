namespace Benchmarks;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class GcOnTheHeapBenchmarks
{
    private static readonly int ten_million = 10000000;

    [Benchmark]
    public void Create10MillionHeapObjects()
    {
        for (int i = 0; i < ten_million; i++)
        {
            HeapObject _ = new()
            {
                Value = i
            };
        }
    }

    [Benchmark]
    public void Create10MillionHeapObjectsWithGcInBatchMode()
    {
        GCSettings.LatencyMode = GCLatencyMode.Batch;
        for (int i = 0; i < ten_million; i++)
        {
            HeapObject _ = new()
            {
                Value = i
            };
        }

        GCSettings.LatencyMode = GCLatencyMode.Interactive;
    }

    [Benchmark]
    public void Create10MillionHeapPoolObjects()
    {
        List<HeapObject> heap_objects = new();
        for (int i = 0; i < ten_million; i++)
        {
            HeapObject obj = HeapPoolObject.GetInstanceOrNew(i);
            heap_objects.Add(obj);
        }

        // Do some work with the heap_pool_objects...

        // Release the heap_pool_objects back to the pool
        foreach (HeapObject obj in heap_objects)
        {
            HeapPoolObject.Release(obj);
        }
    }

    [Benchmark]
    public void Create10MillionHeapPoolObjectsWithGcInBatchMode()
    {
        GCSettings.LatencyMode = GCLatencyMode.Batch;
        List<HeapObject> heap_objects = new();
        for (int i = 0; i < ten_million; i++)
        {
            HeapObject obj = HeapPoolObject.GetInstanceOrNew(i);
            heap_objects.Add(obj);
        }

        // Do some work with the heap_pool_objects...

        // Release the heap_pool_objects back to the pool
        foreach (HeapObject obj in heap_objects)
        {
            HeapPoolObject.Release(obj);
        }

        GCSettings.LatencyMode = GCLatencyMode.Interactive;
    }
}
