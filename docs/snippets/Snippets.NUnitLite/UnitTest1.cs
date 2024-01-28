namespace Snippets.NUnitLite;

public class Tests
{
    [Test]
    public void PassingTest()
    {
        Assert.Pass();
    }

    [Test]
    [Ignore("Ignored test")]
    public void IgnoredTest()
    {
        Assert.Fail();
        Assert.Pass();
    }

    [Test]
    public void FailingTest()
    {
        Assert.Fail();
    }


}