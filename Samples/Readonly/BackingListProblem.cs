namespace Samples.Readonly;

public sealed class BackingListProblem
{
    private readonly List<int> _list = new();
    public IReadOnlyList<int> List => _list; // -> .AsReadOnly();
    public void AddInt(int i) => _list.Add(i);
}
