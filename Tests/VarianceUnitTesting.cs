namespace Tests;

[TestClass]
public class VarianceUnitTesting
{
    [TestMethod]
    public void BaseCovariantTest()
    {
        int value = 16;
        IProducer<Derived> derivedProducer = new Producer<Derived>();
        Derived c = derivedProducer.Produce(value);

        IConsumer<Base> baseConsumer = new Consumer<Base>();
        int returned = baseConsumer.Consume(c);

        Assert.AreEqual(value, returned);
    }

    [TestMethod]
    public void DerivedCovariantTest()
    {
        // Consumer example
        int value = 512;
        IProducer<Derived> derivedProducer = new Producer<Derived>();
        Derived c = derivedProducer.Produce(value);

        IConsumer<Derived> derivedConsumer = new Consumer<Derived>();
        int returned = derivedConsumer.Consume(c); // c => Derived

        Assert.AreEqual(value, returned);
    }

    [TestMethod]
    public void IProducer_Contravariance_Test()
    {
        IProducer<Base> baseProducer = new Producer<Base>();

        Base a = baseProducer.Produce(32);

        Assert.IsInstanceOfType(a, typeof(Base));
    }

    [TestMethod]
    public void IConsumer_Covariance_Test()
    {
        IConsumer<Base> baseConsumer = new Consumer<Base>();
        IConsumer<Base> v = baseConsumer;

        Base a = new() { Value = 32 };
        Derived c = new() { Value = 64 };

        int baseConsumed = v.Consume(a);
        int derivedConsumed = v.Consume(c);

        Assert.AreEqual(32, baseConsumed);
        Assert.AreEqual(64, derivedConsumed);
    }

    [TestMethod]
    public void IConsumer_Contravariance_Test()
    {
        IConsumer<Derived> derivedConsumer = new Consumer<Derived>();

        Derived c = new() { Value = 64 };

        int derivedConsumed = derivedConsumer.Consume(c);

        Assert.AreEqual(64, derivedConsumed);
    }
}
