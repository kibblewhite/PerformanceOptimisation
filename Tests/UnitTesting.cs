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
}
