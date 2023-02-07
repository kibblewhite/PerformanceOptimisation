namespace Samples.Readonly;

public sealed class Listings
{
    public List<int> list { get; set; } = new() { 1, 2, 3 };
    public HashSet<int> set { get; set; } = new() { 1, 2, 3 };
    public Dictionary<int, string> dictionary { get; set; } = new()
    {
        { 1, "1" },
        { 2, "2" },
        { 3, "3" },
    };

    public void SampleMethod()
    {
        list.Add(4);
        set.Add(4);
        dictionary.Add(4, "4");
    }

}
