---
uid: v5breakingchanges
---

# NUnit 5 - A summary of the breaking changes

NUnit 5 is a small major release. Most of the breaking changes finish work started in the 4.x series: they remove
APIs that were already marked obsolete, or they turn errors that used to show up at runtime into compiler errors.
This page lists each breaking change: why it was needed, what changed, and what you need to do.

For the full list of changes, see the [release notes](xref:frameworkreleasenotes).

## Test code changes

### `TestDelegate` and `ActualValueDelegate` removed

Issues [#5253](https://github.com/nunit/nunit/issues/5253) and [#5265](https://github.com/nunit/nunit/issues/5265)

* **Why:** NUnit 4.6 added `Action`/`Func` overloads next to the old NUnit-specific `TestDelegate` overloads. With
  older C# language versions (for example .NET Framework projects on C# 7.3), a plain lambda such as
  `Assert.Throws<T>(() => ...)` matched both overloads, and the compiler reported the call as ambiguous.
* **What changed:** `TestDelegate`, `AsyncTestDelegate` and `ActualValueDelegate<T>` are removed. Every API now takes
  the standard `Action`, `Func<Task>` and `Func<T>` types. Because only one overload is left, lambdas always compile,
  whatever the language version.
* **What to do:** Replace any explicit use of these delegate types with `Action`, `Func<Task>` or `Func<T>`.
  Code that just passes a lambda needs no change.

> [!TIP]
> If you have many explicit uses of `TestDelegate` or `AsyncTestDelegate`, you can keep that code compiling by adding
> type aliases to your test project:
>
> ```csharp
> global using TestDelegate = System.Action;
> global using AsyncTestDelegate = System.Func<System.Threading.Tasks.Task>;
> ```
>
> `global using` requires C# 10 or later. With older language versions, add the same `using` aliases, without
> `global`, at the top of each file that needs them. This doesn't work for `ActualValueDelegate<T>`, because C# aliases
> can't be open generic types. Replace that one with `Func<T>`.

### `Assert.ThrowsAsync`, `Assert.CatchAsync` and `Assert.DoesNotThrowAsync` must be awaited

Issue [#4384](https://github.com/nunit/nunit/issues/4384)

* **Why:** `Assert.ThatAsync` could be awaited, but `Assert.ThrowsAsync` could not, even though the names suggest they
  work the same way. The `*Async` assertions ran the async code synchronously, blocking the calling thread.
* **What changed:** The three methods are now truly asynchronous and return a `Task`. They behave like every other
  `*Async` method in .NET.
* **What to do:** Add `await` and make the test method `async Task`. If you don't await the call, the assertion is not
  evaluated. Version 4.14 or later of
  [NUnit.Analyzers](https://www.nuget.org/packages/NUnit.Analyzers) reports assertions that are not awaited and can fix them,
  including changing the enclosing method to return `Task`.

```csharp
// NUnit 4
var ex = Assert.ThrowsAsync<ArgumentException>(async () => await DoAsync());

// NUnit 5
var ex = await Assert.ThrowsAsync<ArgumentException>(async () => await DoAsync());
```

### `Is.SameAs` works only with reference types

Issue [#5145](https://github.com/nunit/nunit/issues/5145)

* **Why:** Reference equality has no meaning for value types. With the old `object` overload, a value such as a boxed
  `int` or a nullable struct compiled fine but always failed at runtime, unless both values were `null`.
* **What changed:** The `object?` overload is removed. The only overload left is `Is.SameAs<T>(T? expected)`, which
  requires `T : class?`. Mistakes that used to fail at runtime are now compiler errors.
* **What to do:** For value types, use `Is.EqualTo`.

### `Has.Attribute<T>()` requires `T` to be an attribute

Issue [#5323](https://github.com/nunit/nunit/issues/5323)

* **Why:** An attribute type must derive from `System.Attribute`, but NUnit only checked this at runtime. Passing some
  other type compiled fine and then failed when the test ran.
* **What changed:** `Has.Attribute<T>()` now has the generic constraint `where T : Attribute`, so the compiler catches
  the mistake.
* **What to do:** Nothing, unless your code passed a non-attribute type, which never worked. Extensions compiled
  against NUnit 4 must be recompiled, because the method signature changed.

### Type constraints are now generic

Issue [#5007](https://github.com/nunit/nunit/issues/5007)

* **Why:** The generic methods, such as `Is.TypeOf<T>()` and `Is.InstanceOf<T>()`, only called `typeof(T)` and
  returned the same non-generic constraints as the `Type`-based overloads. The expected type was lost at compile
  time, which prevented stronger typing further along the constraint chain.
* **What changed:** The generic methods now return generic constraints, such as `ExactTypeConstraint<T>`,
  `InstanceOfTypeConstraint<T>`, `AssignableToConstraint<T>`, `AssignableFromConstraint<T>` and
  `ExceptionTypeConstraint<T>`. This is a step toward a fully generic constraint model.
* **What to do:** Normal `Assert.That(x, Is.TypeOf<Foo>())` code needs no change. You only need to act if your code
  stores these return values in variables of the non-generic constraint types, or if you have extensions compiled
  against NUnit 4. Recompile those extensions.

### `StringAssert`, `CollectionAssert`, `FileAssert` and `DirectoryAssert` are back in `NUnit.Framework`

Issue [#5180](https://github.com/nunit/nunit/issues/5180)

* **Why:** NUnit 4 moved these classes to the `NUnit.Framework.Legacy` namespace. That forced a lot of code changes when
  upgrading, even though the classes are still widely used and fully supported.
* **What changed:** The classes are now in the `NUnit.Framework` namespace again. They still ship in
  `nunit.framework.legacy.dll`, which is part of the NUnit package. Code written for NUnit 3 works again with only
  `using NUnit.Framework;`.
* **What to do:** Remove any `using NUnit.Framework.Legacy;` that was only there for these classes. Change any fully
  qualified names or aliases, such as `using CollectionAssert = NUnit.Framework.Legacy.CollectionAssert;`, to point to
  `NUnit.Framework`.

### `"NET"` and `"DotNET"` in `[Platform]` now mean modern .NET

Issue [#3669](https://github.com/nunit/nunit/issues/3669)

* **Why:** Microsoft now uses the name ".NET" for .NET 5 and later, but in NUnit `"NET"` still meant .NET Framework.
  For example, `[Platform("NET")]` excluded a test running on .NET 8.
* **What changed:** `"NET"` and `"DotNET"` now match modern .NET. The new identifiers `"NETFramework"` and
  `"DotNETFramework"` match .NET Framework.
* **What to do:** If you used `"NET"` or `"DotNET"` to mean .NET Framework, change them to `"NETFramework"` or
  `"DotNETFramework"`.

| Identifier        | NUnit 4        | NUnit 5        |
| ----------------- | -------------- | -------------- |
| `NET`             | .NET Framework | modern .NET    |
| `DotNET`          | .NET Framework | modern .NET    |
| `NETFramework`    | (not defined)  | .NET Framework |
| `DotNETFramework` | (not defined)  | .NET Framework |
| `NETCore`         | modern .NET    | modern .NET    |
| `DotNETCore`      | modern .NET    | modern .NET    |

## Platform changes

### .NET 6 target removed

Issue [#4857](https://github.com/nunit/nunit/issues/4857)

* **Why:** .NET 6 reached end of life in November 2024, and newer .NET SDKs will stop building it. Keeping it would
  also have prevented NUnit from using newer runtime APIs.
* **What changed:** The framework targets `net462`, `net8.0` and `net10.0`.
* **What to do:** Test projects must target .NET Framework 4.6.2 or later, or .NET 8 or later.

## Extension and runner changes

These changes affect extension and runner authors, not normal test code.

### Forced stop removed

Issues [#5367](https://github.com/nunit/nunit/issues/5367) and [#5373](https://github.com/nunit/nunit/issues/5373)

* **Why:** A forced stop depended on `Thread.Abort`. That is not supported on .NET Core, so `StopRun(force: true)` was
  silently ignored there. On .NET Framework, it only worked for tests running on their own thread. Runners were calling
  an API that mostly did nothing, and the framework kept a lot of thread-abort code that was rarely used.
* **What changed:** The `force` parameter is removed. `ITestAssemblyRunner.StopRun()` and `FrameworkController.StopRun()`
  now take no arguments and always request a cooperative stop. The thread-abort code is gone from the framework.
* **What to do:** Runners must call `StopRun()` without arguments. The compiler now reports calls that used to be
  silently ignored.

### `CollectionTally` deprecated and `CollectionTallyResult` moved

Issue [#5263](https://github.com/nunit/nunit/issues/5263)

* **Why:** `CollectionTally` is a public class meant for internal use, and a generic version has replaced it. The
  class needs to be removed eventually, but many callers only use its nested result class.
* **What changed:** `CollectionTally.CollectionTallyResult` is now a top-level class,
  `NUnit.Framework.Constraints.CollectionTallyResult`. `CollectionTally` is marked `[Obsolete]` and will be removed in
  NUnit 6. Moving the result class out lets the two classes be retired separately.
* **What to do:** Replace `CollectionTally.CollectionTallyResult` with `CollectionTallyResult`, and stop using
  `CollectionTally`.
