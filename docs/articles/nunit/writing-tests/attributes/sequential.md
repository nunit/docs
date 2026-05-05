---
uid: sequentialattribute
---

# Sequential

`SequentialAttribute` tells NUnit to generate test cases by matching parameter values by index rather than creating additional combinations.

## Usage

This is a parameterless attribute that can only be applied to test methods.

```csharp
[Sequential]
```

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ |

> [!NOTE]
> If parameter data is provided by multiple attributes, the order in which NUnit uses the data items is not
> guaranteed. However, it can be expected to remain constant for a given runtime and operating system. For best results
> with **SequentialAttribute** use only one data attribute on each parameter.

## Example

The following test is executed three times.

[!code-csharp[SequentialBasic](~/snippets/Snippets.NUnit/Attributes/SequentialAttributeExamples.cs#SequentialBasic)]

MyTest is called three times, as follows:

```csharp
MyTest(1, "A")
MyTest(2, "B")
MyTest(3, null)
```

## Notes

1. `Sequential` pairs values from each parameter by position (`index 0` with `index 0`, and so on).
2. If parameter data lengths differ, missing entries are filled using the default value for that parameter type.
3. Prefer one data-providing attribute per parameter when using `Sequential` to avoid ordering ambiguities.

## See Also

* [Combinatorial Attribute](combinatorial.md)
* [Pairwise Attribute](pairwise.md)
* [Values Attribute](values.md)
