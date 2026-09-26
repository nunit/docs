---
uid: v5newfeatures
---

# NUnit 5 - New features

This page lists the enhancements in NUnit 5. For each one, it explains why it was needed and what it gives you.
For changes that may require you to update existing code, see
[NUnit 5 - A summary of the breaking changes](xref:v5breakingchanges). For the full list of changes, see the
[release notes](xref:frameworkreleasenotes).

## Test ordering and selection

### Test dependencies with `[DependsOnTest]` and `[DependsOnFixture]`

Issues [#51](https://github.com/nunit/nunit/issues/51) and [#5396](https://github.com/nunit/nunit/issues/5396)

* **Why:** Some tests have to run after others, for example database installation before upgrade tests. Until now,
  the only tool was `[Order]`, which sets a relative position but doesn't say which test depends on which, and doesn't
  react when the earlier test fails.
* **What's new:** `[DependsOnTest("TestName")]` makes a test run after another test in the same fixture, and
  `[DependsOnFixture(typeof(OtherFixture))]` makes a fixture run after another fixture. If the dependency fails, the
  dependent test isn't run, unless you set `AllowFailure = true`. NUnit reports circular dependencies as errors.
  If you run a single test from your IDE, NUnit also runs the tests it depends on, even though the filter excludes
  them.

```csharp
[Test]
public void Install() { ... }

[Test, DependsOnTest(nameof(Install))]
public void Upgrade() { ... }
```

> [!NOTE]
> `[Order]` is now marked `[Obsolete]`. Use `[DependsOnTest]` or `[DependsOnFixture]` instead. A test can't be part of
> both an `Order` chain and a dependency chain, and tests in a dependency chain can't run in parallel.

For more information, see [DependsOnTest](xref:attribute-dependsontest) and
[DependsOnFixture](xref:attribute-dependsonfixture).

### `TestContext.ActiveTests`

Issue [#5354](https://github.com/nunit/nunit/issues/5354)

* **Why:** A `[SetUpFixture]` often does expensive setup, such as starting a database or a browser, that only some
  tests need. There was no way to find out which tests would actually run after filtering, so the setup had to run
  every time.
* **What's new:** In a `[OneTimeSetUp]` or `[OneTimeTearDown]` method, `TestContext.CurrentContext.ActiveTests` lists
  the tests under the current suite that passed the filter. You can inspect them, for example their categories or
  attributes, and skip setup that no active test needs. The property works with every runner, and is `null` outside
  those methods.

For more information, see [TestContext](xref:testcontext).

## Assertions and test data

### Type-safe `TestCaseData` expected results

Issue [#4717](https://github.com/nunit/nunit/issues/4717)

* **Why:** The generic `TestCaseData<T1, ...>` classes, added in NUnit 4.1, typed the arguments. However, `.Returns()`
  still took an `object`, so a wrongly typed expected result was only found at runtime. The fluent methods, such as
  `.SetName()`, also returned a plain `TestCaseData`, which lost the generic type.
* **What's new:** `.Returns()` on a generic `TestCaseData` returns a `TestCaseDataWithReturn<T1, ..., TReturn>`, so the
  compiler checks the expected result. `TestCaseData.Create(...)` infers the argument types. Fluent methods keep the
  generic type, and a generic instance can still be returned from a source declared as `IEnumerable<TestCaseData>`.

```csharp
private static IEnumerable<TestCaseDataWithReturn<int, int, int>> AddCases()
{
    yield return TestCaseData.Create(1, 2).Returns(3);
    yield return TestCaseData.Create(2, 3).SetName("Two plus three").Returns(5);
}
```

For more information, see [TestCaseData](xref:testcasedata).

### `ParamName` on argument exception constraints

Issue [#3947](https://github.com/nunit/nunit/issues/3947)

* **Why:** Checking which parameter caused an `ArgumentException` needed the long form
  `.With.Property("ParamName")`, which uses a string and isn't checked by the compiler.
* **What's new:** Generic exception constraints for `ArgumentException` and derived types have a `ParamName`
  property. It must come directly after the exception type in the constraint expression. It is a C# 14 extension
  property, so your test project needs C# 14 or later to use it.

```csharp
Assert.That(() => Parse(null!), Throws.ArgumentNullException.ParamName.EqualTo("input"));
Assert.That(() => Parse(""), Throws.InstanceOf<ArgumentException>().ParamName.EqualTo("input"));
```

For more information, see [Throws Constraint](xref:constraint-throws).

### Compile-time checks and awaitable async assertions

Issues [#5323](https://github.com/nunit/nunit/issues/5323) and [#4384](https://github.com/nunit/nunit/issues/4384)

* `Has.Attribute<T>()` now only accepts attribute types, so a wrong type is a compiler error instead of a failure at
  runtime.
* `Assert.ThrowsAsync`, `Assert.CatchAsync` and `Assert.DoesNotThrowAsync` are now truly asynchronous and must be
  awaited.

Both are breaking changes, and are described in
[NUnit 5 - A summary of the breaking changes](xref:v5breakingchanges).

## Timing and repetition

### Warning threshold for `[MaxTime]`

Issue [#5260](https://github.com/nunit/nunit/issues/5260)

* **Why:** `[MaxTime]` fails a test that takes too long, with nothing in between pass and fail. A test that is getting
  slower gave no signal until it crossed the limit.
* **What's new:** The optional `WarningTime` property sets a lower threshold. A passing test that takes longer than
  `WarningTime`, but less than the maximum, gets a *Warning* result. This makes performance drift visible before it
  becomes a failure.

```csharp
[Test, MaxTime(2000, WarningTime = 1000)]
public void ImportLargeFile() { ... }
```

For more information, see [MaxTime](xref:attribute-maxtime).

### Pass-percentage threshold for `[Repeat]`

Issue [#5220](https://github.com/nunit/nunit/issues/5220)

* **Why:** Some systems are not deterministic, for example an LLM-based chat bot. For these, "passes 9 times out of
  10" is a valid requirement, but `[Repeat]` required every run to pass.
* **What's new:** `RequiredPassPercentage` sets the percentage of runs that must pass (1-100, default 100). When it is
  below 100, all runs are executed and the result reports how many passed. Set `StopWhenOverallResultDetermined = true`
  to stop as soon as the outcome is certain, either because the threshold has already been reached or because it can
  no longer be reached.

```csharp
[Test, Repeat(20, RequiredPassPercentage = 90, StopWhenOverallResultDetermined = true)]
public void ChatBotAnswersCorrectly() { ... }
```

For more information, see [Repeat](xref:attribute-repeat).

## Platform support

### .NET 10 target

Issue [#5316](https://github.com/nunit/nunit/issues/5316)

* **Why:** Projects targeting .NET 10 were using the .NET 8 build of NUnit, so they couldn't benefit from newer
  runtime APIs.
* **What's new:** NUnit now ships `net462`, `net8.0` and `net10.0` builds, and projects on .NET 10 or later get the
  `net10.0` build.

## Under the hood

These changes don't affect how you write tests, but they make NUnit faster and easier to maintain.

* **Faster locking on .NET 10** ([#5387](https://github.com/nunit/nunit/issues/5387)): The work-item and parallel
  dispatcher code now uses the `System.Threading.Lock` type introduced in .NET 9, with a polyfill for older runtimes.
  Test projects on .NET 10 or later get the faster locking.
* **Argument validation throw helpers** ([#5348](https://github.com/nunit/nunit/issues/5348),
  [#5349](https://github.com/nunit/nunit/issues/5349)): Manual argument checks were replaced with the built-in
  `ArgumentNullException.ThrowIfNull` and `ArgumentOutOfRangeException.ThrowIf*` helpers, polyfilled for .NET
  Framework. The CA1510 and CA1512 analyzer rules are now enforced in the build.
* **Simpler overload resolution** ([#5267](https://github.com/nunit/nunit/issues/5267)): The
  `OverloadResolutionPriority` attributes added in 4.6 to handle the switch from `TestDelegate` to `Action` are
  removed. They are no longer needed now that the old delegate overloads are gone.
