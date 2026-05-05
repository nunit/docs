---
uid: apartment-attribute
---

# Apartment

`ApartmentAttribute` is used to specify that tests should run in a particular COM [apartment](https://learn.microsoft.com/en-us/windows/win32/com/processes--threads--and-apartments) state, either STA (Single-Threaded Apartment) or MTA (Multi-Threaded Apartment).

This is primarily needed for tests that interact with COM objects, Windows Forms controls, or WPF components that require a specific apartment state.

## Constructor

```csharp
ApartmentAttribute(ApartmentState apartmentState)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `apartmentState` | `ApartmentState` | The apartment state for the test. Must be `STA` or `MTA` (not `Unknown`). |

## ApartmentState Values

| Value | Description |
|-------|-------------|
| `ApartmentState.STA` | Single-Threaded Apartment. Required for most UI components (WinForms, WPF, COM controls). |
| `ApartmentState.MTA` | Multi-Threaded Apartment. The default for NUnit tests. |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ✅ |

When applied at multiple levels, the most specific level takes precedence.

## Examples

### Assembly Level

```csharp
// All tests in this assembly will use the STA by default
[assembly: Apartment(ApartmentState.STA)]
```

### Test Fixture Level

[!code-csharp[ApartmentFixture](~/snippets/Snippets.NUnit/Attributes/ApartmentAttributeExamples.cs#ApartmentFixture)]

### Test Method Level

[!code-csharp[ApartmentMethod](~/snippets/Snippets.NUnit/Attributes/ApartmentAttributeExamples.cs#ApartmentMethod)]

## Notes

1. When this attribute is not specified, tests run in the **MTA** by default.
2. When running tests in parallel, tests are scheduled to execute on a thread with the specified apartment state.
3. When parallel execution is disabled, a new thread may be created if the current thread doesn't have the correct apartment state.
4. This attribute replaces the obsolete `RequiresMTA` and `RequiresSTA` attributes.
5. The `ApartmentState.Unknown` value is not allowed and will cause an error.

## See Also

* [RequiresThread Attribute](requiresthread.md)
* [SingleThreaded Attribute](singlethreaded.md)
* [Parallelizable Attribute](parallelizable.md)
