---
uid: testfixturedata
---

# TestFixtureData

The `TestFixtureData` class provides specific instance information for a parameterized fixture, although any object
deriving from `TestFixtureParameters` may be used. Unlike NUnit 2, you cannot implement `IFixtureData`, you must derive
from `TestFixtureParameters`.

The following example varies the example shown under [TestFixture Attribute](xref:attribute-testfixture) by using a
`TestFixtureSourceAttribute` with a data source in a separately defined class.

[!code-csharp[TestFixtureDataExample](~/snippets/Snippets.NUnit/TestFixtureDataExample.cs#TestFixtureDataExample)]

`TestFixtureData` supports the following properties and methods, which may be appended to an instance in any order.

* `Explicit()` or `Explicit(string)` causes the fixture to be marked explicit, optionally specifying the reason
  for doing so.
* `Ignore(string)` causes the fixture to be ignored and specifies the reason, which is required.
* `SetArgDisplayNames(string[])` sets the list of display names to use as the parameters in the fixture name.
* `SetArgDisplayNames(object[])` sets the list of display names using objects that are automatically formatted.
  (_NUnit 4.5+_)
* `TypeArgs` specifies the `Type`s to be used when targeting a generic fixture.

The following example uses the fluent interface to give each fixture a readable name, and to mark one fixture explicit
and another ignored.

[!code-csharp[TestFixtureDataFluentExample](~/snippets/Snippets.NUnit/TestFixtureDataExample.cs#TestFixtureDataFluentExample)]

> [!NOTE]
> Unlike `TestCaseData`, `TestFixtureData` has no public `SetName` method. To control how a fixture is named, use
> `SetArgDisplayNames`.
