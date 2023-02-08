namespace Samples.StrangeTests;

public class BaseX
{
    public void CallMethod(int x) => Console.WriteLine($"Base.F(int) => {x}");
}

public class DerivedX : BaseX
{
    public void CallMethod(double x) => Console.WriteLine($"Derived.F(double) => {x}");
}

public class Crazy
{
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

    public void CallDeligate()
    {
        // Func delegate is already present
        Func<int, int> a = x => x;
        Do(a);

        // Lambda
        Do(x => x);

        // static method group
        Do(Crazy.C.F);

        // Instance level method group
        C obj = new();
        Do(obj.G);

        // strongly typed delegate
        F f = x => x;
        Do(f.Invoke);

        // local function
        Helper();
    }

    internal class C
    {
        public static int F(int x) => x;
        public int G(int x) => x;
    }
    delegate int F(int x);

    internal void Helper()
    {
        int F(int x) => x;
        Do(F);
    }

    /// <summary>
    /// Call the function delegate in as many ways possible
    /// </summary>
    /// <param name="f"></param>
    public void Do(Func<int, int> f)
    {
        f(5);
    }

    public void StructLock()
    {
        S s = new();
        _ = s;
        // lock can not occur because it has no sync table entry
        //lock (s) { }
    }
}

public struct S
{
    // no type handle which references to the method table, means that a virtual method can not be resolved when the runtime looks for it
    //public virtual void F() { }
}

// type handle which leads to a type descriptor, which lists all the methds, fields/properties, can not be found and thus struct can not be inherited
//public struct T : S { }

class StructClass
{
    // - missing elements in the struct compared to a class
    // sync table entry (unique object)
    // type handle (ref to method table, same for all objects of type StructClass and is why GetHashCode() of same classes without being overridden is the same)
}
