---
name: NUnit Attribute Documentation
description: Create and update documentation for NUnit attributes following the established template structure
---

# NUnit Attribute Documentation

This skill describes how to create and update documentation for NUnit attributes.

## Documentation Template Structure

Each attribute documentation file in `docs/articles/nunit/writing-tests/attributes/` should follow this structure:

````markdown
# AttributeName

Brief description of what the attribute does.

## Constructor

```csharp
AttributeName(paramType paramName)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `paramName` | `Type` | Description of the parameter. Include important notes like valid ranges or default behavior. |

## Properties

| Property | Type | Description | Default |
|----------|------|-------------|---------|
| `PropertyName` | `Type` | Description of the property. | `defaultValue` |

> [!NOTE]
> Version notes if applicable (e.g., "Added in **NUnit 4.5.0**").

## Applies To

Use a table with checkmarks to show where the attribute can be applied:

| Target | Supported |
|--------|-----------|
| Test Methods | ✅ |
| Test Fixtures (Classes) | ✅ |
| Assemblies | ❌ |

Use ✅ (green checkmark) where the attribute applies, ❌ (red X) where it doesn't.

## Example

[!code-csharp[ExampleName](~/snippets/Snippets.NUnit/Attributes/AttributeNameExamples.cs#RegionName)]

## Notes

1. Important behavioral notes
2. Limitations
3. Edge cases

## See Also

* [Related Attribute](relatedattribute.md)
````

### For Parameterless Attributes

Use a simpler "Usage" section instead of Constructor/Properties:

````markdown
## Usage

This is a parameterless attribute that can only be applied to [target].

```csharp
[AttributeName]
```
````

## Workflow for Updating Attribute Documentation

### Step 1: Find the Source Code

Search for the attribute class in the NUnit framework:

```shell
# Find the attribute source file
grep -r "class AttributeNameAttribute" C:/repos/nunit/nunit --include="*.cs"
```

The source is typically at:
`C:\repos\nunit\nunit\src\NUnitFramework\framework\Attributes\AttributeNameAttribute.cs`

### Step 2: Analyze the Source Code

From the source file, extract:
- Constructor parameters and their XML doc comments
- Properties with their types, descriptions, and default values
- `AttributeUsage` to determine valid targets (Class, Method, Assembly)
- Whether `Inherited = true`

### Step 3: Check for Existing Unit Tests

```shell
# Find unit tests for the attribute
grep -r "AttributeName" C:/repos/nunit/nunit/src/NUnitFramework/tests --include="*.cs"
```

Tests are typically at:
`C:\repos\nunit\nunit\src\NUnitFramework\tests\Attributes\AttributeNameAttributeTests.cs`

Unit tests provide good examples of usage patterns and edge cases.

### Step 4: Create Snippet File

Create a new file at:
`docs/snippets/Snippets.NUnit/Attributes/AttributeNameAttributeExamples.cs`

Follow this pattern:

```csharp
using NUnit.Framework;

namespace Snippets.NUnit.Attributes
{
    public class AttributeNameAttributeExamples
    {
        #region ExampleName
        [TestFixture]
        public class ExampleTests
        {
            [Test]
            public void ExampleTest()
            {
                // Test code that demonstrates the attribute
                Assert.That(true, Is.True);
            }
        }
        #endregion

        #region AnotherExample
        // More examples...
        #endregion
    }
}
```

Key points:
- Use `#region` / `#endregion` to mark code sections
- Region names are used in the markdown reference: `#RegionName`
- Tests must actually pass - avoid stub code that doesn't work
- If you need helper classes, make them private nested classes

### Step 5: Update the Markdown Documentation

Reference snippets using DocFX syntax:

```markdown
[!code-csharp[ExampleName](~/snippets/Snippets.NUnit/Attributes/AttributeNameExamples.cs#ExampleName)]
```

### Step 6: Build and Test

Always verify the snippets compile and tests pass:

```shell
cd C:/repos/nunit/docs/docs/snippets

# Build
dotnet build Snippets.slnx

# Run all tests
dotnet test Snippets.slnx --no-build

# Run specific tests
dotnet test Snippets.slnx --no-build --filter "FullyQualifiedName~AttributeNameExamples" --verbosity normal
```

### Step 7: Update the Plan File

Mark the attribute as done in `docs-improvement-plan.md`:

```markdown
| AttributeName | Done | Brief notes about what was added |
```

## Common Attribute Patterns

### Attributes with Constructor Parameters Only
Examples: `Retry`, `Repeat`, `MaxTime`, `Order`

### Attributes with Properties
Examples: `Retry` (has `RetryExceptions`), `TestCase` (has many named parameters)

### Parameterless Attributes
Examples: `SingleThreaded`, `NonParallelizable`, `Combinatorial`

### Enum-based Attributes
Examples: `Parallelizable` (takes `ParallelScope`), `Apartment` (takes `ApartmentState`)

Document the enum values in a table.

## Command Line Documentation Guidelines

When documenting command line usage:

1. **Use appropriate code fences** - Use ` ```shell ` for command line examples, not ` ```shell ` or plain code blocks.

2. **Prioritize `dotnet test`** - Always mention `dotnet test` before the NUnit console runner, as it is used far more frequently.

3. **Include runsettings equivalents** - When mentioning console runner options (like `--timeout`, `--workers`, etc.), note that these settings can also be configured for `dotnet test` via the NUnit adapter's `.runsettings` file.

Example:

````markdown
## Command Line Usage

```shell
# dotnet test (via NUnit adapter)
dotnet test --filter "TestCategory=Fast"

# Or via runsettings
dotnet test --settings test.runsettings

# NUnit Console Runner
nunit3-console MyTests.dll --where "cat == Fast"
```
````

## Quality Checklist

Before marking an attribute as done:

- [ ] Constructor section with parameter table (if applicable)
- [ ] Properties section with defaults (if applicable)
- [ ] At least one working code example in snippets folder
- [ ] Examples build without errors
- [ ] Example tests pass
- [ ] Notes section with important behavioral info
- [ ] See Also section with related attributes
- [ ] Plan file updated
