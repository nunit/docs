---
uid: category-attribute
---

# Category

`CategoryAttribute` provides a way to group tests into categories. Categories can be used to include or exclude specific groups of tests when running from the command line or test runners. When categories are used to filter tests, only tests in the selected categories will be run, and excluded tests are not reported.

## Constructors

```csharp
CategoryAttribute(string name)
protected CategoryAttribute()  // For derived classes
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `name` | `string` | The name of the category. May not contain `,`, `+`, `-`, or `!` characters. |

The protected parameterless constructor is used when creating custom category attributes - it sets the category name to the derived class name (minus the "Attribute" suffix).

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Name` | `string` | Gets the name of the category. |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ✅ |

> [!WARNING]
> While the C# syntax allows you to place a Category attribute on a SetUpFixture class, the attribute is ignored by NUnit and has no effect.

## Examples

### Test Fixture Level

[!code-csharp[CategoryTestFixtureExample](~/snippets/Snippets.NUnit/AttributeExamples.cs#CategoryTestFixtureExample)]

### Test Method Level

[!code-csharp[CategoryTestExample](~/snippets/Snippets.NUnit/AttributeExamples.cs#CategoryTestExample)]

### Custom Category Attributes

Custom attributes that derive from `CategoryAttribute` will be recognized by NUnit. The default protected constructor sets the category name to the name of your class (minus "Attribute").

[!code-csharp[CustomCategoryAttribute](~/snippets/Snippets.NUnit/AttributeExamples.cs#CustomCategoryAttribute)]

## Command Line Usage

Categories can be filtered using `dotnet test` or the NUnit console runner:

```shell
# dotnet test (via NUnit adapter)
dotnet test --filter "TestCategory=Fast"
dotnet test -- NUnit.Where="cat == Fast"

# Exclude a category
dotnet test --filter "TestCategory!=Slow"

# Multiple categories
dotnet test --filter "TestCategory=Unit|TestCategory=Integration"

# NUnit Console Runner
nunit3-console MyTests.dll --where "cat == Fast"
nunit3-console MyTests.dll --where "cat != Slow"
nunit3-console MyTests.dll --where "cat == Unit || cat == Integration"
```

## Notes

1. Multiple `Category` attributes can be applied to the same test or fixture.
2. Category names may not contain the characters `,`, `+`, `-`, or `!` as these are used as operators in category expressions.
3. Categories are inherited - a test inherits all categories from its fixture and assembly.
4. Category names are case-sensitive.
5. When no category filter is specified, all tests run regardless of their categories.

## See Also

* [Console Command Line](xref:consolecommandline)
* [Property Attribute](property.md)
