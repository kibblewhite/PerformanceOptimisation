using Samples.Readonly;

namespace Tests;

/// <summary>
/// https://www.youtube.com/watch?v=7hBPI0xYezo
/// </summary>

[TestClass]
public class ReadonlyUnitTesting
{
    [TestMethod]
    public void BasicTest()
    {
        Listings listings = new();
        listings.list.Add(4);
        listings.set.Add(4);
        listings.dictionary.Add(4, "4");

        Assert.IsTrue(listings.list.Contains(4));
    }

    [TestMethod]
    public void BackingReadonlyProblem()
    {
        BackingListProblem backingListProblem = new();

        // backingListProblem.AddInt(27);
        ((List<int>)backingListProblem.List).Add(27);

        Assert.IsTrue(backingListProblem.List.Contains(27));
    }
}
