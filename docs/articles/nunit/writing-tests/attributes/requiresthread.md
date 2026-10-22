---
uid: attribute-requiresthread
---

# RequiresThread

`RequiresThreadAttribute` is used to indicate that a test method, class, or assembly should always run on a separate thread. Optionally, the desired apartment state for the thread may be specified.

## Constructors

```csharp
RequiresThreadAttribute()
RequiresThreadAttribute(ApartmentState apartment)
```

| Parameter   | Type             | Description                                                                 |
| ----------- | ---------------- | --------------------------------------------------------------------------- |
| `apartment` | `ApartmentState` | The apartment state for the thread. Must be `STA` or `MTA` (not `Unknown`). |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
| ------------ | ----------------------- | -------- |
| ✅           | ✅                      | ✅       |

## Examples

### Fixture Level

[!code-csharp[RequiresThreadFixture](~/snippets/Snippets.NUnit/Attributes/RequiresThreadAttributeExamples.cs#RequiresThreadFixture)]

### Method Level with Apartment State

[!code-csharp[RequiresThreadMethod](~/snippets/Snippets.NUnit/Attributes/RequiresThreadAttributeExamples.cs#RequiresThreadMethod)]

### Assembly Level

```csharp
// The whole assembly runs on a separate thread
[assembly: RequiresThread]
```

Assembly-level use is rarely needed. Runners already execute each test assembly on its own thread, so the attribute
adds little at that level. It was more useful in earlier versions of NUnit and is kept for compatibility.

## When to Use It

Most test projects never need this attribute. Its intended use is on a test method, or occasionally a fixture, whose
code intentionally corrupts the state of the thread it runs on: for example by changing thread-local storage, the
thread's culture or principal without restoring it, or by leaving the thread in a state that later tests must not
inherit. Running such a test on a dedicated thread, which is discarded afterwards, protects the worker threads that
NUnit reuses for other tests.

If you only need a particular apartment state, use the [`Apartment`](xref:attribute-apartment) attribute instead. It
creates a new thread only when the current thread does not already have the requested state.

## Notes

1. This attribute **always** creates a new thread, regardless of the current thread's apartment state.
2. To create a thread **only** when the current apartment state is not appropriate, use the `[Apartment]` attribute instead.
3. When used without an `ApartmentState` argument, the thread uses the default apartment state (MTA).
4. This attribute is useful for tests that modify thread-local state or require isolation from other tests.
5. Use on an assembly is rarely useful, since each test assembly already runs on its own thread.

## See Also

* [Apartment Attribute](xref:attribute-apartment)
* [SingleThreaded Attribute](xref:attribute-singlethreaded)
