namespace Samples.Sealed;

/// <summary>
/// in .editorconfig
/// [*.cs]
/// dotnet_diagnostic.CA1852.severity = warning
/// </summary>

public class BaseClass
{
    public virtual void ExampleVoidMethod() { }
    public virtual int ExampleIntMethod() => 0;
}

public class OpenClass : BaseClass
{
    public override void ExampleVoidMethod() { }
    public override int ExampleIntMethod() => 64;
}

public sealed class SealedClass : BaseClass
{
    public override void ExampleVoidMethod() { }
    public override int ExampleIntMethod() => 512;
}

// Can not extend sealed class
// note: it might had been better to have classes sealed by default and open them up instead
// also -> inheritance is becoming more of an anti-pattern these days and people prefer composition
// public class ExtendedClass : SealedClass { }

#region [inheritance]
public class Vehicle
{
    public void StartEngine() => Console.WriteLine("Engine started");
}
public class Bus : Vehicle { }

// Bus bus = new(); bus.StartEngine();
#endregion [inheritance]

#region [composition]
public class Engine
{
    public void Start() => Console.WriteLine("Engine started");
}
public class Car
{
    private readonly Engine engine;
    public Car() => engine = new Engine();
    public void StartEngine() => engine.Start();
}
#endregion [composition]
