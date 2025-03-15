# AllItems Constraint

`AllItemsConstraint` applies a constraint to each item in an `IEnumerable`, succeeding only if all of them succeed. An
exception is thrown if the actual value passed does not implement `IEnumerable`.

## Constructor

```csharp
AllItemsConstraint(Constraint itemConstraint)
```

## Syntax

```csharp
Is.All...
Has.All...
```

## Examples of Use

```csharp
int[] iarray = new int[] { 1, 2, 3 };
string[] sarray = new string[] { "a", "b", "c" };
Assert.That(iarray, Is.All.Not.Null);
Assert.That(sarray, Is.All.InstanceOf<string>());
Assert.That(iarray, Is.All.GreaterThan(0));
Assert.That(iarray, Has.All.GreaterThan(0));
```
