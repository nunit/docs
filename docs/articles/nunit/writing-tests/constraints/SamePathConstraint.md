---
uid: constraint-samepath
---

# SamePath Constraint

`SamePathConstraint` tests that two paths are equivalent.

## Constructor

```csharp
SamePathConstraint(string expectedPath)
```

## Syntax

```csharp
Is.SamePath(string expectedPath)
```

## Modifiers

```csharp
...IgnoreCase
...RespectCase
```

## Examples of Use

[!code-csharp[SamePathConstraintExamples](~/snippets/Snippets.NUnit/Constraints/PathConstraintSnippets.cs#SamePathConstraintExamples)]

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

* [SubPathConstraint](SubPathConstraint.md)
* [SamePathOrUnderConstraint](SamePathOrUnderConstraint.md)
