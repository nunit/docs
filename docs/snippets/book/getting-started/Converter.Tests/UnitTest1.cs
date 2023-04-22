namespace Converter.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    #region OutOfTheBoxTest
    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    #endregion

    #region FirstTest
    [Test]
    public void MathWorksAsExpected()
    {
        var result = 2 + 2;

        Assert.That(result, Is.EqualTo(4));
    }
    #endregion
}