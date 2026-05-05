---
uid: combinatorialattribute
---

# Combinatorial

`CombinatorialAttribute` is used on a test method to tell NUnit to generate test cases for all possible combinations of parameter values.

This is NUnit's default combining strategy, so using this attribute is optional unless you want to be explicit.

## Usage

This is a parameterless attribute that can only be applied to test methods.

```csharp
[Combinatorial]
```

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ |

## Example

The following test is executed six times:

[!code-csharp[CombinatorialBasic](~/snippets/Snippets.NUnit/Attributes/CombinatorialAttributeExamples.cs#CombinatorialBasic)]

MyTest is called six times, as follows:

```csharp
MyTest(1, "A")
MyTest(1, "B")
MyTest(2, "A")
MyTest(2, "B")
MyTest(3, "A")
MyTest(3, "B")
```

## Notes

1. When used on a generic method, ensure all combinations of generated arguments are valid.
2. If multiple parameters share the same generic type (for example, `T`), some generated combinations may be invalid.
3. Use `Sequential` or `Pairwise` when combinatorial generation produces too many or unsuitable combinations.

## See Also

* [Sequential Attribute](sequential.md)
* [Pairwise Attribute](pairwise.md)
* [Values Attribute](values.md)
