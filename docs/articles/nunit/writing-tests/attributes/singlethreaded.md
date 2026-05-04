# SingleThreaded

`SingleThreadedAttribute` is used on a test fixture to ensure that `OneTimeSetUp`, `OneTimeTearDown`, and all child tests run on the same thread. This forces all child tests to be run sequentially on the current thread.

## Usage

This is a parameterless attribute that can only be applied to test fixture classes.

```csharp
[SingleThreaded]
```

## Example

[!code-csharp[SingleThreadedExample](~/snippets/Snippets.NUnit/Attributes/SingleThreadedAttributeExamples.cs#SingleThreadedExample)]

## Notes

1. When this attribute is applied, any `ParallelScope` setting on the fixture or its child tests is ignored.
2. This attribute is inherited by derived test fixture classes.
3. Use this attribute when your tests share resources that have thread affinity, such as database connections, COM objects, or UI components.
4. This attribute only affects the fixture it is applied to. Other fixtures in the same assembly can still run in parallel with this fixture (unless assembly-level parallelization is disabled).

## See Also

* [Parallelizable Attribute](parallelizable.md)
* [NonParallelizable Attribute](nonparallelizable.md)
* [RequiresThread Attribute](requiresthread.md)
* [Apartment Attribute](apartment.md)
