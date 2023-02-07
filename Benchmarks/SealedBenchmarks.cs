namespace Benchmarks;

/// <summary>
/// in .editorconfig
/// [*.cs]
/// dotnet_diagnostic.CA1852.severity = warning
/// </summary>

[MemoryDiagnoser(false)]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class SealedBenchmarks
{
    private readonly BaseClass _baseClass = new();
    private readonly OpenClass _openClass = new();
    private readonly SealedClass _sealedClass = new();

    private readonly OpenClass[] _openClasses = new OpenClass[1];
    private readonly SealedClass[] _sealedClasses = new SealedClass[1];

    [Benchmark]
    public void OpenVoid() => _openClass.ExampleVoidMethod();

    [Benchmark]
    public void SealedVoid() => _sealedClass.ExampleVoidMethod();

    [Benchmark]
    public int OpenInt() => _openClass.ExampleIntMethod() + 1337;

    [Benchmark]
    public int SealedInt() => _sealedClass.ExampleIntMethod() + 1337;

    [Benchmark]
    public bool IsCheckOpen() => _baseClass is OpenClass;

    [Benchmark]
    public bool IsCheckSealed() => _baseClass is SealedClass;

    [Benchmark]
    public void StoreOpen() => _openClasses[0] = _openClass;

    [Benchmark]
    public void StoreSealed() => _sealedClasses[0] = _sealedClass;

    [Benchmark]
    public Span<OpenClass> SpanOpen() => _openClasses;

    [Benchmark]
    public Span<SealedClass> SpanSelaed() => _sealedClasses;
}
