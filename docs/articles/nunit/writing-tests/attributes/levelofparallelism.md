---
uid: levelofparallelismattribute
---

# LevelOfParallelism

`LevelOfParallelismAttribute` is an assembly-level attribute used to specify the maximum number of worker threads that may execute tests simultaneously. This controls how many tests can run in parallel.

## Constructor

```csharp
LevelOfParallelismAttribute(int level)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `level` | `int` | The maximum number of worker threads to be created by the framework for running tests. |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ❌ | ❌ | ✅ |

Typically placed in `AssemblyInfo.cs` or a global usings file.

## Default Value

If this attribute is not specified, NUnit uses `Environment.ProcessorCount` or 2, whichever is greater. For example, on an 8-core machine, the default is 8 worker threads.

## Example

The following code, placed in `AssemblyInfo.cs`, limits parallel execution to 3 worker threads:

```csharp
using NUnit.Framework;

[assembly: LevelOfParallelism(3)]
```

## Notes

1. This attribute controls the **maximum** number of parallel workers. The actual number may be lower depending on the tests and their parallelization settings.
2. Tests must be marked with `[Parallelizable]` to actually run in parallel. This attribute only sets the upper limit on worker threads.
3. Setting the level to 1 effectively disables parallelism (only one test runs at a time).
4. This value can be overridden using the `--workers` command-line option in the NUnit console runner.
5. Consider your test dependencies and shared resources when setting this value. Higher parallelism can cause issues with tests that share state.

## See Also

* [Parallelizable Attribute](xref:parallelizableattribute)
* [NonParallelizable Attribute](xref:nonparallelizableattribute)
* [Console Command Line](xref:consolecommandline)
