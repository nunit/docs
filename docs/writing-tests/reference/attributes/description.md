# Description

The Description attribute is used to apply descriptive text to a Test, TestFixture or Assembly. The text appears in the
XML output file.

## Example

```csharp
[assembly: Description("Assembly description here")]

namespace NUnit.Tests
{
  using System;
  using NUnit.Framework;

  [TestFixture, Description("Fixture description here")]
  public class SomeTests
  {
    [Test, Description("Test description here")]
    public void OneTest()
    { /* ... */ }
  }
}
```

> [!NOTE]
> The Test and TestFixture attributes continue to support an optional Description property. The Description
> attribute should be used for new applications. If both are used, the Description attribute takes precedence.
