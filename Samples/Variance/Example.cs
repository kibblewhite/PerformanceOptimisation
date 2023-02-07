namespace Samples.Variance;

internal class Example
{
    public void Sample()
    {
        // Covariant example
        ICovariant<Derived> derivedCovariant = new Covariant<Derived>() { InternalObj = new Derived() };
        ICovariant<Base> baseCovariant = derivedCovariant;
        Console.WriteLine(baseCovariant.InternalObj.Value);

        // Contravariant example
        IContravariant<Base> baseContravariant = new Contravariant<Base>();
        IContravariant<Derived> derivedContravariant = baseContravariant;
        derivedContravariant.SetObject(new Derived());
    }
}

class Base
{
    public int Value { get; set; }
}

class Derived : Base
{
    public new int Value { get; set; }
}

interface ICovariant<out T>
{
    T InternalObj { get; }
}

interface IContravariant<in T>
{
    void SetObject(T obj);
}

class Covariant<T> : ICovariant<T>
{
    public required T InternalObj { get; set; }
}

class Contravariant<T> : IContravariant<T>
{
    public void SetObject(T obj) => Console.WriteLine(obj);
}
