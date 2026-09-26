---
uid: classic-directory-assert
---

# DirectoryAssert

The DirectoryAssert class provides methods for comparing two directories
or verifying the existence of a directory. Directories may be provided
as DirectoryInfos or as strings giving the path to each directory.

`DirectoryAssert` is in the `NUnit.Framework` namespace, so `using NUnit.Framework;` is enough. It ships in
`nunit.framework.legacy.dll`, which is part of the NUnit package.

> [!NOTE]
> In NUnit 4, `DirectoryAssert` was in the `NUnit.Framework.Legacy` namespace and needed `using NUnit.Framework.Legacy;`.

```csharp
DirectoryAssert.AreEqual(DirectoryInfo expected, DirectoryInfo actual);
DirectoryAssert.AreEqual(DirectoryInfo expected, DirectoryInfo actual,
    string message, params object[] args);

DirectoryAssert.AreNotEqual(DirectoryInfo expected, DirectoryInfo actual);
DirectoryAssert.AreNotEqual(DirectoryInfo expected, DirectoryInfo actual,
    string message, params object[] args);

DirectoryAssert.Exists(DirectoryInfo actual);
DirectoryAssert.Exists(DirectoryInfo actual,
    string message, params object[] args);

DirectoryAssert.Exists(string actual);
DirectoryAssert.Exists(string actual,
    string message, params object[] args);

DirectoryAssert.DoesNotExist(DirectoryInfo actual);
DirectoryAssert.DoesNotExist(DirectoryInfo actual,
    string message, params object[] args);

DirectoryAssert.DoesNotExist(string actual);
DirectoryAssert.DoesNotExist(string actual,
    string message, params object[] args);
```

## See Also

* [File and Directory Constraints](xref:constraints#file-and-directory-constraints)
