namespace Benchmarks;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class CastingBenchmarks
{
    [Benchmark]
    public Person SingleHardCasting()
    {
        Person kibble = (Person)StaticObjects.Kibble;
        return kibble;
    }

    [Benchmark]
    public Person SingleSafeCasting()
    {
        Person? kibble = StaticObjects.Kibble as Person;
        return kibble!;
    }

    [Benchmark]
    public Person SingleMatchCasting()
    {
        if (StaticObjects.Kibble is not Person kibble)
        {
            return null!;
        };
        return kibble;
    }

    [Benchmark]
    public List<Person> EnumerableCastOfType()
        => StaticObjects.People.OfType<Person>().ToList();

    [Benchmark]
    public List<Person> EnumerableCastAs()
        => StaticObjects.People.Where(x => x as Person is not null).Cast<Person>().ToList();

    [Benchmark]
    public List<Person> EnumerableCastIs()
        => StaticObjects.People.Where(x => x is Person).Cast<Person>().ToList();

    [Benchmark]
    public List<Person> EnumerableHardCastIs()
        => StaticObjects.People.Where(x => x is Person).Select(x => (Person)x).ToList();

    [Benchmark]
    public List<Person> EnumerableHardCastTypeOf()
        => StaticObjects.People.Where(x => x.GetType() == typeof(Person)).Select(x => (Person)x).ToList();
}
