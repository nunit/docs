---
uid: constraint-fileordirectoryexists
---

# FileOrDirectoryExists Constraint

`FileOrDirectoryExistsConstraint` tests that a file or directory exists at the specified path.

## Usage

```csharp
Does.Exist
Does.Not.Exist
```

## Modifiers

```csharp
.IgnoreDirectories   // Only check for file existence
.IgnoreFiles         // Only check for directory existence
```

## Examples

[!code-csharp[FileOrDirectoryExistsConstraintExamples](~/snippets/Snippets.NUnit/Constraints/SpecialConstraintSnippets.cs#FileOrDirectoryExistsConstraintExamples)]

## Notes

1. The constraint accepts string paths, `FileInfo`, or `DirectoryInfo` objects.
2. By default, the constraint passes if either a file or directory exists at the path.
3. Use `.IgnoreDirectories` to require a file specifically.
4. Use `.IgnoreFiles` to require a directory specifically.

## See Also

* [EmptyDirectory Constraint](EmptyDirectoryConstraint.md) - Test if directory is empty
* [SamePath Constraint](SamePathConstraint.md) - Compare paths
