---
uid: nonparallelizableattribute
---

# NonParallelizable

`NonParallelizableAttribute` marks an assembly, fixture, or method so it is not run in parallel with anything else (`ParallelScope.None`). It inherits from `ParallelizableAttribute` and takes no constructor arguments.

## Usage

```csharp
[NonParallelizable]
```

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ✅ |

When used at assembly level, execution starts on the non-parallel queue; child suites or methods can still opt into parallelism with [Parallelizable](parallelizable.md).

When used on a fixture or method, that test queues on the non-parallel queue and does not overlap with concurrent parallel-eligible tests.

## Platform Support

Parallel execution is not supported by all builds of the NUnit Framework, although the attributes are recognized without
error in order to allow use in projects that build against multiple targets. Currently, only the .NET Standard 1.6 build
does not support parallelization.

## See Also

* [Parallelizable Attribute](parallelizable.md)
* [LevelOfParallelism Attribute](levelofparallelism.md)
