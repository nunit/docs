# IImplyFixture Interface

The `IImplyFixture` interface is an empty interface, used solely as a marker:

```csharp
public interface IImplyFixture
{
}
```

If a class contains any method with an attribute that implements this interface, that class is treated as an NUnit
TestFixture without any `TestFixture` attribute being specified. The following NUnit attributes currently implement this
interface:

* [`TestAttribute`](../writing-tests/attributes/test.md)
* [`TestCaseAttribute`](../writing-tests/attributes/testcase.md)
* [`TestCaseSourceAttribute`](../writing-tests/attributes/testcasesource.md)
* [`TheoryAttribute`](../writing-tests/attributes/theory.md)
