# TestFixtureTearDown

> [!IMPORTANT]
> The TestFixtureTearDown attribute has been deprecated. Use [OneTimeTearDown Attribute](onetimeteardown.md) instead.

`TestFixtureTearDownAttribute` was used in older NUnit versions for one-time teardown after all tests in a fixture.

## Usage

This legacy attribute is deprecated and should be replaced with `[OneTimeTearDown]`.

## Applies To

| Lifecycle Methods | Test Methods | Test Fixtures (Classes) | Assembly |
|-------------------|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ | ❌ |

## See Also

* [OneTimeTearDown Attribute](onetimeteardown.md)
* [TearDown Attribute](teardown.md)
