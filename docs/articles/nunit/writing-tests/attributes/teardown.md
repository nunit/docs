---
uid: teardown-attribute
---

# TearDown

`TearDownAttribute` marks a method NUnit calls **immediately after each** test case finishes under a
[`TestFixture`](xref:testfixtureattribute). Pair it with [`SetUp`](xref:setup-attribute) to release **per-test** resources (files, handles, mock
substitutions, etc.).

Like `SetUp`, you usually place tear-down helpers on **base classes** and **derived fixtures** rather than stacking many
methods on a single class (allowed, but **order among them is undefined**).

## Static and instance methods

`TearDown` may be **`static`** or an **instance** method and runs on the **same logical fixture object** NUnit used for that
test’s `SetUp` and test body (including a **new** instance per test when
[`LifeCycle.InstancePerTestCase`](xref:fixturelifecycleattribute) applies).

**`async`** `Task` / `Task<T>` methods are supported.

## When TearDown runs

* **After a successful `SetUp` and test** — always in normal execution (unless the run is **aborted** before teardown is
  dispatched).
* **After `SetUp` fails** — `TearDown` **still runs** so partially constructed state can be unwound. The **test method is
  skipped** and the result shows a **setup** failure, but teardown for that level is **not** skipped solely because setup
  failed.
* **After the test throws or fails** — `TearDown` still runs; the framework records the test failure **and** any teardown
  exception separately if both occur.

The only broad exception is an **abort** (`TestExecutionStatus.AbortRequested`), where NUnit may omit the teardown callback
entirely—mirroring the behavior described for [`OneTimeTearDown`](xref:onetimeteardown-attribute).

Teardown failures or assertions are attached to the test result as **teardown** issues (`FailureSite.TearDown`) while
preserving the original test outcome when possible.

## Usage

This is a parameterless attribute that can only be applied to methods.

```csharp
[TearDown]
```

## Applies To

| Lifecycle Methods | Test Methods | Test Fixtures (Classes) | Assembly |
|-------------------|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ | ❌ |

## Example

[!code-csharp[TearDownExample](~/snippets/Snippets.NUnit/Attributes/TearDownAttributeExamples.cs#TearDownExample)]

## Inheritance

The TearDown attribute is inherited from any base class. Therefore, if a base class has defined a TearDown method, that
method will be called after each test method in the derived class.

You may define a TearDown method in the base class and another in the derived class. NUnit will call base class TearDown
methods after those in the derived classes.

> [!WARNING]
> If a base class TearDown method is overridden in the derived class, NUnit will not call the base class
> TearDown method; NUnit does not anticipate usage that includes hiding the base method. Note that you may have a
> different name for each method; as long as both have the `[TearDown]` attribute present, each will be called in the
> correct order.

## Notes

1. **`TestContext`** — still **per-test** scope, but executed **after** the test method returns or throws.
2. Multiple `TearDown` methods on the **same** class are unordered relative to one another.
3. **Derived** `TearDown` runs **before** base-class `TearDown` when both apply (see **Inheritance**).

## See Also

* [SetUp Attribute](xref:setup-attribute)
* [OneTimeSetUp Attribute](xref:onetimesetup-attribute)
* [OneTimeTearDown Attribute](xref:onetimeteardown-attribute)
* [FixtureLifeCycle Attribute](xref:fixturelifecycleattribute)
* [TestFixture Attribute](xref:testfixtureattribute)
