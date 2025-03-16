---
title: Ordinary NUnit Tests
---

Ordinary tests are the simple tests that are mostly used.  The do simple checks on the code, and covers the majority of the test use cases you have.

A typical ordinary test method looks like this:

```csharp
public class CalculatorTests
{
    [Test]
    public void CheckThatAddFunctionWorks()
    {
        // Arrange
        var sut = new Calculator();

        // Act
        var result = sut.Add(2,3);

        // Assert
        Assert.That(result,Is.EqualTo(5));
    }
}
```
