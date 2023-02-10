namespace Samples.Variance;

public class VarianceExample
{
    // Covariance and Contravariance
    /// <remarks>The summary is the best explaination that I have come across so far...</remarks>
    /// <summary>
    /// Covariance and Contravariance are concepts in C# that deal with the compatibility of generic type parameters in inheritance relationships.
    /// Covariance allows you to use a more derived type(subclass) than originally specified.For example, in the given code, the IProducer<Base> interface can be assigned to IProducer<Derived>.
    /// Contravariance, on the other hand, allows you to use a more base type (superclass) than originally specified. In the given code, the IConsumer<Derived> interface can be assigned to IConsumer<Base>.
    /// Covariance and Contravariance are indicated in C# by using the out keyword for covariance and the in keyword for contravariance. Interfaces and delegates can be covariant or contravariant, but classes cannot. This is because classes are invariant, which means they can only be used with the type they are declared with, and cannot be assigned to or from subtypes or supertypes.
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

        //

        ICovariant<Object> icovobj = new CovariantSample<Object>();
        ICovariant<String> icovstr = new CovariantSample<String>();

        // You can assign istr to iobj because
        // the ICovariant interface is covariant.
        icovobj = icovstr;

        //

        IContravariant<Object> icontraobj = new ContravariantSample<Object>();
        IContravariant<String> icontrastr = new ContravariantSample<String>();

        // You can assign iobj to istr because
        // the IContravariant interface is contravariant.
        icontrastr = icontraobj;
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

// Covariant interface.
interface ICovariant<out R> { }

// Extending covariant interface.
interface IExtCovariant<out R> : ICovariant<R> { }

// Implementing covariant interface.
class CovariantSample<R> : ICovariant<R> { }

// Contravariant interface.
interface IContravariant<in A> { }

// Extending contravariant interface.
interface IExtContravariant<in A> : IContravariant<A> { }

// Implementing contravariant interface.
class ContravariantSample<A> : IContravariant<A> { }
