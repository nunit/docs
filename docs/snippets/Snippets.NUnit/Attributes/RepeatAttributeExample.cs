using NUnit.Framework;

namespace Snippets.NUnit.Attributes;


public class RepeatAttributeExample
{
    #region RepeatDefaultAttributeExample
    [Test]
    [Repeat(5)]
    public void TestMethod1()
    {
        Assert.Pass();
    }
    #endregion

    private int count1;
    #region RepeatWithFaultAndOutputAttributeExample
    [Test, Explicit("Demonstrates failure collection - intentionally fails on iterations 3 and 4")]
    [Repeat(5, StopOnFailure = false)]
    public void TestMethod2()
    {
        TestContext.Out.WriteLine(count1);
        count1++;
        Assert.That(count1, Is.Not.EqualTo(3).And.Not.EqualTo(4));
    }
    #endregion

    #region RepeatWithFaultAttributeExample

    private int count2;
    
    [Test,Explicit]  // Marking the test as Explicit to avoid failing our doc build. You can skip this.
    [Repeat(5, StopOnFailure = false)]
    public void TestMethod3()
    {
        count2++;
        Assert.That(count2, Is.Not.EqualTo(3)); // Intentional failure on 3rd iteration
    }
    #endregion
}