# NUnit2056

## Consider using Assert.EnterMultipleScope statement instead of Assert.Multiple/Assert.MultipleAsync

| Topic    | Value
| :--      | :--
| Id       | NUnit2056
| Severity | Info
| Enabled  | True
| Category | Assertion
| Code     | [UseAssertEnterMultipleScopeAnalyzer](https://github.com/nunit/nunit.analyzers/blob/4.9.2/src/nunit.analyzers/UseAssertEnterMultipleScope/UseAssertEnterMultipleScopeAnalyzer.cs)

## Description

Consider using `Assert.EnterMultipleScope` statement instead of `Assert.Multiple`/`Assert.MultipleAsync`.

## Motivation

Prior to NUnit 4.2, developers used two separate methods to group multiple assertions into a single
logical assertion:

* `Assert.Multiple` for synchronous code
* `Assert.MultipleAsync` for asynchronous code

This approach, while functional, had limitations — in particular around unnecessary context capture
and limited static analysis due to the use of lambda expressions.

With the release of NUnit 4.2, a new API was introduced: `Assert.EnterMultipleScope`. This method unifies
the handling of multiple assertions for both sync and async code and avoids the problems above.

For more information on `EnterMultipleScope` see the discussion in this
[Feature Request](https://github.com/nunit/nunit/issues/4587)

```csharp
[Test]
public void TestMultiple()
{
    Assert.Multiple(() =>
    {
        var i = 4;
        var j = 67;
        Assert.That(i, Is.EqualTo(j));
    });
}
```

and

```csharp
[Test]
public async Task TestMultipleAsync()
{
    await Assert.MultipleAsync(async () =>
    {
        var i = await GetInt();
        var j = await GetInt();
        Assert.That(i, Is.EqualTo(j));
    });
}
```

## How to fix violations

The analyzer comes with a code fix that will replace `Assert.Multiple` and `Assert.MultipleAsync`
with `using (Assert.EnterMultipleScope())` and keep the body of the methods as body of the using
statement. So the methods above will be changed into.

```csharp
[Test]
public void TestMultiple()
{
    using (Assert.EnterMultipleScope())
    {
        var i = 4;
        var j = 67;
        Assert.That(i, Is.EqualTo(j));
    }
}
```

and

```csharp
[Test]
public async Task TestMultipleAsync()
{
    using (Assert.EnterMultipleScope())
    {
        var i = await GetInt();
        var j = await GetInt();
        Assert.That(i, Is.EqualTo(j));
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
# NUnit2056: Consider using Assert.EnterMultipleScope statement instead of Assert.Multiple/Assert.MultipleAsync
dotnet_diagnostic.NUnit2056.severity = chosenSeverity
```

where `chosenSeverity` can be one of `none`, `silent`, `suggestion`, `warning`, or `error`.

### Via #pragma directive

```csharp
#pragma warning disable NUnit2056 // Consider using Assert.EnterMultipleScope statement instead of Assert.Multiple/Assert.MultipleAsync
Code violating the rule here
#pragma warning restore NUnit2056 // Consider using Assert.EnterMultipleScope statement instead of Assert.Multiple/Assert.MultipleAsync
```

Or put this at the top of the file to disable all instances.

```csharp
#pragma warning disable NUnit2056 // Consider using Assert.EnterMultipleScope statement instead of Assert.Multiple/Assert.MultipleAsync
```

### Via attribute `[SuppressMessage]`

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Assertion",
    "NUnit2056:Consider using Assert.EnterMultipleScope statement instead of Assert.Multiple/Assert.MultipleAsync",
    Justification = "Reason...")]
```
<!-- end generated config severity -->
