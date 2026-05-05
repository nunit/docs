---
uid: testfixtureteardownattribute
---

# TestFixtureTearDown

> [!IMPORTANT]
> The TestFixtureTearDown attribute has been deprecated. Use [OneTimeTearDown Attribute](xref:onetimeteardown-attribute) instead.

`TestFixtureTearDownAttribute` was used in older NUnit versions for one-time teardown after all tests in a fixture.

## Usage

This legacy attribute is deprecated and should be replaced with `[OneTimeTearDown]`.

## Applies To

| Lifecycle Methods | Test Methods | Test Fixtures (Classes) | Assembly |
|-------------------|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ | ❌ |

## See Also

* [OneTimeTearDown Attribute](xref:onetimeteardown-attribute)
* [TearDown Attribute](xref:teardown-attribute)
