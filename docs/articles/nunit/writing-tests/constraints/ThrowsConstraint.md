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
```

## Examples

```csharp
// Test for specific exception type
Assert.That(() => MethodThatThrows(), Throws.TypeOf<ArgumentException>());
Assert.That(() => MethodThatThrows(), Throws.InstanceOf<Exception>());

// Test exception message
Assert.That(() => throw new ArgumentException("bad value"),
    Throws.ArgumentException.With.Message.EqualTo("bad value"));

// Test with lambda expression
Assert.That(() => int.Parse("abc"), Throws.TypeOf<FormatException>());

// Assert no exception is thrown
Assert.That(() => SafeMethod(), Throws.Nothing);
```

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
* [Assert.Throws](xref:classicassertthrows)
* [Assert.ThrowsAsync](xref:classicassertthrowsasync)
