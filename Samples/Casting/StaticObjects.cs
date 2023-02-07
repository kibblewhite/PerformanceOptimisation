namespace Samples.Casting;

public sealed class StaticObjects
{
    public static object Kibble = new Person
    {
        Id = Guid.NewGuid(),
        Name = "Kibble White"
    };

    public static List<object> People = Enumerable.Range(0, 10000)
        .Select(x => (object) new Person
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
        }).ToList();
}
