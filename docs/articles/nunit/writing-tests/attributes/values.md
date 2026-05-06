---
uid: attribute-values
---

# Values

`ValuesAttribute` specifies literal values for a parameter of a parameterized test method.

By default, NUnit combines values across parameters combinatorially unless the method is marked with a different combining attribute.

> [!NOTE]
> Once **any** parameter on a parameterized test specifies data (`[Values]`, `[Range]`, `[TestCase]`, …), **every** parameter must have a data source—the framework builds Cartesian products (or pairwise/sequential variants) across parameters. See [Parameterized Tests](xref:parameterizedtests).

## Constructors

```csharp
ValuesAttribute()
ValuesAttribute(object arg1)
ValuesAttribute(object arg1, object arg2)
ValuesAttribute(object arg1, object arg2, object arg3)
ValuesAttribute(params object[] args)
```

| Parameter | Type        | Description                                |
|-----------|-------------|--------------------------------------------|
| `args`    | `object[]`  | Literal values supplied for the parameter. |

## Applies To

| Method Parameters | Test Methods | Test Fixtures (Classes) | Assembly |
|-------------------|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ | ❌ |

## Example

[!code-csharp[ValuesAttributeExample](~/snippets/Snippets.NUnit/Attributes/ValuesAttributeExamples.cs#ValuesAttributeExample)]

The above test will be executed six times, as follows:

```csharp
MyTest(1, "A")
MyTest(1, "B")
MyTest(2, "A")
MyTest(2, "B")
MyTest(3, "A")
MyTest(3, "B")
```

## Values with enum or bool

Parameterless **`[Values]`** expands enums and Booleans differently from other parameter types:

When used without any arguments, the **[Values]** attribute on an enum parameter
will automatically include all possible values of the enumeration.

[!code-csharp[ValuesAttributeEnumExample](~/snippets/Snippets.NUnit/Attributes/ValuesAttributeExamples.cs#ValuesAttributeEnumExample)]

For **`bool`**, the same mechanism supplies **`false`** then **`true`**. For **`bool?`**, NUnit adds **`null`** alongside those flags. For **`Nullable<T>` enums**, every enum constant **plus null** are generated.

[!code-csharp[ValuesAttributeBoolExample](~/snippets/Snippets.NUnit/Attributes/ValuesAttributeExamples.cs#ValuesAttributeBoolExample)]

## Notes

1. **`Values()`** with **no positional arguments** only auto-expands enums, Booleans (including **`bool?`**), and nullable enums; for other parameter types it yields nothing useful until you supply explicit values.
2. Use method-level `Combinatorial`, `Sequential`, or `Pairwise` to control how values from multiple parameters combine.
3. Values you pass to **`[Values(...)]`** are converted to the parameter type with the same attribute-argument conversion rules as **`[TestCase]`** (including **`Convert.ChangeType`** where applicable); see the opening note on **[TestCase](xref:attribute-testcase)**.

## See also

* [Range Attribute](xref:attribute-range)
* [Random Attribute](xref:attribute-random)
* [Sequential Attribute](xref:attribute-sequential)
* [Combinatorial Attribute](xref:attribute-combinatorial)
* [Pairwise Attribute](xref:attribute-pairwise)
