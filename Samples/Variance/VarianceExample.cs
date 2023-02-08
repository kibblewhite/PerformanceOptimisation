namespace Samples.Variance;

public class VarianceExample
{
    // Covariance and Contravariance 
    public void Sample()
    {
        // Contravariance Behaviour
        IProducer<Base> baseProducer = new Producer<Base>();
        Base a = baseProducer.Produce(32);
        // Derived b = baseProducer.Produce();

        // Covariance Behaviour
        IProducer<Derived> derivedProducer = new Producer<Derived>();
        Derived c = derivedProducer.Produce(64);
        Base d = derivedProducer.Produce(128);

        // Covariance Behaviour
        IConsumer<Base> baseConsumer = new Consumer<Base>();
        _ = baseConsumer.Consume(a);        // a => Base
        _ = baseConsumer.Consume(c);        // c => Derived

        // Contravariance Behaviour
        IConsumer<Derived> derivedConsumer = new Consumer<Derived>();
        _ = derivedConsumer.Consume(c); // c => Derived
        // derivedContravariant.Consume(new Base());

        IProducer<Base> p = baseProducer;           // IProducer<Base>
        IProducer<Base> q = derivedProducer;        // IProducer<Derived>
        IProducer<Derived> r = derivedProducer;     // IProducer<Derived>
        // IProducer<Derived> s = baseProducer;     // IProducer<Base>

        IConsumer<Derived> t = derivedConsumer;     // IConsumer<Derived>
        IConsumer<Derived> u = baseConsumer;        // IConsumer<Base>
        IConsumer<Base> v = baseConsumer;           // IConsumer<Base>
        // IConsumer<Base> w = derivedConsumer;     // IConsumer<Derived>
    }
}

public class Base
{
    public int Value { get; set; }
}

public class Derived : Base { }

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
