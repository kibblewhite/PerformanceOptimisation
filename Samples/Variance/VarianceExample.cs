namespace Samples.Variance;

// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/in-generic-modifier
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out-generic-modifier

public class VarianceExample
{
    // Covariance and Contravariance
    /// <summary>
    /// Covariance is when you can use a more derived type(subclass) than originally specified.
    /// Contravariance is when you can use a more base type(superclass) than originally specified.
    /// In C#, covariance is allowed for interfaces and delegates with the out keyword,
    /// while contravariance is allowed with the in keyword.
    /// </summary>
    public void Sample()
    {
        // Contravariance Behaviour
        IProducer<Base> baseProducer = new Producer<Base>();
        Base a = baseProducer.Produce(32);
        // Derived b = baseProducer.Produce(16);

        // Covariance Behaviour
        IProducer<Derived> derivedProducer = new Producer<Derived>();
        Derived c = derivedProducer.Produce(64);
        Base d = derivedProducer.Produce(128);

        // Contravariance Behaviour
        IConsumer<Derived> derivedConsumer = new Consumer<Derived>();
        _ = derivedConsumer.Consume(c);        // c => Derived
        // _ = derivedConsumer.Consume(a);     // a => Base

        // Covariance Behaviour
        IConsumer<Base> baseConsumer = new Consumer<Base>();
        _ = baseConsumer.Consume(a);        // a => Base
        _ = baseConsumer.Consume(c);        // c => Derived
        
        // Covariance Behaviour
        IProducer<Base> p = baseProducer;           // IProducer<Base>
        IProducer<Base> q = derivedProducer;        // IProducer<Derived>
        IProducer<Derived> r = derivedProducer;     // IProducer<Derived>
        // IProducer<Derived> s = baseProducer;     // IProducer<Base>

        // Covariant Behaviour
        IConsumer<Derived> t = derivedConsumer;     // IConsumer<Derived>
        IConsumer<Base> v = baseConsumer;           // IConsumer<Base>

        // Contravariance Behaviour
        IConsumer<Derived> u = baseConsumer;        // IConsumer<Base>
        // IConsumer<Base> w = derivedConsumer;     // IConsumer<Derived>
    }
}

public class Base
{
    public int Value { get; set; }
}

public class Derived : Base { }

public class Extended : Base
{
    public Guid Unique { get; } = Guid.NewGuid();
}

public interface IProducer<out T>
{
    T Produce(int value);
}

public interface IConsumer<in T>
{
    int Consume(T obj);
}

public class Producer<T> : IProducer<T>
{
    public T Produce(int value)
    {
        T? obj = Activator.CreateInstance<T>();
        Type? type = obj?.GetType();
        PropertyInfo? prop = type?.GetProperty(nameof(Base.Value));
        prop?.SetValue(obj, value, null);
        return obj;
    }
}

public class Consumer<T> : IConsumer<T>
{
    public int Consume(T obj)
    {
        Type? type = obj?.GetType();
        PropertyInfo? prop = type?.GetProperty(nameof(Base.Value));
        return Convert.ToInt32(prop?.GetValue(obj, null));
    }
}
