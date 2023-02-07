namespace Samples.Dictionary;

/// <summary>
/// When using a struct as a value in a dictionary, retrieving the value from the dictionary
/// will create a copy of the struct. Updating the value through this copy will not affect
/// the original value stored in the dictionary. To update the value, you must access the
/// dictionary directly and update the original value stored there.
/// </summary>
/// <remarks>
/// This can be over come by the use of <see cref="CollectionsMarshal"/>; 
/// reference the method <see cref="DictionaryPerf.CollectionMarshalNullRefApproach"/>
/// </remarks>
public struct DictionaryStructEntry
{
    public Guid Id { get; private set; }
    private DictionaryStructEntry(Guid id) => Id = id;
    public static DictionaryStructEntry Create(Guid id) => new(id);
    public void UpdateId(Guid id) => Id = id;
}
