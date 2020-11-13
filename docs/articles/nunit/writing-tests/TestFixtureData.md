---
uid: TestFixtureData
---

# TestFixtureData

The `TestFixtureData` class provides specific instance information for a parameterized fixture, although any object deriving from `TestFixtureParameters` may be used. Unlike NUnit 2, you cannot implement `IFixtureData`, you must derive from `TestFixtureParameters`.

The following example varies the example shown under [TestFixture Attribute](xref:testfixtureattribute) by using
a `TestFixtureSourceAttribute` with a data source in a separately defined class.

```csharp
[TestFixtureSource(typeof(MyFixtureData), nameof(MyFixtureData.Fixtureparams))]
public class ParameterizedTestFixture
{
    private string eq1;
    private string eq2;
    private string neq;

    public ParameterizedTestFixture(string eq1, string eq2, string neq)
    {
        this.eq1 = eq1;
        this.eq2 = eq2;
        this.neq = neq;
    }

    public ParameterizedTestFixture(string eq1, string eq2)
        : this(eq1, eq2, null) { }

    public ParameterizedTestFixture(int eq1, int eq2, int neq)
    {
        this.eq1 = eq1.ToString();
        this.eq2 = eq2.ToString();
        this.neq = neq.ToString();
    }

    [Test]
    public void TestEquality()
    {
        Assert.AreEqual(eq1, eq2);
        if (eq1 != null && eq2 != null)
            Assert.AreEqual(eq1.GetHashCode(), eq2.GetHashCode());
    }

    [Test]
    public void TestInequality()
    {
        Assert.AreNotEqual(eq1, neq);
        if (eq1 != null && neq != null)
            Assert.AreNotEqual(eq1.GetHashCode(), neq.GetHashCode());
    }
}


public class MyFixtureData
{
    public static IEnumerable Fixtureparams
    {
        get
        {
            yield return new TestFixtureData("hello", "hello", "goodbye");
            yield return new TestFixtureData("zip", "zip");
            yield return new TestFixtureData(42, 42, 99);
        }
    }  
}
```
