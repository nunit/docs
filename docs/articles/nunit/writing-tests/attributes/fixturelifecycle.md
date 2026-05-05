---
uid: fixturelifecycleattribute
---

# FixtureLifeCycle

Added in **NUnit 3.13**.

`FixtureLifeCycleAttribute` selects how NUnit constructs your fixture class:

* **`LifeCycle.SingleInstance`** — one instance is created and **shared** by every test in the fixture. This matches the
  usual NUnit default when you do not use the attribute.
* **`LifeCycle.InstancePerTestCase`** — a **new** instance is created for each test.

Place the attribute on a **fixture class** to control that class, or on the **assembly** to set a default for all
fixtures in that assembly. A class-level attribute **overrides** an assembly-level default.

`InstancePerTestCase` is often combined with [Parallelizable](xref:parallelizableattribute). With a separate instance per test,
instance fields are not shared while tests run in parallel, which avoids a common source of interference and often makes
**thread safety for instance state** easier—while still leaving you responsible for static state, shared singletons, and
other resources outside the fixture instance.

## Constructor

```csharp
FixtureLifeCycleAttribute(LifeCycle lifeCycle)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `lifeCycle` | `LifeCycle` | `SingleInstance` or `InstancePerTestCase`. |

## Properties

| Property | Type | Description | Default |
|----------|------|-------------|---------|
| `LifeCycle` | `LifeCycle` | Life cycle for the fixture or assembly. | _(from constructor)_ |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ❌ | ✅ | ✅ |

Assembly-level settings can be overridden by a class-level attribute.

## LifeCycle enumeration

| Value | Meaning |
|-------|---------|
| `LifeCycle.SingleInstance` | A single instance is created and shared for all test cases. This is the default. |
| `LifeCycle.InstancePerTestCase` | A new instance is created for each test case. |

## Notes

* When using `LifeCycle.InstancePerTestCase`, the [`OneTimeSetUp`](xref:onetimesetup-attribute) and
  [`OneTimeTearDown`](xref:onetimeteardown-attribute) methods must be static, and each are only called once. This is
  required so that the setup or teardown methods do not access instance fields or properties that are reset for every
  test.

* When using `LifeCycle.InstancePerTestCase`, a class's constructor will be called before every test is executed and
  `IDisposable` test fixtures will be disposed after the test is finished.

* [`SetUp`](xref:setup-attribute) and [`TearDown`](xref:teardown-attribute) methods are called before and after every
  test.

* The `Order` attribute is respected.

## See Also

* [Parallelizable Attribute](xref:parallelizableattribute)
* [OneTimeSetUp Attribute](xref:onetimesetup-attribute)
* [OneTimeTearDown Attribute](xref:onetimeteardown-attribute)
