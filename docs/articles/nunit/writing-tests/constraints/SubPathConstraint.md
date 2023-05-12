# SubPath Constraint

`SubPathConstraint` tests that one path is under another path.

## Constructor

```csharp
SubPathConstraint(string expectedPath)
```

## Syntax

```csharp
Is.SubPathOf(string expectedPath)
```

## Modifiers

```csharp
...IgnoreCase
...RespectCase
```

## Examples of Use

```csharp
Assert.That("/folder1/./junk/../folder2", Is.SubPathOf("/folder1/"));
Assert.That("/folder1/junk/folder2", Is.Not.SubPathOf("/folder1/folder2"));

Assert.That(@"C:\folder1\folder2\Folder3", Is.SubPathOf(@"C:\Folder1\Folder2").IgnoreCase);
Assert.That("/folder1/folder2/folder3", Is.Not.SubPathOf("/Folder1/Folder2/Folder3").RespectCase);
```

## Notes

1. Path constraints perform tests on paths, without reference to any
actual files or directories. This allows testing paths that are
created by an application for reference or later use, without
any effect on the environment.

2. Path constraints are intended to work across multiple file systems,
and convert paths to a canonical form before comparing them.

3. It is usually not necessary to know the file system of the paths
in order to compare them. Where necessary, the programmer may
use the **IgnoreCase** and **RespectCase** modifiers to provide
behavior other than the system default.

## See also

* [SamePathConstraint](SamePathConstraint.md)
* [SamePathOrUnderConstraint](SamePathOrUnderConstraint.md)
