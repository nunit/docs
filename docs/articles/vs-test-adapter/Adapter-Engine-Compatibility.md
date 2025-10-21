# Compatibility of the Test Adapter with the Test Engine

The `NUnit3TestAdapter` has an embedded `NUnit.Engine` package. This means that you don't need to install the engine
separately, and you don't need to add a reference to the engine in your test project.

You should **never** add an extra reference to the `NUnit.Engine` when using the adapter in a project, as that may cause
the adapter to malfunction.

[@CharliePoole](https://github.com/charliepoole) has written a [blog
post](http://charliepoole.com/technical/nunit-engine-version-conflicts-in-visual-studio.html) about the compatibility of
the adapter with the engine, explaining how it works and how you should work with both the console, engine and adapter.

The table below shows the embedded engine versions for the different adapter versions, extended from Charlie's blog
post.

| Adapter version | Embedded engine version |
| --------------- | ----------------------- |
| 6.0.0           | 3.20.2                  |
| 5.2.0           | 3.18.1                  |
| 5.1.0           | 3.18.1                  |
| 5.0.0           | 3.18.1                  |
| 4.6.0           | 3.18.1                  |
| 4.5.0           | 3.15.4                  |
| 4.4.2           | 3.15.3-dev-build        |
| 4.4.0           | 3.16.3                  |
| 4.3.2           | 3.15.5                  |
| 4.3.1           | 3.15.2                  |
| 4.2.1           | 3.13.2                  |
| 4.2             | 3.13                    |
| 4.0-4.1         | 3.12                    |
| 3.17            | 3.11.1                  |
| 3.14-3.16.1     | 3.10                    |
| 3.8-3.13        | 3.10                    |
| 3.7             | 3.6                     |
| 3.5-3.6.1       | 3.5                     |
| 3.4             | 3.4.1                   |
| 3.2             | 3.2.1                   |
| 3.0             | 3.0.1                   |

## Using the console

If, for some unknown reason, you really badly want to use the NUnit.Console, and you really want to add it as a package
reference instead of just installing it globally, you should use the exact same version as listed for the engine in the
table above.

Note that most of what the console can do, can be done using the `dotnet test` command with the appropriate runsettings
added, see [Tips&Tricks](https://docs.nunit.org/articles/vs-test-adapter/Tips-And-Tricks.html).

> [!WARNING]
> If you try to add another engine version package, it may seem that the adapter and test are still working.  That is just
> by luck, and it does so because the interfaces between the version you have added are the same as the embedded version.
> But if you try to use a feature that is not in the embedded version, it will fail.
>
> Most likely you will see messages about "no tests found", or it may simply crash during test.

<!-- markdownlint-disable MD028 -->

> [!WARNING]
> Version 4.4.1 use an engine version that is not released yet.  This is because the engine has a bug that prevents it
> from working with the adapter.  The bug is fixed in the engine, but the fix is not yet released.  The adapter will be
> updated to use the released engine version as soon as it is released. You may try to use 3.15.2, but we can currently
> not confirm that it works.
