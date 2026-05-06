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

| Parameter | Type | Description |
|-----------|------|-------------|
| `apartment` | `ApartmentState` | The apartment state for the thread. Must be `STA` or `MTA` (not `Unknown`). |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ✅ |

## Examples

### Fixture Level

[!code-csharp[RequiresThreadFixture](~/snippets/Snippets.NUnit/Attributes/RequiresThreadAttributeExamples.cs#RequiresThreadFixture)]

### Method Level with Apartment State

[!code-csharp[RequiresThreadMethod](~/snippets/Snippets.NUnit/Attributes/RequiresThreadAttributeExamples.cs#RequiresThreadMethod)]

### Assembly Level

```csharp
// All tests in this assembly will run on separate threads
[assembly: RequiresThread]
```

## Notes

1. This attribute **always** creates a new thread, regardless of the current thread's apartment state.
2. To create a thread **only** when the current apartment state is not appropriate, use the `[Apartment]` attribute instead.
3. When used without an `ApartmentState` argument, the thread uses the default apartment state (MTA).
4. This attribute is useful for tests that modify thread-local state or require isolation from other tests.

## See Also

* [Apartment Attribute](xref:attribute-apartment)
* [SingleThreaded Attribute](xref:attribute-singlethreaded)
