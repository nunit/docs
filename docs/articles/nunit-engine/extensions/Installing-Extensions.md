---
uid: installingextensions
---

# Installing Engine Extensions

Extensions are located by the engine by use of an `.addins` file.

For certain package managers, default `.addins` have been created such that when both engine and extensions are installed from the same package manager, all extensions are installed automatically. Currently, this includes NuGet and Chocolatey.

In other cases, the user may need to create a new `.addins` file, or edit an existing one. Ths behaviour of the `.addins` file is covered below.

## The .addins file

`.addins` files are used to locate engine extensions. Either a single `.addins` file can be used to list all extensions and directories to be searched, or multiple files. `.addins` files can also be chained together -- allowing multiple levels of redirection.

Each line of the `.addins` file contains the path of an extension assembly or a directory containing assemblies. Wildcards may be used for assembly entries and relative paths are interpreted based on the location of the `.addins` file. 

The following is an example of a possible `.addins` file, with comments indicating what each line does:

```none
# This line is a comment and is ignored. The next (blank) line is ignored as well.

*.dll                   # include all dlls in the same directory
addins/*.dll            # include all dlls in the addins directory too
special/myassembly.dll  # include a specific dll in a special directory
/some/other/directory/  # process another directory, which may contain its own addins file
                        # note that an absolute path is allowed, but is probably not a good idea
                        # in most cases
```

Any assemblies specified in a `.addins` file will be scanned fully, looking for addins and extensions. Any directories specified will be browsed, first looking for any `.addins` files. If one or more files are found, the content of the files will direct all further browsing. If no such file is found, then all `.dll` files in the directory will be scanned, just as if a `.addins` file contained "*.dll."

Note that if a specific assembly is listed in the `.addins` file which is found not to be a valid extension, an exception will be thrown by the engine. This exception is suppressed in the cases of wildcard paths, where it is considered valid to find no extensions under the path.