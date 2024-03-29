# WhiteSpace Constraint

The `WhiteSpaceConstraint` tests if a string contains only white-space.

The constraint is the equivalent of
[String.IsNullOrWhiteSpace](https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorwhitespace?view=net-8.0)

White-space characters are defined by the Unicode standard as interpreted by
[Char.IsWhiteSpace](https://learn.microsoft.com/en-us/dotnet/api/system.char.iswhitespace?view=net-8.0) method.

## Constructor

```csharp
WhiteSpaceConstraint()
```

## Syntax

```csharp
Is.WhiteSpace  // From version 4.2
```

## Examples of Use

```csharp
Assert.That(" ", Is.WhiteSpace);
Assert.That("A String", Is.Not.WhiteSpace);
```
