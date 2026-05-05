# TestFixtureSetUp

> [!IMPORTANT]
> The TestFixtureSetUp attribute has been deprecated. Use [OneTimeSetUp Attribute](onetimesetup.md) instead.

`TestFixtureSetUpAttribute` was used in older NUnit versions for one-time setup before tests in a fixture.

## Usage

This legacy attribute is deprecated and should be replaced with `[OneTimeSetUp]`.

## Applies To

| Lifecycle Methods | Test Methods | Test Fixtures (Classes) | Assembly |
|-------------------|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ | ❌ |

## See Also

* [OneTimeSetUp Attribute](onetimesetup.md)
* [SetUp Attribute](setup.md)
