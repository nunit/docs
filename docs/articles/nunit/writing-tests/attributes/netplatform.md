---
uid: netplatformattribute
---

# NetPlatform

The `NetPlatformAttribute` is used to specify platforms for which a test or fixture should be run. It is a modern
replacement for the [Platform](platform.md) attribute, using platform names based on the .NET `TargetFramework`
conventions as documented in [CA1416: Validate platform
compatibility](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1416).

Platforms are specified using case-insensitive string values and may be either included or excluded from the run by use
of the `Include` or `Exclude` properties respectively. Multiple comma-separated values may be specified.

If a test or fixture with the `NetPlatformAttribute` does not satisfy the specified platform requirements, it is
skipped.

> [!NOTE]
> This attribute was introduced in NUnit 4.6 and provides better alignment with .NET's built-in platform checking
> mechanisms compared to the older `PlatformAttribute`.

## Constructors

```csharp
NetPlatformAttribute()
NetPlatformAttribute(string platforms)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `platforms` | `string` | Comma-delimited list of included platforms. |

## Properties

| Property | Type | Description | Default |
|----------|------|-------------|---------|
| `Include` | `string` | Comma-delimited platform list that should run. | `null` |
| `Exclude` | `string` | Comma-delimited platform list that should be skipped. | `null` |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ✅ |

## Test Fixture Syntax

[!code-csharp[NetPlatformFixture](~/snippets/Snippets.NUnit/Attributes/NetPlatformAttributeExamples.cs#NetPlatformFixture)]

## Test Syntax

[!code-csharp[NetPlatformBasic](~/snippets/Snippets.NUnit/Attributes/NetPlatformAttributeExamples.cs#NetPlatformBasic)]

## Excluding Platforms

[!code-csharp[NetPlatformExclude](~/snippets/Snippets.NUnit/Attributes/NetPlatformAttributeExamples.cs#NetPlatformExclude)]

## Platform Version Requirements

You can specify minimum version requirements for platforms:

[!code-csharp[NetPlatformVersion](~/snippets/Snippets.NUnit/Attributes/NetPlatformAttributeExamples.cs#NetPlatformVersion)]

## Multiple Platforms

[!code-csharp[NetPlatformMultiple](~/snippets/Snippets.NUnit/Attributes/NetPlatformAttributeExamples.cs#NetPlatformMultiple)]

## Platform Specifiers

The following platform names are supported, matching the .NET SDK's supported platform identifiers:

| Platform | Description |
| ---------- | ------------- |
| `windows` | Microsoft Windows |
| `linux` | Linux distributions |
| `macos` | Apple macOS |
| `android` | Android |
| `ios` | Apple iOS |
| `tvos` | Apple tvOS |
| `watchos` | Apple watchOS |
| `browser` | WebAssembly in browser |

### Version Specifiers

Platform names can include version numbers to specify minimum version requirements:

* `windows10.0` - Windows 10 or later
* `windows10.0.19041` - Windows 10 build 19041 or later
* `macos10.15` - macOS Catalina (10.15) or later
* `ios14.0` - iOS 14 or later

> [!NOTE]
> For Windows, public version numbers (like Windows 7, 8, 10, 11) are automatically mapped to their internal version
> numbers for compatibility checking.

## Comparison with PlatformAttribute

| Feature | NetPlatformAttribute | PlatformAttribute |
| --------- | --------------------- | ------------------- |
| Platform names | .NET SDK style (`windows`, `linux`, `macos`) | Legacy style (`Win`, `Unix`, `MacOsX`) |
| Version support | Full version specifiers (`windows10.0.19041`) | Limited version support |
| Runtime detection | Uses `OperatingSystem.IsOSPlatform()` | Uses custom detection logic |
| Analyzer support | Compatible with CA1416 | Not compatible |

## See Also

* [Platform Attribute](platform.md)
* [Culture Attribute](culture.md)
* [CA1416: Validate platform compatibility](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1416)
