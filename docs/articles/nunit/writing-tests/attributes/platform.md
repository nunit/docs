---
uid: attribute-platform
---

# Platform

`PlatformAttribute` specifies platforms on which a test, fixture, or assembly should run. Platform names are
case-insensitive. You can require platforms in any of these ways:

* Pass a comma-separated list to the constructor (treated as **included** platforms).
* Set the `Include` property to a comma-separated list.
* Set the `Exclude` property to a comma-separated list.

You can combine `Include` and `Exclude` where that makes sense for your scenario.

If the current environment does **not** satisfy the attribute, NUnit marks the test as **skipped** (`RunState.Skipped`)
with a skip reason—it does **not** mark it as ignored, and it does not fail the run. Skipped tests are omitted from the
normal pass/fail counts in the same way as other skipped work. How your test runner displays skipped tests (for example
in a tree view or status bar) depends on that runner.

Invalid or unrecognized platform names can make a test **not runnable** instead of skipped; see your runner output for
the reason.

## Constructors

```csharp
PlatformAttribute()
PlatformAttribute(string platforms)
PlatformAttribute(string[] includes)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `platforms` | `string` | Comma-delimited platform list to include. |
| `includes` | `string[]` | Platform identifiers to include. |

## Properties

| Property | Type | Description | Default |
|----------|------|-------------|---------|
| `Include` | `string` | Comma-delimited list of included platforms. | `null` |
| `Exclude` | `string` | Comma-delimited list of excluded platforms. | `null` |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ✅ |

## Examples

[!code-csharp[PlatformAttributeExamples](~/snippets/Snippets.NUnit/Attributes/PlatformAttributeExamples.cs#PlatformAttributeExamples)]

## Platform Specifiers

The following values are recognized as platform specifiers. They may be expressed in upper, lower or mixed case.

### Operating System

* Win
* Win32
* Win32S
* Win32Windows
* Win32NT
* WinCE
* Win95
* Win98
* WinMe
* NT3
* NT4
* NT5
* NT6
* Win2K
* WinXP
* Win2003Server
* Vista
* Win2008Server
* Win2008ServerR2
* Windows7
* Win2012Server
* Windows8
* Windows8.1
* Windows10
* Windows11
* WindowsServer10
* Unix
* Linux
* MacOsX
* XBox

A list of supported identifiers can also be referenced from the named constants in the `PlatformNames` class. _(NUnit 4.6+)_.

### Architecture

* 32-Bit
* 32-Bit-Process
* 32-Bit-OS (.NET 4.0 and higher only)
* 64-Bit
* 64-Bit-Process
* 64-Bit-OS (.NET 4.0 and higher only)

### Runtime

* Net
* NETCore
* DotNET
* DotNETCore
* NETFramework _(NUnit 5+)_
* DotNETFramework _(NUnit 5+)_

> [!NOTE]
> The meaning of `Net` and `DotNET` has changed in NUnit 5. These identifiers previously targeted .NET Framework and now
> target modern .NET (.NET 5+, .NET Core). For more information please see the **Breaking Changes** section below.

#### Other Runtimes

* SSCLI
* Rotor
* Mono
* MonoTouch

#### Runtime Version Specifiers

> [!NOTE]
> Version specifiers (for example, `Net-5.0`) are **not** supported for modern .NET identifiers.

A runtime version number can be appended using a dash, for example `NETFramework-4.0`, `NETFramework-4.5`, or `Mono-3.0`. These relate to the underlying Common Language Runtime (CLR) version and are inclusive of lower runtime versions which target the same CLR.

For example:

`NETFramework-4.5` will include `NETFramework-4.0` as both run on version 4 of the CLR. Similarly, `Mono-3.5` will include `Mono-2.0` and `Mono-3.0` as all run on version 2 of the MonoCLR.

## Breaking Changes in NUnit 5

> [!IMPORTANT]
> **Breaking change in NUnit 5:** The meaning of `NET` and `DotNET` has changed to better align with
> Microsoft's current .NET terminology. These identifiers previously targeted .NET Framework and now
> target modern .NET (.NET 5+, .NET Core).

| Identifier | NUnit 4 | NUnit 5 |
|------------|---------|---------|
| `NET` | .NET Framework | Modern .NET |
| `NETFramework` | Not supported | .NET Framework |
| `NETCore` | Modern .NET | Modern .NET _(unchanged)_ |
| `DotNET` | .NET Framework | Modern .NET |
| `DotNETCore` | Modern .NET | Modern .NET _(unchanged)_ |
| `DotNETFramework` | Not supported | .NET Framework |

If you were using `[Platform("NET")]` or `[Platform("DotNET")]` to target .NET Framework,
update those usages to `[Platform("NETFramework")]` or `[Platform("DotNETFramework")]`.

Additionally, version-specific .NET targeting using `Net-X.X` (for example, `Net-4.0`, `Net-4.5`)
is no longer supported. Use `NETFramework-X.X` instead (for example, `NETFramework-4.0`,
`NETFramework-4.5`).

## `[SupportedOSPlatformAttribute]` and `[UnsupportedOSPlatformAttribute]` support

The [`[SupportedOSPlatform]` and `[UnsupportedOSPlatform]`](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1416) attributes are also supported,
however they are only supported on a subset of dotnet versions compared to `[Platform]`. See the docs from Microsoft for more information about `[SupportedOSPlatform]` and `[UnsupportedOSPlatform]`.
