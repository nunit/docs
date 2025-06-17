# NUnit1034

## Base TestFixtures should be abstract

| Topic    | Value
| :--      | :--
| Id       | NUnit1034
| Severity | Warning
| Enabled  | True
| Category | Structure
| Code     | [TestFixtureShouldBeAbstractAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/TestFixtureShouldBeAbstract/TestFixtureShouldBeAbstractAnalyzer.cs)

## Description

Base TestFixtures should be abstract to prevent base class tests executing separately.

## Motivation

When a base class is not `abstract` it will also be run as a standalone test which is most times not the intention.

```csharp
namespace Tests
{
    internal class ParentFixture
    {
        [Test]
        public void ParentTest()
        {
            Assert.Pass($"Run {nameof(ParentTest)} from class {GetType().Name}");
        }
    }

    internal class ChildFixture : ParentFixture
    {
        [Test]
        public void ChildTest()
        {
            Assert.Pass($"Run {nameof(ChildTest)} from class {GetType().Name}");
        }
    }
}
```

As the `Parent` class is valid as a standalone `TestFixture` it will be instantiated and run separately.

```text
ChildTest: Run ChildTest from class ChildFixture
ParentTest: Run ParentTest from class ChildFixture
ParentTest: Run ParentTest from class ParentFixture
```

This rule only fires when a class is found to be used as a base class in the current compilation.

## How to fix violations

Mark any base class test fixture as `abstract`:

```csharp
    internal abstract class Parent
    {
        [Test]
        public void ParentRun()
        {
            Assert.Pass($"Run {nameof(ParentRun)} from {GetType().Name}");
        }
    }
```

<!-- start generated config severity -->
## Configure severity

### Via ruleset file

Configure the severity per project, for more info see
[MSDN](https://learn.microsoft.com/en-us/visualstudio/code-quality/using-rule-sets-to-group-code-analysis-rules?view=vs-2022).

### Via .editorconfig file

```ini
# NUnit1034: Base TestFixtures should be abstract
dotnet_diagnostic.NUnit1034.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit1034 // Base TestFixtures should be abstract
Code violating the rule here
#pragma warning restore NUnit1034 // Base TestFixtures should be abstract
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit1034 // Base TestFixtures should be abstract
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Structure",
    "NUnit1034:Base TestFixtures should be abstract",
    Justification = "Reason...")]
```
<!-- end generated config severity -->
