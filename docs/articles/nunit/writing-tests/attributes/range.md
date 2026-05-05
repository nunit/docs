---
uid: rangeattribute
---

# Range

`RangeAttribute` supplies a sequence of values for **one parameter** on a parameterized test method.

Once you supply explicit data sources (such as `Range`, [`Values`](xref:valuesattribute), [`Random`](xref:randomattribute), etc.) for **any**
parameter on that method, you must specify **sources for every parameter**—see [Parameterized Tests](xref:parameterizedtests).

By default, NUnit merges parameters **combinatorially** (every combination). Use [`Sequential`](xref:sequentialattribute),
[`Pairwise`](xref:pairwiseattribute), or another combining strategy on the **method** to change pairing behavior.

## Constructors

```csharp
RangeAttribute(int from, int to)
RangeAttribute(uint from, uint to)
RangeAttribute(long from, long to)
RangeAttribute(ulong from, ulong to)
RangeAttribute(int from, int to, int step)
RangeAttribute(uint from, uint to, uint step)
RangeAttribute(long from, long to, long step)
RangeAttribute(ulong from, ulong to, ulong step)
RangeAttribute(float from, float to, float step)
RangeAttribute(double from, double to, double step)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `from` | numeric | First yielded value |
| `to` | numeric | End of the progression; yielded while stepping **toward** this bound without crossing it |
| `step` | numeric | Increment between values (**required** for `float`/`double`; when omitted on signed integral types `from`/`to`, NUnit uses **1 or −1**, matching whether `from` < `to` or `from` > `to`) |

Unsigned `uint` / `ulong` ranges require **`to` ≥ `from`** and a **positive** `step` (no automatic downward ranges).
Floating-point generators stop at the **last** value reached before arithmetic would overshoot `to`; if `from`/`to`/step
produce no exact landing on `to`, **`to` itself might not appear**.

## Applies To

| Method Parameters | Test Methods | Test Fixtures (Classes) | Assembly |
|-------------------|--------------|--------------------------|----------|
| ✅ | ❌ | ❌ | ❌ |

## Example

The following test will be executed nine times.

[!code-csharp[RangeAttributeExample](~/snippets/Snippets.NUnit/Attributes/RangeAttributeExamples.cs#RangeAttributeExample)]

The MyTest method is called nine times, as follows:

```csharp
MyTest(1, 0.2)
MyTest(1, 0.4)
MyTest(1, 0.6)
MyTest(2, 0.2)
MyTest(2, 0.4)
MyTest(2, 0.6)
MyTest(3, 0.2)
MyTest(3, 0.4)
MyTest(3, 0.6)
```

## Notes

1. Annotate **`[Range]` directly on the method parameter**. `AllowMultiple` is **true**, so repeat the attribute if you want
   several disjoint spans merged for the same argument.
2. **Signed** integral two-argument constructors pick default step **`+1` or −1**, so **`[Range(5, 1)]`** yields a descending sequence.
   **Unsigned** constructors throw if `from` > `to`.
3. Resulting Cartesian products still depend on whichever combining attributes appear on the test method (**Combinatorial** by default).
4. `float`/`double` overloads always require an explicit **`step`**; there is **no two-argument** floating-point shortcut.

## See Also

* [Values Attribute](xref:valuesattribute)
* [Random Attribute](xref:randomattribute)
* [Sequential Attribute](xref:sequentialattribute)
* [Combinatorial Attribute](xref:combinatorialattribute)
* [Pairwise Attribute](xref:pairwiseattribute)
