---
uid: constraint-throws
---

# Throws Constraint

`ThrowsConstraint` is used to test that code, represented as a delegate, throws a particular exception. It may be used
alone to test the exception type, or with additional constraints applied to the exception itself. The related
[ThrowsNothingConstraint](ThrowsNothingConstraint.md) asserts that the delegate does not throw.

## Usage

```csharp
Throws.Exception
Throws.TypeOf<T>()
Throws.TypeOf(Type expectedType)
Throws.InstanceOf<T>()
Throws.InstanceOf(Type expectedType)

// Common exception shortcuts
Throws.ArgumentException
Throws.ArgumentNullException
Throws.InvalidOperationException
Throws.TargetInvocationException

// For testing nothing is thrown
Throws.Nothing
```

## Modifiers

```csharp
.With.Message.EqualTo(string)     // Test exception message
.With.Message.Contains(string)    // Test message contains substring
.With.Property("Name").EqualTo(x) // Test exception property
.With.InnerException.TypeOf<T>()  // Test inner exception
.ParamName.EqualTo(string)        // Test ArgumentException.ParamName (From version 5)
```

### ParamName (From version 5)

For `ArgumentException` and derived types, the generic exception constraints have a `ParamName` property. It checks
which parameter caused the exception, without needing `.With.Property("ParamName")`. It is available after
`Throws.TypeOf<T>()`, `Throws.InstanceOf<T>()`, `Throws.ArgumentException` and `Throws.ArgumentNullException`, and
must come directly after them in the constraint expression.

`ParamName` is a C# 14 extension property, so your test project must use C# 14 or later.

[!code-csharp[ThrowsConstraintParamNameExamples](~/snippets/Snippets.NUnit/Constraints/ComparisonConstraintSnippets.cs#ThrowsConstraintParamNameExamples)]

## Examples

[!code-csharp[ThrowsConstraintBasicExamples](~/snippets/Snippets.NUnit/Constraints/ComparisonConstraintSnippets.cs#ThrowsConstraintBasicExamples)]

### Additional Examples

[!code-csharp[ThrowsConstraintExamples](~/snippets/Snippets.NUnit/ConstraintExamples.cs#ThrowsConstraintExamples)]

## Notes

1. **Throws.TypeOf** requires an exact type match. Use **Throws.InstanceOf** to allow derived exception types.
2. **Throws.Exception** can be followed by additional constraints on the exception object. Avoid using it alone without
   type checking, as you should generally know what exception to expect.
3. For async code, use `Assert.ThrowsAsync` or test the async delegate directly with `Throws`.
4. **Throws.InnerException** tests the InnerException property. Combine it with outer exception type tests for full
   validation.

## See Also

* [ThrowsNothing Constraint](ThrowsNothingConstraint.md)
* [Assert.Throws](../assertions/classic-assertions/Assert.Throws.md)
* [Assert.ThrowsAsync](../assertions/classic-assertions/Assert.ThrowsAsync.md)
