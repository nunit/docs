---
uid: nontestassembly
---

# NonTestAssembly

`NonTestAssemblyAttribute` is used to mark an assembly that references NUnit but does not contain any tests. This is useful for third-party frameworks, extensions, or other software that depend on NUnit but should not be loaded as test assemblies.

## Usage

This is a parameterless attribute that can only be applied at the assembly level.

```csharp
[assembly: NonTestAssembly]
```

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ❌ | ❌ | ✅ |

Typically placed in `AssemblyInfo.cs` or a global usings file.

## Example

The following code, placed in `AssemblyInfo.cs`, marks the assembly as not containing tests:

```csharp
using NUnit.Framework;

[assembly: NonTestAssembly]
```

## Notes

1. Use this attribute when your assembly references `NUnit.Framework` but is not intended to be run as a test assembly (e.g., test utilities, custom assertions, or framework extensions).
2. When used with the console runner's `--skipnontestassemblies` option, assemblies marked with this attribute are skipped without generating an error.
3. Recognition of this attribute depends on the individual test runner. Not all runners may honor it.
4. This attribute is marked `[EditorBrowsable(EditorBrowsableState.Never)]` to reduce IntelliSense noise in typical test projects.

## See Also

* `--skipnontestassemblies` in [Console Command Line](xref:consolecommandline)
