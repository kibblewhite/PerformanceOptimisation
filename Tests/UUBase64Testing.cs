namespace Tests;

[TestClass]
public class UUBase64Testing
{
    [TestMethod]
    public void FromGuidToStringAndBack()
    {
        Guid value = Guid.NewGuid();
        string hashed = UUBase64.ToStringFromGuid(value);
        Guid result = UUBase64.ToGuidFromString(hashed);
        Console.WriteLine(result);
        Console.WriteLine(hashed);
        Assert.AreEqual(value, result);
    }

    [TestMethod]
    public void FromGuidToStringAndBackOp()
    {
        Guid value = Guid.NewGuid();
        string hashed = UUBase64.ToStringFromGuidOp(value);
        Guid result = UUBase64.ToGuidFromStringOp(hashed);
        Console.WriteLine(result);
        Console.WriteLine(hashed);
        Assert.AreEqual(value, result);
    }
}
