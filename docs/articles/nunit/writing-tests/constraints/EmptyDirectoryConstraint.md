---
uid: constraint-emptydirectory
---

# EmptyDirectory Constraint

`EmptyDirectoryConstraint` tests that a directory contains no files or subdirectories.

## Usage

```csharp
Is.Empty
Is.Not.Empty
```

## Examples

[!code-csharp[EmptyDirectoryConstraintExamples](~/snippets/Snippets.NUnit/Constraints/SpecialConstraintSnippets.cs#EmptyDirectoryConstraintExamples)]

## Notes

1. `Is.Empty` is a polymorphic constraint that works on strings, collections, and directories.
2. When applied to a `DirectoryInfo`, it checks for both files and subdirectories.
3. The directory must exist - passing a non-existent directory throws an exception.

## See Also

* [Empty Constraint](EmptyConstraint.md) - Polymorphic empty constraint
* [FileOrDirectoryExists Constraint](FileOrDirectoryExistsConstraint.md) - Test existence
