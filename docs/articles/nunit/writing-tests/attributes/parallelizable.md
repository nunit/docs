---
uid: parallelizableattribute
---

# Parallelizable

Added in **NUnit 3.7.**

The **ParallelizableAttribute** is used to indicate that a test and/or its descendants may be run in parallel with other tests. By default, no parallel execution takes place.

When used without an argument, **Parallelizable** causes the test fixture or method on which it is placed to be queued for execution in parallel with other parallelizable tests. It may be used at the assembly, class or method level.

> [!WARNING]
> When tests are run in parallel, you are responsible for the thread safety of your tests. Tests that run at the same time and modify instance fields or properties without locks will cause unexpected behavior as they would in any multi-threaded program. If you are using fields or properties between parallel tests consider using the **FixtureLifeCycleAttribute** to construct a new instance of a test fixture (class) for each test that is run.

The constructor takes an optional **ParallelScope** enumeration argument (see below), which indicates whether the attribute applies to the item itself, to its descendants or both. It defaults to **ParallelScope.Self**. The Scope may also be specified using the named property **scope=**, for example;

```csharp
[Parallelizable(scope: ParallelScope.All)]
```

## ParallelScope Enumeration

This is a **[Flags]** enumeration used to specify which tests may run in parallel. It applies to the test upon which it appears and any subordinate tests. The following values are available to users:

 Value | Meaning | Valid On
-------|---------|---------
**ParallelScope.Self**     | the test itself may be run in parallel with other tests | Classes, Methods
**ParallelScope.Children** | child tests may be run in parallel with one another     | Assembly, Classes
**ParallelScope.Fixtures** | fixtures may be run in parallel with one another        | Assembly, Classes
**ParallelScope.All**      | the test and its descendants may be run in parallel with others at the same level | Classes, Methods

## Notes

* Some values are invalid on certain elements, although they will compile. NUnit will report any tests so marked as invalid and will produce an error message.

2. The **ParallelScope** enum has additional values, which are used internally but are not visible to users through Intellisense.

3. The **ParallelizableAttribute** may be specified on multiple levels of the tests. Settings at a higher level may affect lower level tests, unless those lower-level tests override the inherited settings.

## See Also

* [FixtureLifeCycle Attribute](fixturelifecycle.md)
* [NonParallelizable Attribute](nonparallelizable.md)
* [LevelOfParallelism Attribute](levelofparallelism.md)
