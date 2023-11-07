---
uid: testfixturedata
---

# TestFixtureData

The `TestFixtureData` class provides specific instance information for a parameterized fixture, although any object
deriving from `TestFixtureParameters` may be used. Unlike NUnit 2, you cannot implement `IFixtureData`, you must derive
from `TestFixtureParameters`.

The following example varies the example shown under [TestFixture Attribute](xref:testfixtureattribute) by using a
`TestFixtureSourceAttribute` with a data source in a separately defined class.

[!code-csharp[TestFixtureDataExample](~/snippets/Snippets.NUnit/TestFixtureDataExample.cs#TestFixtureDataExample)]
