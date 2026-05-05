---
uid: platformattribute
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

A list of supported platform identifiers can also be obtained from the constant string `PlatformHelper.OSPlatforms` of
the NUnit assembly you use. Note that this is for informational purposes only, because the `PlatformHelper` is
considered an internal type and shall not be used in production.

### Architecture

* 32-Bit
* 32-Bit-Process
* 32-Bit-OS (.NET 4.0 and higher only)
* 64-Bit
* 64-Bit-Process
* 64-Bit-OS (.NET 4.0 and higher only)

### Runtime

* Net
* Net-1.0
* Net-1.1
* Net-2.0
* Net-3.0 (1)
* Net-3.5 (2)
* Net-4.0
* Net-4.5 (3)
* NetCF
* SSCLI
* Rotor
* Mono
* Mono-1.0
* Mono-2.0
* Mono-3.0 (4)
* Mono-3.5 (5)
* Mono-4.0

## Notes

1. Includes Net-2.0
2. Includes Net-2.0 and Net-3.0
3. Includes Net-4.0
4. Includes Mono-2.0
5. Includes Mono-2.0 and Mono-3.0

## `[SupportedOSPlatformAttribute]` and `[UnsupportedOSPlatformAttribute]` support

The [`[SupportedOSPlatform]` and `[UnsupportedOSPlatform]`](https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1416) attributes are also supported,
however they are only supported on a subset of dotnet versions compared to `[Platform]`. See the docs from Microsoft for more information about `[SupportedOSPlatform]` and `[UnsupportedOSPlatform]`.
