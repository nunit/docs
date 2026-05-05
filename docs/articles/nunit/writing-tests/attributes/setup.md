---
uid: setup-attribute
---

# SetUp

`SetUpAttribute` marks a method NUnit calls **immediately before each** `[Test]`, `[TestCase]`, `[Theory]`, etc. in the
fixture. Use it to reset or prepare **per-test** instance state that should not leak between cases.

The method lives on your [`TestFixture`](testfixture.md) (or fixture base classes in the inheritance chain). Typical use is
alongside **[`TearDown`](teardown.md)** for symmetrical cleanup afterward.

Normally you scatter **multiple** `[SetUp]` methods across inheritance levels (**base**, then **derived**). Declaring several
marked methods on **one class** is allowed, but mutual **order among them is undefined** unless you constrain them logically.

## Static and instance methods

`SetUp` may be **`static`** or an **instance** method. Instance methods execute on **`context.TestObject`**, meaning the **same
fixture instance** that receives the imminent test (`LifeCycle.SingleInstance`) or **a freshly constructed instance** before
every test when [`LifeCycle.InstancePerTestCase`](fixturelifecycle.md) is in effect.

Prefer **instance** `SetUp` for fields on the test object; use **`static`** only when the preparation truly applies without a
specific instance (be careful with shared static state under parallel runs).

Methods may be **`async`** (`Task` / `Task<T>`); NUnit awaits them like other async test infrastructure.

## Failures and assumptions

If `SetUp` throws or an assertion fails, the **test method body is not run**; the result reflects a **setup** failure
(`FailureSite.SetUp`). [`TearDown`](teardown.md) for that same per-test scope **still runs afterwards** in normal operation
so you can release partially initialized resources—unless the run is **aborted** before teardown is reached.

If you use **`Assume.That(...)`** in `SetUp`, a failed assumption also prevents the test body from running (treated like a
setup outcome). Teardown behavior matches the normal path above.

## Usage

This is a parameterless attribute that can only be applied to methods.

```csharp
[SetUp]
```

## Applies To

| Lifecycle Methods | Test Methods | Test Fixtures (Classes) | Assembly |
|-------------------|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ | ❌ |

## Example

[!code-csharp[SetUpExample](~/snippets/Snippets.NUnit/Attributes/SetUpAttributeExamples.cs#SetUpExample)]

## Inheritance

The SetUp attribute is inherited from any base class. Therefore, if a base class has defined a SetUp method, that method
will be called before each test method in the derived class.

You may define a SetUp method in the base class and another in the derived class. NUnit will call base class SetUp
methods before those in the derived classes.

> [!WARNING]
> If a base class SetUp method is overridden in the derived class, NUnit will not call the base class SetUp
> method; NUnit does not anticipate usage that includes hiding the base method. Note that you may have a different name
> for each method; as long as both have the `[SetUp]` attribute present, each will be called in the correct order.

## Notes

1. **`TestContext`** — `SetUp` runs in **per-test** context; most `TestContext` APIs reflect the **about-to-run** test.
2. Multiple `SetUp` methods on the **same** declaration have **no guaranteed** relative order.
3. Base-class `SetUp` runs **before** derived-class `SetUp` (see **Inheritance**).

## See Also

* [TearDown Attribute](teardown.md)
* [OneTimeSetUp Attribute](onetimesetup.md)
* [OneTimeTearDown Attribute](onetimeteardown.md)
* [FixtureLifeCycle Attribute](fixturelifecycle.md)
* [TestFixture Attribute](testfixture.md)
