# Known Problems

1. Using both the VSIX adapter and nuget adapters at the same time can lead to discovery issues; see
   [nunit3-vs-adapter/issues #769](https://github.com/nunit/nunit3-vs-adapter/issues/769).  The resolution is to
   uninstall the VSIX adapter, and only use the nuget adapters.  The VSIX adapters are being deprecated in later VS
   versions.

2. Support for Explicit keyword

    1  Adapter versions in the 4.XX series support the `explicit` keyword in all Visual Studio versions.

    2 Adapter versions in the 3.XX series:  From version 16.2 (Visual Studio 2019) the `Explicit` keyword is no longer
    explicitly supported by Visual Studio.  If you want to use it, it does exist as a Category, so you can use it as a
    category filter.

3. There is no test status in Visual Studio corresponding to NUnit's Inconclusive result, so tests with this result are
   reported as Not Run. Click on the individual test to see the result.

4. Theories are reported as individual cases, rather as a single unit.

5. In NUnit, tests have names, which are not necessarily unique. Visual Studio wants the names to be unique. So if two
   tests have the same name, VS displays a warning message in the output window. The message may be ignored. Two
   separate results will be shown under the single test in the explorer pane.

6. Startup performance is substantially improved but is still slower than using NUnit directly.

7. Applies to pre-VS2017: When using a VSIX adapter and the NuGet adapter, the VSIX adapter will be used regardless of
   the NuGet adapter version.

    1. Workaround: Make sure you have upgraded VSIX adapter to latest version, or uninstalled it if you have the NuGet
       adapter in a solution. The adapter will display its version number in the Output window under Tests.

    2. Avoid using the VSIX adapter for VS2017 and upwards.  It is being deprecated, but is still supported optionally
       in VS2019.

8. Visual Studio 2017 Live Unit Testing require NUnit3.  The NUnit2 adapter doesn't support Live Unit Testing.

9. `Exception: Could not load file or assembly 'nunit.engine'` - Is caused by an incomplete copy of the adapter in the
   Visual Studio cache. Close Visual Studio and delete
   `C:\Users\username\AppData\Local\Temp\VisualStudioTestExplorerExtensions\NUnit3TestAdapter.{{version}}`

## Issues with other tools

* Versions of ReSharper earlier than the 8.2 version has an issue with the NuGet adapter, which will prevent NUnit tests
  from running. Make sure you have updated Reshaper to at least version 8.2.

* ReSharper version 2018.1 are not able to work with adapter versions >= 3.12.  This is fixed in 2018.3.  See
  [Issue638](https://github.com/nunit/nunit3-vs-adapter/issues/638) for details.
