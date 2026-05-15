---
name: NUnit Constraint Documentation
description: Create and update documentation for NUnit constraints following the established template structure
---

# NUnit Constraint Documentation

This skill describes how to create and update documentation for NUnit constraints.

## Documentation Template Structure

Each constraint documentation file in `docs/articles/nunit/writing-tests/constraints/` should follow this structure:

````markdown
---
uid: constraint-<name>
---

# <Name> Constraint

Brief description (2-3 sentences) explaining what the constraint tests and when to use it.

## Usage

```csharp
Is.<Method>(args)           // Primary syntax
Does.<Method>(args)         // If applicable
Has.<Method>(args)          // If applicable
```

## Modifiers

```csharp
.IgnoreCase                 // Makes comparison case-insensitive
.Using(IComparer comparer)  // Uses custom comparison logic
.Within(tolerance)          // Allows approximate matching
```

> [!NOTE]
> Only include this section if the constraint has modifiers.

## Examples

Inline one-liners showing common patterns:

```csharp
Assert.That(actual, Is.<Method>(expected));
Assert.That(actual, Is.Not.<Method>(expected));
Assert.That(actual, Is.<Method>(expected).IgnoreCase);
```

### [Scenario Section - only if complex setup needed]

Brief explanation of the scenario.

[!code-csharp[ScenarioExample](~/snippets/Snippets.NUnit/ConstraintExamples.cs#ScenarioExample)]

## Notes

1. Important behavioral notes
2. Edge cases
3. Compatibility information

## See Also

* [Related Constraint](related.md)
* [Another Related](another.md)
````

## Key Structural Principles

| Section | Purpose |
|---------|---------|
| Usage (first) | Users interact with fluent API (`Is.*`, `Does.*`), not constructors |
| Modifiers | Use `.ModifierName` format (shows method chaining) |
| Examples | Inline one-liners for common patterns |
| Notes | Edge cases and important behaviors |
| See Also | Links to related constraints |

## Inline vs External Examples

**Inline examples** (in the markdown itself):
- **Usage section**: Always inline - shows the API surface (1-3 lines of just the syntax)
- **Examples section**: One-liners demonstrating common patterns without test boilerplate

````markdown
## Usage

```csharp
Is.Null
Is.Not.Null
```

## Examples

```csharp
Assert.That(myObject, Is.Null);
Assert.That(myString, Is.Not.Null);
Assert.That(GetResult(), Is.Null.Or.Empty);  // Combined with other constraints
```
````

**External snippets** (from Snippets.NUnit):
- Complex scenarios requiring setup code (custom comparers, test data, helper classes)
- Full compilable test methods that verify the documentation is correct
- Scenarios where the setup/context is important to understand

````markdown
### Using Custom Comparers

[!code-csharp[EqualWithComparer](~/snippets/Snippets.NUnit/ConstraintExamples.cs#EqualWithComparer)]
````

**Never inline:**
- Full `[Test] public void...` methods - those go in external snippets
- Examples requiring helper classes or significant setup

## UID Standardization

All constraint UIDs should follow the pattern: `constraint-<lowercase-name>`

Examples:
- `equalconstraint` → `constraint-equal`
- `nullconstraint` → `constraint-null`
- `greaterthanconstraint` → `constraint-greaterthan`

## Workflow for Updating Constraint Documentation

> **Repository Layout Assumption**: This workflow assumes you have cloned both repositories as siblings:
> - `<workspace>/nunit/` - The NUnit framework source code ([nunit/nunit](https://github.com/nunit/nunit))
> - `<workspace>/docs/` - This documentation repository ([nunit/docs](https://github.com/nunit/docs))
>
> Adjust paths below to match your local setup.

### Step 1: Find the Source Code

Search for the constraint class in the NUnit framework:

```shell
# Find the constraint source file (adjust path to your nunit repo location)
grep -r "class <Name>Constraint" ../nunit/src/NUnitFramework/framework/Constraints --include="*.cs"
```

The source is typically at:
`<nunit-repo>/src/NUnitFramework/framework/Constraints/<Name>Constraint.cs`

### Step 2: Analyze the Source Code

From the source file, extract:
- Available syntax helpers (check `Is.cs`, `Does.cs`, `Has.cs`, `Contains.cs`)
- Modifier methods and their purposes
- Constructor parameters (for reference, not for documentation focus)
- Any special behaviors or edge cases from XML doc comments

### Step 3: Check for Existing Unit Tests

```shell
# Find unit tests for the constraint (adjust path to your nunit repo location)
grep -r "<Name>Constraint" ../nunit/src/NUnitFramework/tests --include="*.cs"
```

Unit tests provide good examples of usage patterns and edge cases.

### Step 4: Update the Markdown Documentation

Follow the template structure above. Key points:
- Lead with Usage section showing the fluent API
- Include inline examples for quick reference
- Add external snippet references for complex scenarios
- Document all available modifiers with brief descriptions

### Step 5: Update or Create Snippet Examples

If complex scenarios need external snippets, add them to:
`docs/snippets/Snippets.NUnit/ConstraintExamples.cs`

Use regions to organize:

```csharp
#region <Name>ConstraintExamples
[Test]
public void <Name>Constraint_WithCustomComparer()
{
    // Example with setup that's too complex for inline
    var comparer = new MyCustomComparer();
    Assert.That(actual, Is.<Method>(expected).Using(comparer));
}
#endregion
```

### Step 6: Build and Test

Always verify the snippets compile and tests pass. From the docs repository root:

```shell
# Build
dotnet build docs/snippets/Snippets.slnx

# Run all tests
dotnet test docs/snippets/Snippets.slnx --no-build

# Run specific constraint tests
dotnet test docs/snippets/Snippets.slnx --no-build --filter "FullyQualifiedName~ConstraintExamples" --verbosity normal
```

## Quality Checklist

Before marking a constraint as done:

- [ ] UID follows `constraint-<name>` pattern
- [ ] Description is 2-3 sentences explaining purpose
- [ ] Usage section shows fluent API methods (inline, 1-3 lines)
- [ ] Modifiers section (if applicable) with brief descriptions
- [ ] Examples section with inline one-liners for common patterns
- [ ] External snippets for complex scenarios (custom comparers, setup-heavy)
- [ ] Examples have subsection headers if multiple scenarios exist
- [ ] Notes section for edge cases/important behaviors
- [ ] See Also links to related constraints
- [ ] Version info for features added after NUnit 3.0

## Common Constraint Patterns

### Simple Constraints (no modifiers)
Examples: `NullConstraint`, `TrueConstraint`, `FalseConstraint`, `NaNConstraint`

These need minimal documentation but should still have:
- Clear description
- Usage showing `Is.<Name>` and `Is.Not.<Name>`
- 2-3 inline examples

### Comparison Constraints (with Using/Within modifiers)
Examples: `EqualConstraint`, `GreaterThanConstraint`, `LessThanConstraint`

These need:
- Modifiers section documenting `.Using()` and `.Within()` variants
- Examples showing basic comparison and modifier usage
- External snippets for custom comparer scenarios

### Collection Constraints (with collection-specific modifiers)
Examples: `CollectionEquivalentConstraint`, `UniqueItemsConstraint`, `AllItemsConstraint`

These need:
- Modifiers section with `.IgnoreCase`, `.Using()`, `.UsingPropertiesComparer()`
- Examples showing different collection types
- Notes about element comparison behavior

### String Constraints (with string-specific modifiers)
Examples: `StartsWithConstraint`, `SubstringConstraint`, `RegexConstraint`

These need:
- Modifiers for `.IgnoreCase`, `.Using(StringComparison)`, `.Using(CultureInfo)`
- Examples showing case-sensitive and case-insensitive usage
- Notes about culture-specific behavior where applicable
