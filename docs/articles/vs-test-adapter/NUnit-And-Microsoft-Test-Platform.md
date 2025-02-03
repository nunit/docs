# NUnit and Microsoft Test Platform

## Overview

Microsoft Test Platform (MTP) is the new platform for testing from Microsoft. The Test Projects can be run as
executables, like we do with [NUnitLite](../nunit/running-tests/NUnitLite-Runner.md). There is no longer a test runner;
the executable _is_ the test runner.

It will take time to develop feature parity with NUnit's current system, and there are many historical factors to
consider. But, the NUnit team recognizes that in the meantime, there needs to be a bridge between these two. In NUnit,
the NUnit3TestAdapter contains what is necessary to run the MTP using the same old test runners.

This means we have two modes of MTP operation: either use the new platform but not as an executable, or use it
as an executable too.

## Changing a Project to Use MTP

To change a current test project to use MTP, you need to use version 5.0 or greater of the NUnit3TestAdapter.

Note that this version can run both MTP and non-MTP, and you can easily switch between them by setting two project
properties.

In a property group (use the top level one), add the following two properties

```xml
   <EnableNUnitRunner>true</EnableNUnitRunner>
   <OutputType>Exe</OutputType>  
```

The first one enables the MTP.  The second enables it to also run as an executable, but it doesn't prevent you from
using it in Test Explorer or through `dotnet test`.

## Information on the Microsoft Test Platform

* [Microsoft Test Platform](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-platform-intro?tabs=dotnetcli)
* [NUnit Samples](https://github.com/nunit/nunit3-vs-adapter.issues/tree/master/Issue1152)
* [Adapter issue for implementing MTP](https://github.com/nunit/nunit3-vs-adapter/issues/1152)

## Known issues

In the current (v5) version of the NUnit3TestAdapter, running single tests don't work.  It will always run all tests.
See [Adapter Issue 1232](https://github.com/nunit/nunit3-vs-adapter/issues/1232).

This applies to both Test Explorer and `dotnet test`.

As a workaround for the latter, you can filter tests using MTP-specific commands
like `dotnet test -- --filter Name=Test1`.
