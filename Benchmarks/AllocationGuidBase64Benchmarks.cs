using Samples.AllocationGuidBase64;

namespace Benchmarks;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class AllocationGuidBase64Benchmarks
{
    private static readonly Guid TestIdAsGuid = Guid.Parse("f9983781-554e-45d9-ae8e-b0acf9e94505");
    private const string TestIdAsString = "gTeY_U5V2UWujrCs_elFBQ";

    [Benchmark]
    public Guid ToGuidFromString()
        => UUBase64.ToGuidFromString(TestIdAsString);

    [Benchmark]
    public string ToStringFromGuid()
        => UUBase64.ToStringFromGuid(TestIdAsGuid);

    [Benchmark]
    public Guid ToGuidFromStringOp()
        => UUBase64.ToGuidFromStringOp(TestIdAsString);

    [Benchmark]
    public string ToStringFromGuidOp()
        => UUBase64.ToStringFromGuidOp(TestIdAsGuid);
}
