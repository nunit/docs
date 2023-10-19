# BinarySerializable Constraint

`BinarySerializableConstraint` tests whether an object is serializable in binary format.

## Constructor

```csharp
BinarySerializableConstraint()
```

## Syntax

```csharp
Is.BinarySerializable
```

## Examples of Use

```csharp
Assert.That(someObject, Is.BinarySerializable));
```

## See also

* [XmlSerializableConstraint](XmlSerializableConstraint.md)

## Note
Binary Serialization is no longer supported in .NET 8 due to security concerns, from Nunit4 this constraint is being removed.
https://learn.microsoft.com/en-us/dotnet/core/compatibility/serialization/8.0/binaryformatter-disabled
https://learn.microsoft.com/en-au/dotnet/standard/serialization/binaryformatter-security-guide