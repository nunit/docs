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

> [!WARNING]
> Binary Serialization is no longer supported in .NET 8 due to security concerns. From NUnit 4.x onward, this
> constraint is not available. More information can be found in these Microsoft Learn articles [on BinaryFormatter's
> removal](https://learn.microsoft.com/en-us/dotnet/core/compatibility/serialization/8.0/binaryformatter-disabled) and
> [on the BinaryFormatter security
> guide](https://learn.microsoft.com/en-au/dotnet/standard/serialization/binaryformatter-security-guide)
