---
uid: onetimeteardown-attribute
---

# OneTimeTearDown

`OneTimeTearDownAttribute` marks a method that runs **once** after **every child test finished** under a suite—for that
fixture or setup-fixture scope. Pair it with [`OneTimeSetUp`](xref:onetimesetup-attribute).

Put it on a method inside a [`TestFixture`](xref:testfixtureattribute) or a [`SetUpFixture`](xref:setupfixture-attribute).

Normally you declare multiple `OneTimeTearDown` methods spread across an **inheritance chain** (derived first at runtime,
then base—see **Inheritance** below). Putting several methods on the **same class** is allowed, but execution **order among
them is undefined** unless you constrain them logically.

## Static and instance methods

`OneTimeTearDown` may be **static** or an **instance** method.

With [`LifeCycle.SingleInstance`](xref:fixturelifecycleattribute), an **instance** method runs once on the same shared fixture instance
that held `OneTimeSetUp`/`SetUp`; use it for instance-field cleanup tied to shared setup.

With [`FixtureLifeCycle(LifeCycle.InstancePerTestCase)`](xref:fixturelifecycleattribute), `OneTimeTearDown` **must be static**. It runs
once after all tests despite each case having its **own** instance; instance teardown belongs in [`TearDown`](xref:teardown-attribute)
per test instead.

Methods may be **async** (`Task` / `Task<T>`): NUnit will wait for completion.

## Test fixture versus SetUp fixture

* **`TestFixture`** — teardown runs **after all tests declared in that fixture** (every parameterized case rooted there)
finish, failed or passed unless something aborts scheduling earlier.
* **`SetUpFixture`** — teardown runs once after everything under that [**SetUpFixture**](xref:setupfixture-attribute) slice finishes,
matching the broader “run once init / run once cleanup” workflow.

Teardown semantics for **abstract or concrete bases** mirror setup: inheritance causes code to participate per derived
fixture type unless you refactor to **`SetUpFixture`** or **`static`** cleanup patterns when you truly need cross-suite
lifetime control.

## When teardown runs relative to failures

* **After [`OneTimeSetUp`](xref:onetimesetup-attribute) fails** — once children are skipped, NUnit typically still invokes
this fixture’s teardown chain so disposal paths can execute. See **[OneTimeSetUp — Failures and exceptions](xref:onetimesetup-attribute#failures-and-exceptions)**.

* **`OneTimeTearDown` failures** — assertion failures or exceptions during teardown are recorded on the **fixture / suite**
  result as teardown failures. Individual child test outcomes are usually left as they were, but runners still surface the
  teardown problem.

* **Cancellation / abort** — if execution ends in an **abort** state, teardown may not run (for example parallel stop).
Normal **stop-on-error** still lets scheduled teardown phases run unless the dispatcher aborts the run.

NUnit schedules fixture teardown **after every direct child of that suite finishes** (runs, failures, or skips scheduled
from parent setup). Do not treat teardown as a synchronous callback you can trigger from inside an individual `[Test]`
method body.

## Usage

This is a parameterless attribute that can only be applied to methods.

```csharp
[OneTimeTearDown]
```

## Applies To

| Lifecycle Methods | Test Methods | Test Fixtures (Classes) | Assembly |
|-------------------|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ | ❌ |

## Example

[!code-csharp[OneTimeTearDownExample](~/snippets/Snippets.NUnit/Attributes/OneTimeTearDownAttributeExamples.cs#OneTimeTearDownExample)]

## Inheritance

The OneTimeTearDown attribute is inherited from any base class. Therefore, if a base class has defined a OneTimeTearDown
method, that method will be called after any test methods in the derived class.

You may define a OneTimeTearDown method in the base class and another in the derived class. NUnit will call base class
OneTimeTearDown methods after those in the derived classes.

> [!WARNING]
> If a base class OneTimeTearDown method is overridden in the derived class, NUnit will not call the base
> class OneTimeTearDown method; NUnit does not anticipate usage that includes hiding the base method. Note that you may
> have a different name for each method; as long as both have the `[OneTimeTearDown]` attribute present, each will be
> called in the correct order.

## Notes

1. **`TestContext`** — like `OneTimeSetUp`, `OneTimeTearDown` runs in **fixture / setup-fixture** context, **not**
   per-test context. Exercise caution using [`TestContext`](xref:testcontext) APIs meant for `[Test]` methods.
2. Multiple `OneTimeTearDown` methods on the **same** declaration run without a guaranteed mutual order unless you arrange
   them logically.
3. Across inheritance, **derived** `OneTimeTearDown` methods run **before** base-class teardowns when both apply (see **Inheritance**).

## See Also

* [SetUp Attribute](xref:setup-attribute)
* [TearDown Attribute](xref:teardown-attribute)
* [OneTimeSetUp Attribute](xref:onetimesetup-attribute)
* [SetUpFixture Attribute](xref:setupfixture-attribute)
* [FixtureLifeCycle Attribute](xref:fixturelifecycleattribute)
