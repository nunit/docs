---
uid: nunit40migrationguide
---

# NUnit 4.0 Migration Guide

NUnit 4.0 has a few [breaking changes](../release-notes/breaking-changes.md#nunit-40)
making it neither binary nor source code compatible with NUnit 3.14.0

* Change to [Classic Asserts](../writing-tests/assertions/assertion-models/classic.md)
* Removal of `Assert.That` overloads with _format_ specification and `params`.

## Classic Assert migration

There are different ways to migrate these to NUnit 4.0

* Convert Classic Assert to the [Constraint model](../writing-tests/assertions/assertion-models/constraint.md)
* Update source code to new namespace and class name
* Using `global using` aliases

In the sections below we use the following simple test as an example:

```csharp
public class Tests
{
    [Test]
    public void TestSomeCalculation()
    {
        int actual = SomeCalculation();
        Assert.AreEqual(42, actual, "Expected {0} to be 42", actual);
        StringAssert.StartsWith("42", actualText, "Expected '{0}' to start with '42'", actualText);
    }

    private static int SomeCalculation() => 42;
}
```

### Convert Classic Assert to Constraint Model

Although the code can be converted manually, that is a lot of work.

Luckily, the [NUnit.Analyzer](https://www.nuget.org/packages/NUnit.Analyzers) has had rules and associated code fixes for a while now.
Version _3.10.0_ knows about the 2nd non-backward compatible change and will convert the _format_ specification and `params` into a `FormattableString`.

> [!NOTE]
> **Caveat**: The analyzers only run when the code compiles, so execute and act on the analyzer _before_ upgrading `nunit` to version `4.0.0`!

In our example code, the analyzer will flag the `Assert.AreEqual` as shown below:
![NUnit.Analyzer Classic Assert Warning](~/images/NUnit.Analyzer-ClassicAssert-Warning.png)

Running the associated `Transform to constraint model` code fix in Visual Studio will convert the code into:

```csharp
public class Tests
{
    [Test]
    public void TestSomeCalculation()
    {
        int actual = SomeCalculation();
        Assert.That(actual, Is.EqualTo(42), $"Expected {actual} to be 42");
    }

    private static int SomeCalculation() => 42;
}
```

The analyzer code fix supports _Batch Fixing_:

![NUnit.Analyzer Classic Assert CodeFix](~/images/NUnit.Analyzer-ClassicAssert-CodeFix.png)

This allows changing all corresponding `Assert` usages for a document, project or a complete solution.

There are many classic asserts and most of these come with a separate code analyzer rule and code fix.
Although it allows full configuration to what classic asserts to keep or convert, it means that a developer has to repeat this process multiple times, once for each assert method.

NUnit.Analyzer also has code fixers for `CollectionAssert` and `StringAssert`.

```csharp
string actualText = actual.ToString();
StringAssert.StartsWith("42", actualText, "Expected '{0}' to start with '42'", actualText);
```

Will be converted into:

```csharp
string actualText = actual.ToString();
Assert.That(actualText, Does.StartWith("42"), $"Expected '{actualText}' to start with '42'");
```

There are no code fixers for `FileAssert` and `DirectoryAssert`.
They could be added, but we don't expect these to be used too much.

### Convert Classic Assert into NUnit4 equivalent

If you want to keep the Classic Asserts and not convert them to the constraint model --
but do want to use the new NUnit4 naming -- you'll need to update the code manually.

The NUnit.Analyzer can't help here as the code either doesn't compile before the change or after,
depending on what version of `nunit` you are compiling with.

If you _only_ use classic asserts, you can get away with a couple of global substitutes:

1. Convert `using NUnit.Framework;` into _both_ `using NUnit.Framework;using NUnit.Framework.Legacy;`

   Depending on your editor you can automatically insert a newline between the two `using` statements.
1. Convert `Assert` into `ClassicAssert`.

   This global substitute will also convert those asserts that have not changed.
You can narrow the scope of this substitute to do only the asserts that need converting, but there are quite a lot.

   1. Convert `Assert.AreEqual` into `ClassicAssert.AreEqual`.
   1. Convert `Assert.True` into `ClassicAssert.True`.
   1. Similar for `IsTrue`, `False`, `IsFalse`, `Greater`, `Less`, ...

   Depending on what is less work, alternatively you can reverse the substitution of those that shouldn't be have been changed:
   1. Convert `ClassicAssert.That` into `Assert.That`.
   1. Convert `ClassicAssert.Fail` into `Assert.Fail`.
   1. Convert `ClassicAssert.Throws` into `Assert.Throws`.
   1. Etc.

   Or if you use Visual Studio, it will raise an [IDE0002](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/ide0002) with a code fix that can convert all of those that are not considered _classic_ back to assert in one swoop:

   ![ClassicAssert to Assert](~/images/IDE0002-ClassicAssert-into-Assert.png)

### Use `global using` aliases

If you use SDK 6.0 or newer that supports C#10, you can upgrade without modifying any actual tests by adding the following aliases to `GlobalUsings.cs`

```csharp
global using Assert = NUnit.Framework.Legacy.ClassicAssert;
global using CollectionAssert = NUnit.Framework.Legacy.CollectionAssert;
global using StringAssert = NUnit.Framework.Legacy.StringAssert;
global using DirectoryAssert = NUnit.Framework.Legacy.DirectoryAssert;
global using FileAssert = NUnit.Framework.Legacy.FileAssert;
```

Note that this doesn't mean you have to target .NET 6.0. This also works if targeting .NET Framework as it is purely done on the source code level.

## Assert.That with _format_ specification and `params` overload conversion

These overloads were removed to allow for better messages in case of failure.
See [Towards-NUnit4.md](../Towards-NUnit4.md#improved-assert-result-messages)

NUnit4 has been optimized such that these formattable strings only get formatted in case the test is failing.

```csharp
int actual = SomeCalculation();
Assert.That(actual, Is.EqualTo(42), "Expected {0} to be 42", actual);
```

Needs to be converted into:

```csharp
int actual = SomeCalculation();
Assert.That(actual, Is.EqualTo(42), $"Expected {actual} to be 42");
```

To make this transition easy, the Nunit.Analyzer has been updated with a new rule and corresponding code-fix:

![Replace Format Specification with Formattable String](~/images/NUnit.Analyzer-ReplaceFormatSpecification.png)

## Using NUnit Extension libraries

If your code doesn't call `nunit` asserts directly but uses a local `NUnitExtension` library or a 3rd party one then that dependency needs to be upgraded _before_ you can upgrade your own code.

If the library is not NUnit 4.0 compliant, you will get error messages like:

```txt
System.MissingMethodException : Method not found: 'Void NUnit.Framework.Assert.That(!!0, NUnit.Framework.Constraints.IResolveConstraint, System.String, System.Object[])'.
```
