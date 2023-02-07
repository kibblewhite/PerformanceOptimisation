namespace Benchmarks;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class DictionaryPerfBenchmarks
{
    public Dictionary<Guid, DictionaryEntry> keyValuePairs = new();
    public Dictionary<Guid, DictionaryStructEntry> keyStructValuePairs = new();
    public Guid DictionaryStructEntryGuid = Guid.Parse("53514961-91e5-4e0a-bd47-aa74c8e82f4e");

    //[GlobalSetup]
    //public void GlobalSetup()
    //{
    //    // Place an instantiated `class` into the dictionary...
    //    DictionaryEntry dictionaryEntry = new();
    //    keyValuePairs.Add(dictionaryEntry.Id, dictionaryEntry);

    //    // Place an instantiated `struct` into the dictionary...
    //    DictionaryStructEntry dictionaryStructEntry = DictionaryStructEntry.Create(DictionaryStructEntryGuid);
    //    keyStructValuePairs.Add(dictionaryStructEntry.Id, dictionaryStructEntry);
    //}

    [Benchmark]
    public void OriginalApproachInsertingClass()
    {
        DictionaryEntry dictionaryEntry = new();
        if (keyValuePairs.ContainsKey(dictionaryEntry.Id) is false)
        {
            keyValuePairs[dictionaryEntry.Id] = dictionaryEntry;
            // keyValuePairs.Add(dictionaryEntry.Id, dictionaryEntry);
        }
    }

    //[Benchmark]
    //public void OriginalApproachUpdatingStructClass()
    //{
    //    DictionaryStructEntry dictionaryStructEntry = DictionaryStructEntry.Create(DictionaryStructEntryGuid);
    //    if (keyStructValuePairs.TryGetValue(dictionaryStructEntry.Id, out DictionaryStructEntry entry) is true)
    //    {
    //        DictionaryStructEntryGuid = Guid.NewGuid();
    //        entry.UpdateId(DictionaryStructEntryGuid);
    //        keyStructValuePairs[dictionaryStructEntry.Id] = entry;
    //    }
    //}

    //[Benchmark]
    //public void CollectionMarshalAddDefaultApproach()
    //{
    //    DictionaryEntry dictionaryEntry = new();

    //    // IMPORTANT: During this operation no items should be added/removed/updated to the dictionary - concurrent locking on the dictionary should be implemented
    //    ref DictionaryEntry? valOrNew = ref CollectionsMarshal.GetValueRefOrAddDefault(keyValuePairs, dictionaryEntry.Id, out bool exists);
    //    if (exists is false)
    //    {
    //        valOrNew = dictionaryEntry;
    //    }
    //}

    //[Benchmark]
    //public void CollectionMarshalNullRefApproach()
    //{
    //    DictionaryStructEntry dictionaryStructEntry = DictionaryStructEntry.Create(DictionaryStructEntryGuid);

    //    // IMPORTANT: During this operation no items should be added/removed/updated to the dictionary - concurrent locking on the dictionary should be implemented
    //    ref DictionaryStructEntry valOrNull = ref CollectionsMarshal.GetValueRefOrNullRef(keyStructValuePairs, dictionaryStructEntry.Id);
    //    if (Unsafe.IsNullRef(ref valOrNull) is false)
    //    {
    //        DictionaryStructEntryGuid = Guid.NewGuid();
    //        valOrNull.UpdateId(DictionaryStructEntryGuid);
    //    }
    //}
}
