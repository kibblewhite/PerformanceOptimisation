namespace Tests;

[TestClass]
public class UnitTesting
{
    [TestMethod]
    public void BasicHeapMatchedValuesTest()
    {
        // AAA: (Arrange-Act-Assert)
        string stringValue = "Heylo World";
        int integerValue = 420;
        bool booleanValue = true;

        // Arrange
        HeapOfStructs item = new()
        {
            StringValue = stringValue,
            IntegerValue = integerValue,
            BooleanValue = booleanValue
        };

        // Act
        bool matched = item.MatchingValues(stringValue, integerValue, booleanValue);

        // Assert
        Assert.IsTrue(matched);
    }

    [TestMethod]
    public void BasicStackMatchedValuesTest()
    {
        // AAA: (Arrange-Act-Assert)
        string stringValue = "Heylo World";
        int integerValue = 420;
        bool booleanValue = true;

        // Arrange
        StackOfStructs item = new()
        {
            StringValue = stringValue,
            IntegerValue = integerValue,
            BooleanValue = booleanValue
        };

        // Act
        bool matched = item.MatchingValues(stringValue, integerValue, booleanValue);

        // Assert
        Assert.IsTrue(matched);
    }

    [TestMethod]
    public void CallMethods()
    {
        int x = 5;

        BaseX base_x = new();
        base_x.CallMethod(x);

        int y = 4;

        // calls the derived, because of the method signature matching...
        DerivedX derived_x = new();
        derived_x.CallMethod(y);

    }
}
