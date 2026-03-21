using NUnit.Framework;

#pragma warning disable CA1822
#pragma warning disable NUnit2045
#pragma warning disable NUnit2005
#pragma warning disable NUnit2006
#pragma warning disable NUnit2015
#pragma warning disable NUnit2031
#pragma warning disable NUnit2049

namespace Snippets.NUnit;

public class ClassicAssertExamples
{
    #region AreEqualExamples
    [Test]
    public void AreEqual_Examples()
    {
        // Comparing numerics of different types
       Assert.AreEqual(5, 5.0);
        
        // Floating point special values
       Assert.AreEqual(double.PositiveInfinity, double.PositiveInfinity);
       Assert.AreEqual(double.NegativeInfinity, double.NegativeInfinity);
       Assert.AreEqual(double.NaN, double.NaN);
        
        // Basic equality
       Assert.AreEqual("expected", "expected");
       Assert.AreEqual(42, 42);
        
        // With tolerance for floating point
       Assert.AreEqual(2.1 + 1.2, 3.3, 0.001);
    }
    #endregion

    #region AreNotEqualExamples
    [Test]
    public void AreNotEqual_Examples()
    {
       Assert.AreNotEqual(5, 3);
       Assert.AreNotEqual("Hello", "World");
       Assert.AreNotEqual(null, "something");
    }
    #endregion

    #region TrueExamples
    [Test]
    public void True_Examples()
    {
        Assert.True(2 + 2 == 4);
        Assert.IsTrue(true);
        Assert.True("Hello".StartsWith("H"));
        
    }
    #endregion

    #region FalseExamples
    [Test]
    public void False_Examples()
    {
       Assert.False(2 + 2 == 5);
       Assert.IsFalse(false);
       Assert.False("Hello".StartsWith("X"));
    }
    #endregion

#pragma warning disable CS8600
#pragma warning disable CS8625

    #region NullExamples
    [Test]
    public void Null_Examples()
    {
        object obj = null;
        Assert.Null(obj);
        Assert.IsNull(obj);
        
        obj = "something";
        Assert.NotNull(obj);
        Assert.IsNotNull(obj);
    }
    #endregion
#pragma warning restore CS8600
#pragma warning restore CS8625
    
    #region SameExamples
    [Test]
    public void Same_Examples()
    {
        object obj1 = new object();
        object obj2 = obj1;
        object obj3 = new object();
        
        Assert.AreSame(obj1, obj2);
        Assert.AreNotSame(obj1, obj3);
    }
    #endregion

    #region GreaterExamples
    [Test]
    public void Greater_Examples()
    {
        Assert.Greater(7, 3);
        Assert.Greater(3.5, 2.1);
        Assert.Greater("b", "a");
        Assert.Greater(DateTime.Now, DateTime.Now.AddDays(-1));
    }
    #endregion

    #region GreaterOrEqualExamples
    [Test]
    public void GreaterOrEqual_Examples()
    {
        Assert.GreaterOrEqual(7, 3);
        Assert.GreaterOrEqual(7, 7);
        Assert.GreaterOrEqual("b", "a");
        Assert.GreaterOrEqual("b", "b");
    }
    #endregion

    #region LessExamples
    [Test]
    public void Less_Examples()
    {
        Assert.Less(3, 7);
        Assert.Less(2.1, 3.5);
        Assert.Less("a", "b");
    }
    #endregion

    #region LessOrEqualExamples
    [Test]
    public void LessOrEqual_Examples()
    {
        Assert.LessOrEqual(3, 7);
        Assert.LessOrEqual(7, 7);
        Assert.LessOrEqual("a", "b");
        Assert.LessOrEqual("a", "a");
    }
    #endregion

    #region ContainsExamples
    [Test]
    public void Contains_Examples()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        Assert.Contains(3, list);
        
        var array = new [] { "apple", "banana", "cherry" };
        Assert.Contains("banana", array);
    }
    #endregion

    #region PositiveNegativeZeroExamples
    [Test]
    public void PositiveNegativeZero_Examples()
    {
        Assert.Positive(5);
        Assert.Positive(0.1);
        
        Assert.Negative(-5);
        Assert.Negative(-0.1);
        
        Assert.Zero(0);
        Assert.Zero(0.0);
        
        Assert.NotZero(5);
        Assert.NotZero(-3);
    }
    #endregion

    #region NaNExamples
    [Test]
    public void NaN_Examples()
    {
       Assert.IsNaN(double.NaN);
       Assert.IsNaN(float.NaN);
    }
    #endregion

    #region EmptyExamples
    [Test]
    public void Empty_Examples()
    {
        Assert.IsEmpty("");
        Assert.IsEmpty(new int[] { });
        Assert.IsEmpty(new List<string>());
        
        Assert.IsNotEmpty("Hello");
        Assert.IsNotEmpty(new [] { 1, 2, 3 });
        Assert.IsNotEmpty(new List<string> { "item" });
    }
    #endregion

    #region InstanceOfExamples
    [Test]
    public void InstanceOf_Examples()
    {
        Assert.IsInstanceOf<string>("Hello");
        Assert.IsInstanceOf(typeof(string), "Hello");
        Assert.IsInstanceOf<object>("Hello");
        
        Assert.IsNotInstanceOf<int>("Hello");
        Assert.IsNotInstanceOf(typeof(int), "Hello");
    }
    #endregion

    #region AssignableFromExamples
    [Test]
    public void AssignableFrom_Examples()
    {
        // object can be assigned FROM string (string is a subtype of object)
        object obj = "Hello";
        Assert.IsAssignableFrom<string>(obj);
        Assert.IsAssignableFrom(typeof(string), obj);
        
        Assert.IsNotAssignableFrom<int>("Hello");
        Assert.IsNotAssignableFrom(typeof(int), "Hello");
    }
    #endregion
}