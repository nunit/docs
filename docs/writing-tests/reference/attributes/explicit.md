# Explicit

The Explicit attribute causes a test or test fixture to be skipped unless it is explicitly selected for running. The
test or fixture will be run if it is selected by name or if it is included by use of a filter. A **not** filter, which
excludes certain tests, is not treated as an explicit selection and never causes an explicit test to be run. All other
filters are considered to explicitly select the tests that they match. See examples below.

An optional string argument may be used to give the reason for marking the test Explicit.

If a test or fixture with the Explicit attribute is encountered in the course of running tests, it is skipped unless it
has been specifically selected by one of the above means. The test does not affect the overall result of the test run.
Explicit tests are displayed in the gui as skipped.

> [!WARNING]
> While the C# syntax allows you to place an Explicit attribute on a SetUpFixture class, the attribute is
> ignored by NUnit and has no effect in current releases.

## Examples of Use

Using the console command-line to select tests, the following options will include any explicit tests that fall under
the selection.

```none
    --test=My.Namespace.Fixture.Method
    --test=My.Namespace.Fixture
    --test=My.Namespace
    --where test==My.Namespace.Fixture.Method
    --where test==My.Namespace.Fixture
    --where test==My.Namespace
    --where cat==X
    --where "cat==X || cat==Y"
```

However, the following options will **not** include explicit tests

```none
    --where test!=My.Namespace.Fixture
    --where cat!=X
```

## TRAP

If a project contains only explicit tests, running the test project will execute all tests, as  it is treated as an
explicit test run. To prevent this, ensure the project includes at least one non-explicit test, even if it's just a
dummy test.

From [this issue](https://github.com/nunit/nunit3-vs-adapter/issues/1223), the following comment explains how the
adapter works with explicit tests:

*"When the adapter is called from the testhost, it receives a list of tests to run. It doesn't know HOW the Test
Explorer is being used. And thus it has no knowledge if there are other tests present that are not selected, OR if the
tests it receives are all the tests in the solution.*

*If all the tests are Explicit it will assume that this is an explicit testrun. When you only have one test, and that
test is explicit, it will be an explicit test run.*

*When you add the second test, which is not explicit, it will see both tests, and since there is a non-explicit test
included, the test is a non-explicit testrun, and all explicit tests will be ignored.*

*If you have a situation with only one explicit test, the work around is to just add another non-explicit test, which
can be empty, or even have a false Assume statement, which will make the test be inconclusive, thus not part of your
results."*

## Test Fixture Syntax

C#:

```csharp
namespace NUnit.Tests
{
  using System;
  using NUnit.Framework;

  [TestFixture, Explicit]
  public class ExplicitTests
  {
    // ...
  }
}
```

Visual Basic:

```VB
Imports System
Imports NUnit.Framework

Namespace NUnit.Tests

  <TestFixture(), Explicit()>
  Public Class ExplicitTests
    ' ...
  End Class
End Namespace
```

C++:

```cpp
using namespace System;
using namespace NUnit::Framework;

namespace NUnitTests
{
  [TestFixture]
  [Explicit]
  public __gc class ExplicitTests
  {
    // ...
  };
}

# include "cppsample.h"

namespace NUnitTests {
  // ...
}
```

## Test Syntax

C#:

```csharp
namespace NUnit.Tests
{
  using System;
  using NUnit.Framework;

  [TestFixture]
  public class SuccessTests
  {
    [Test, Explicit]
    public void ExplicitTest()
    { /* ... */ }
}
```

Visual Basic:

```vb
Imports System
Imports NUnit.Framework

Namespace NUnit.Tests

  <TestFixture()> Public Class SuccessTests
    <Test(), Explicit()> Public Sub ExplicitTest()
      ' ...
    End Sub
  End Class
End Namespace
```

C++:

```cpp
# using <NUnit.Framework.dll>
using namespace System;
using namespace NUnit::Framework;

namespace NUnitTests
{
  [TestFixture]
  public __gc class SuccessTests
  {
    [Test][Explicit] void ExplicitTest();
  };
}

# include "cppsample.h"

namespace NUnitTests {
  // ...
}
```
