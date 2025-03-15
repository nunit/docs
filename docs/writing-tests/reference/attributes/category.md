# Category

The Category attribute provides an alternative to suites for dealing with groups of tests. Either individual test cases
or fixtures may be identified as belonging to a particular category. Some runners, including the Console Runner, allow
specifying categories to be included in or excluded from the run. When categories are used, only the tests in the
selected categories will be run. Those tests in categories that are not selected are not reported at all.

> [!WARNING]
> While the C# syntax allows you to place a Category attribute on a SetUpFixture class, the attribute is
> ignored by NUnit and has no effect in current releases.

## Test Fixture Syntax

```csharp
namespace NUnit.Tests
{
  using System;
  using NUnit.Framework;

  [TestFixture]
  [Category("LongRunning")]
  public class LongRunningTests
  {
    // ...
  }
}
```

## Test Syntax

```csharp
namespace NUnit.Tests
{
  using System;
  using NUnit.Framework;

  [TestFixture]
  public class SuccessTests
  {
    [Test]
    [Category("Long")]
    public void VeryLongTest()
    { /* ... */ }
}
```

### Custom Category Attributes

Custom attributes that derive from **CategoryAttribute** will be recognized by NUnit. The default protected constructor
of CategoryAttribute sets the category name to the name of your class.

Here's an example that creates a category of Critical tests. It works just like any other category, but has a simpler
syntax. A test reporting system might make use of the attribute to provide special reports.

```csharp
[AttributeUsage(AttributeTargets.Method, AllowMultiple=false)]
public class CriticalAttribute : CategoryAttribute
{ }
```

```csharp
[Test, Critical]
public void MyTest()
{ /*...*/ }
```
