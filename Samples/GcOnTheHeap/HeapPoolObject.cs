namespace Samples.GcOnTheHeap;

/// <summary>
/// Benchmark results show that this is a bad idea
/// </summary>
public static class HeapPoolObject
{
    // note: Investigate the use of `ConcurrentStack<>` with locking
    private static readonly Stack<HeapObject> objectPool = new();

    public static HeapObject GetInstanceOrNew(int i) => objectPool.Count > 0
            ? objectPool.Pop()
            : new HeapObject() { Value = i };

    public static void Release(HeapObject heap_obj) => objectPool.Push(heap_obj);
}
