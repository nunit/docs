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

    // TODO: Remove the #if guard and update the package reference to the NUnit version that
    // ships RequiredPassPercentage and StopWhenOverallResultDetermined.
#if NUNIT_REPEAT_THRESHOLD
    #region RepeatWithPassThresholdExample
    // The test passes if at least 80% of the 10 runs succeed.
    // Useful for non-deterministic systems where some variation is acceptable.
    [Test]
    [Repeat(10, RequiredPassPercentage = 80)]
    public void NonDeterministicTest()
    {
        bool result = CallFlakyService();
        Assert.That(result, Is.True);
    }

    private bool CallFlakyService() => true; // placeholder
    #endregion

    #region RepeatWithStopWhenDeterminedExample
    // Stops as soon as NUnit can guarantee pass or failure:
    //  - Early success: enough passes accumulated (threshold already guaranteed).
    //  - Early failure: too many failures (threshold no longer achievable).
    [Test]
    [Repeat(10, RequiredPassPercentage = 80, StopWhenOverallResultDetermined = true)]
    public void NonDeterministicTestWithEarlyStop()
    {
        bool result = CallFlakyService();
        Assert.That(result, Is.True);
    }
    #endregion
#endif
}
