# Packaging the V3/V4 Adapter

## Introduction

There are two purposes for building the adapter, one is for creating the packages for a  release - which is what this
page is about, the other is for creating whatever you need for debugging or testing purposes.  For the latter, see [How
to build and debug the adapter]

The procedure described here is for those people who need to release a new version of the adapter.

## Preparing the source code

### Update to the latest version of NUnit

This may not be necessary for all releases. However, if the NUnit version used by the adapter is being updated, it is
important to do it correctly.

* The NUnit3TestAdapter, NUnit3TestAdapterInstall and NUnit3TestAdapterTests projects should all reference the same
  versions of the NUnit Engine package, normally the most recent.

* The NUnit3TestAdapterTests and NUnitTestDemo projects should reference the same version of the NUnit framework
  package, also normally the most recent. Note that this is currently the same version as the engine package, but this
  may not continue to be the case if the frequency of release of the two packages differs.

### Assembly References

At this time, after upgrading the NUnit engine package, you have to manually adjust the references, removing several
that are added automatically by the package and adding an Alias. We will try to eliminate this manual step in the
future.

For each of the **NUnit3TestAdapter**, **NUnit3TestAdapterTests** and **NUnit3TestAdapterInstall** projects, remove
references to nunit-agent and nunit-agent-x86, leaving only the four Mono.Cecil references, nunit.engine and
nunit.engine.api.

For the **NUnit3TestAdapter** project, modify the properties for nunit-engine by entering "ENG" for Aliases.

### Versioning

The version numbers follow the basic principles of [semantic versioning]. (The fourth number is used for debug versions
under development, and will always be 0 for release versions.)

The version numbers have to be edited in the following files, and should match:

| File | Change |
| ---- | ------ |
| `AssemblyInfo.cs`, found in the NUnitTestAdapter project | change both file and assembly version number |
| `appveyor.yml`, found under the Solution Items folder. | change the version number, but only use the three first digits.|
| `build.cake`, found under the Solution Items folder. | change the version number, but only use the three first digits.|

## Build

Use the build command to build and test a release version.

   ```cmd
   build -t Test
   build -t Acceptance
   ```

## Packaging

Use the build command to create packages

```cmd
build -t Package
```

Run this from the solution root folder

The resulting files can be found in the "package" folder:

* **NUnit3TestAdapter-[VERSION].zip**  This is a zipped package for use with TFS Server Builds when you don't use the
  NuGet package in your solution. See  [this blog] for more information.

* **NUnit3TestAdapter.[VERSION].nupkg** This is the NuGet package, which is uploaded to [NuGet for the adapter]

### Testing the Packages

Test the NuGet package on the latest Visual Studio, but if you have earlier versions it is recommended to test on those
too, down to VS 2012.

### Publishing the Release

1. Create a release on GitHub. Few people use this directly, but it is the benchmark release and provides an archive of
   all past releases, so we do this first. Github will automatically create zip and tar files containing the source. In
   addition, upload all three packages created above as a part of the release.

2. Upload the NuGet package to nuget.org. You use your own account for this but you must have been pre-authorized in
   order for it to work. If you are not authorized, ask a committer with access to do it for you.

3. Update the documentation pages in the site as needed. Be sure to update the Release Notes page. In order to perform
   the update quickly after publishing the packages, you may want to clone the `nunit/docs` repository and prepare the
   pull request in advance.

4. Publicize the release, first announcing it on the nunit-developer and nunit-discuss lists and then more widely as
   appropriate. [We should develop a list of places.]

> [!NOTE]
> Publishing the release requires access to various online accounts, which are mentioned above. For obvious
> reasons, the passwords are not provided. Contact Charlie or Terje if you need this access.

## Prerequisites

1. **Visual Studio** Visual Studio 2022 is required in order to build and develop the adapter.
2. **.Net SDKs** You need at least the .Net Core 3.1, .net 5, 6 and 7 SDKs installed. Not all are required for the
   build, but they are required for the tests. You also need .Net Framework 4.6.2 installed.

## Links

[NuGet for the adapter](https://www.nuget.org/packages/NUnitTestAdapter)

## Other GitHub Repositories That Need to be Updated

1. **.Net test templates** You should raise PR in the [dotnet test template
repo](https://github.com/dotnet/test-templates) to update the test templates to use the latest version of the adapter.
See [this PR](https://github.com/dotnet/test-templates/pull/273) for an example.  Right now (March 2023), Microsoft
doesn't accept more PRs to the repo.
