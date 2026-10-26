# IApplyToContext Interface

NUnit tests run within a context, known as the `TestExecutionContext`. The context for a test case is nested within the
context for its containing suite and so on, up to the assembly level. Attributes that implement `IApplyToContext` are
called immediately after the context is created and before the test is run in order to make changes to the context. Once
the test execution has completed, the context is discarded so that - effectively - any changes are reverted to their
original values.

The `IApplyToContext` interface is defined as follows:

```csharp
public interface IApplyToContext
{
    void ApplyToContext(TestExecutionContext context);
}
```

An example of the use of the context may be helpful. One item in the `TestExecutionContext` is the default timeout value
for test cases. When any test is marked with `[Timeout(nnn)]` the context value is replaced by the supplied argument.
The new timeout applies for any test case it appears on and any test case that is contained in a suite that it appears
on. When the test or suite completes, the new value is discarded and the value contained in the original context is once
against used.

Custom attributes that implement `IApplyToContext` should modify the TestExecutionContext in accordance with the
arguments supplied to them. They are not called after the test is run and have no cleanup to perform.

## Where the Attribute May Be Placed

NUnit looks for `IApplyToContext` attributes at every level of the test tree. An attribute placed on a **test method**
changes the context for that test case only. An attribute placed on a **fixture** changes the context for the fixture's
one-time setup and teardown and for every test case in it. An attribute placed on the **assembly** changes the context
for the whole test run. In each case the changes are reverted when the test or suite completes.

The levels at which a particular attribute may be used are controlled by its own `AttributeUsage`. For example,
`ParallelizableAttribute` may be used on assemblies, classes and methods, while `SingleThreadedAttribute` may be used
only on classes. If you write a custom `IApplyToContext` attribute, declare the `AttributeUsage` to match the levels at
which it makes sense:

```csharp
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public class MyContextAttribute : NUnitAttribute, IApplyToContext
{
    public void ApplyToContext(TestExecutionContext context)
    {
        // Modify the context here
    }
}
```

This differs from [`ICommandWrapper`](ICommandWrapper-Interface.md) attributes, which only have an effect when placed on
a test method.

The NUnit attributes that implement `IApplyToContext` are as follows:

* [`DefaultFloatingPointToleranceAttribute`](xref:attribute-defaultfloatingpointtolerance)
* [`ParallelizableAttribute`](xref:attribute-parallelizable)
* [`SetCultureAttribute`](xref:attribute-setculture)
* [`SetUICultureAttribute`](xref:attribute-setuiculture)
* [`SingleThreadedAttribute`](xref:attribute-singlethreaded)
* [`TimeoutAttribute`](xref:attribute-timeout)
