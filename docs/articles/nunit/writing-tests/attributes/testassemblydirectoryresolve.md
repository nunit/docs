---
uid: testassemblydirectoryresolveattribute
---

# TestAssemblyDirectoryResolve

The `TestAssemblyDirectoryResolveAttribute` marks a test assembly as needing a special assembly resolution hook. When
applied, NUnit will explicitly search the test assembly's directory for dependent assemblies during resolution.

This attribute is designed to work around a specific conflict between mixed-mode assembly initialization and tests
running in their own AppDomain.

> [!NOTE]
> This attribute has been available since NUnit 3.2 and addresses edge cases in assembly loading scenarios.

## When to Use

This attribute is typically needed when:

* Your test assembly references mixed-mode assemblies (assemblies containing both managed and native code)
* Tests run in a separate AppDomain from the main process
* Assembly resolution fails because dependent assemblies cannot be found

## Usage

Apply the attribute at the assembly level in your test project:

```csharp
[assembly: TestAssemblyDirectoryResolve]
```

This is typically placed in a file like `AssemblyInfo.cs` or a dedicated assembly attributes file.

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ❌ | ❌ | ✅ |

## Example

[!code-csharp[VerifyAttributeExists](~/snippets/Snippets.NUnit/Attributes/TestAssemblyDirectoryResolveAttributeExamples.cs#VerifyAttributeExists)]

## How It Works

When this attribute is present on a test assembly:

1. NUnit registers an assembly resolution handler before running tests
2. When the runtime cannot find an assembly, the handler searches the test assembly's directory
3. If the assembly is found, it is loaded from that location
4. This resolves issues where the default probing paths don't include the test assembly's directory

## Common Scenarios

### Mixed-Mode Assembly Dependencies

```csharp
// AssemblyInfo.cs
using NUnit.Framework;

// Required because we reference a mixed-mode native interop library
[assembly: TestAssemblyDirectoryResolve]
```

### Plugin or Extension Testing

When testing plugin systems where assemblies are loaded from non-standard locations:

```csharp
[assembly: TestAssemblyDirectoryResolve]

// Tests can now properly resolve plugin dependencies
[TestFixture]
public class PluginTests
{
    [Test]
    public void PluginLoadsSuccessfully()
    {
        var plugin = LoadPlugin("MyPlugin.dll");
        Assert.That(plugin, Is.Not.Null);
    }
}
```

## Verification

[!code-csharp[VerifyAttributeExists](~/snippets/Snippets.NUnit/Attributes/TestAssemblyDirectoryResolveAttributeExamples.cs#VerifyAttributeExists)]

## Limitations

* This attribute only affects assembly resolution within the test assembly's AppDomain
* It does not affect assemblies loaded in child AppDomains or separate processes
* The attribute has no effect if the test assembly directory is already in the probing path

## See Also

* [NonTestAssembly Attribute](nontestassembly.md)
* [.NET Assembly Loading](https://learn.microsoft.com/en-us/dotnet/framework/deployment/how-the-runtime-locates-assemblies)
