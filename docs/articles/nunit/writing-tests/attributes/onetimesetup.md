---
uid: onetimesetup-attribute
---

# OneTimeSetUp

`OneTimeSetUpAttribute` marks a method that runs **once** before any **child tests** in its suite execute. Put it on a
method inside a [`TestFixture`](testfixture.md) or a [`SetUpFixture`](setupfixture.md).

Normally you define multiple `OneTimeSetUp` methods across an **inheritance chain** (base then derived). Defining several
on the **same class** is allowed, but **order is undefined**—avoid unless you truly do not rely on ordering.

## Static and instance methods

A `OneTimeSetUp` method may be **static** or an **instance** method on the fixture type.

With the default fixture life cycle ([`LifeCycle.SingleInstance`](fixturelifecycle.md)), an **instance** method runs on
the shared fixture instance created for that suite—so it can safely touch **instance fields** shared by every test.

With [`FixtureLifeCycle(LifeCycle.InstancePerTestCase)`](fixturelifecycle.md), `OneTimeSetUp` **must be static**. It runs
once for the fixture while each test gets its own instance; keeping it static avoids relying on fields that reset
between tests.

Methods may be **async** (`Task` / `Task<T>`): NUnit will wait for completion like other async test infrastructure.

## Test fixture versus SetUp fixture

* **`TestFixture`** — `OneTimeSetUp` runs **once before all tests declared in that fixture** (including parameterized
  cases sourced from that class). Each concrete fixture class gets its own one-time setup for its subtree.
* **`SetUpFixture`** — `OneTimeSetUp` runs **once for the scope that setup fixture covers** (for example several fixtures
  under the same namespace), as described in [SetUpFixture](setupfixture.md). Use this pattern when costly initialization
  should run **once** for that whole slice of the hierarchy instead of repeating it on every concrete fixture class.

If `OneTimeSetUp` lives on an **abstract or concrete base test class**, NUnit invokes it **for every derived fixture
type** that inherits that hierarchy (along with setup on the descendants). When you truly need execution **exactly once
for many unrelated fixtures**, prefer **`SetUpFixture`** or **`static`** initialization instead of repeating base-class
`OneTimeSetUp` semantics.

## Failures and exceptions

If **`OneTimeSetUp` fails** — including an assertion failure (`Assert.*`) or **any thrown exception** — NUnit treats the
setup as unsuccessful. Tests that would run **under that suite** are **not executed** (they are skipped as descendants of
failed setup), and the run reports a **failure** or **error** for that setup/fixture subtree. NUnit still invokes
**`OneTimeTearDown`** for that scope afterward (unless execution is aborted), which allows shared resources created during
partial setup to be released; see [OneTimeTearDown](onetimeteardown.md).

## Usage

This is a parameterless attribute that can only be applied to methods.

```csharp
[OneTimeSetUp]
```

## Applies To

| Lifecycle Methods | Test Methods | Test Fixtures (Classes) | Assembly |
|-------------------|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ | ❌ |

## Example

[!code-csharp[OneTimeSetUpExample](~/snippets/Snippets.NUnit/Attributes/OneTimeSetUpAttributeExamples.cs#OneTimeSetUpExample)]

## Inheritance

The OneTimeSetUp attribute is inherited from any base class. Therefore, if a base class has defined a OneTimeSetUp
method, that method will be called before any methods in the derived class.

You may define a OneTimeSetUp method in the base class and another in the derived class. NUnit will call base class
OneTimeSetUp methods before those in the derived classes.

> [!WARNING]
> If a base class OneTimeSetUp method is overridden in the derived class, NUnit will not call the base class
> OneTimeSetUp method; NUnit does not anticipate usage that includes hiding the base method. Note that you may have a
> different name for each method; as long as both have the `[OneTimeSetUp]` attribute present, each will be called in
> the correct order.

## Notes

1. **`TestContext`** — `OneTimeSetUp` executes in **fixture / setup-fixture** context, **not** the per-test-case context.
   Be careful when calling [`TestContext`](xref:testcontext) APIs that assume an active test method.
2. Multiple `OneTimeSetUp` methods in the **same** class run in arbitrary order unless you constrain them logically.
3. Base-class `OneTimeSetUp` methods run **before** derived-class methods (see **Inheritance** above).

## See Also

* [SetUp Attribute](setup.md)
* [TearDown Attribute](teardown.md)
* [OneTimeTearDown Attribute](onetimeteardown.md)
* [SetUpFixture Attribute](setupfixture.md)
* [FixtureLifeCycle Attribute](fixturelifecycle.md)
