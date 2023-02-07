namespace Tests;

public static class HeapVsStackOfStructsExtensions
{
    public static bool MatchingValues(this HeapOfStructs item, string stringValue, int integerValue, bool booleanValue) => item.StringValue.Equals(stringValue, StringComparison.OrdinalIgnoreCase) is true
            && item.IntegerValue.Equals(integerValue) is true
            && item.BooleanValue.Equals(booleanValue) is true;

    public static bool MatchingValues(this StackOfStructs item, string stringValue, int integerValue, bool booleanValue) => item.StringValue.Equals(stringValue, StringComparison.OrdinalIgnoreCase) is true
            && item.IntegerValue.Equals(integerValue) is true
            && item.BooleanValue.Equals(booleanValue) is true;
}