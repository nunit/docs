# Packaging the Framework

This note describes how to create release packages for the NUnit Framework. Currently, all the builds and packaging must be done on a single Windows machine. This is likely to change in the future as we add more platforms.

## Software Prerequisites

Various software combinations and environments may be used to build NUnit components. The following software is what we have used and tested for building everything and creating the release packages. We'll add options to the list as we find them.

1. Visual Studio 2019 16.8 or newer with the NuGet Package manager.
2. .NET 5.0 SDK

## Preparing for Release

### Create a Release Branch

All work on releases should be done on a branch.

1. On master `git checkout master`, Fetch `git fetch -p` and pull latest `git pull`
2. Create a branch to prepare the release `git checkout -b release313`
3. Push the branch to GitHub `git push -u origin release313`
4. As you make the changes below, push the changes to GitHub and create a Pull Request targeting the `release` branch to allow other team members to review your changes.
5. The PR can be created in the web or using the GitHub CLI with `gh pr create -a rprouse -B release -t "Release 3.13"`

### Make Sure it Works

1. Close all instances of Visual Studio or other IDE to ensure that no changes are left unsaved.

2. Do a clean build and run all the tests on Windows. You may use the command below or three separate commands if preferred. If you encounter errors at any stage, you're not actually ready to release!

    ```sh
    .\build.ps1 --Target Clean
    .\build.ps1 --Target Test
    ```

3. Repeat the build on a Linux system, if available. If this is not possible, be sure to scrutinize the results from the Linux Azure DevOps build carefully. On Linux, you may use the command

      `./build -Target=Test`

### Review Milestone Status

1. Check the milestone for the current release to see that there are no open issues. Any issues that are not going to be in this release should be moved to a future milestone. This may be the time to create the next milestone.
2. Make sure that completed issues are marked with the appropriate 'closed' label depending on disposition. The release notes will end up reflecting issues marked closed:done.
3. Check all future open milestones for completed issues. Anything that is completed will be included in this release so change its milestone to the current release.
4. Review all closed issues without a milestone. Move them to the current milestone if they were fixed in this release, or set their milestone to `Closed without action` for questions and issues that were closed without a fix. You can use the following query to find issues that need to be reviewed:

```cmd
    is:issue no:milestone is:closed -label:closed:sep -label:closed:notabug -label:is:question -label:closed:wontfix -label:closed:noresponsefromreporter -label:closed:fixedin_newer_version -label:closed_moved_to_discussion -label:closed:duplicate -label:closed:byDesign
```

### Update Copyright Year

The copyright in the `[assembly: AssemblyCopyright("...")]` and the copyright text displayed by `nunitlite` should be updated to the year of the release. Search for `AssemblyCopyright` in the solution and update it where needed, then check `TextUI.cs` in `nunitlite-runner` for default values used when no attribute is found.

If necessary, update the year in the general copyright notice LICENSE.txt. Note that these copyright notices refer to each of the packages in their entirety. Each of the `.nuspec` files in the `nuget` subdirectory contains a copyright line, which should also be updated.

### Update CHANGES File

The `CHANGES.md` file in the project root contains all relevant changes for each release. It contains the same information as the release notes in the project documentation, in text format. Because the CHANGES file includes the **date** of the release, you must know when the release is coming out in order to edit it. Otherwise, it will be necessary to make a final change to the file at the point of making the release.

Create new sections in the CHANGES file to match those for prior releases. To ensure that all changes are included, review closed issues in the current and any future milestones. If an issue for a previous milestone was actually completed and closed, move it to the current milestone, since that's where it is being released. Include all issues resolved as closed:done in the issues section of the file. Significant feature additions and changes should be documented, even if they are also listed with issue numbers. Reviewing commits and merged pull requests may help in catching additional changes.

To generate the change list in the format required, use the **rprouse/GetChanges** console app from [NUnit.InternalTools](https://github.com/nunit/NUnit.InternalTools) which fetches and prints all issues in the given milestone, e.g. for milestone 4.0:

`dotnet run -o nunit -r nunit -l -m 4.0`

Clone the repo and run it from the solution root. The `-o` and `-r` options specify the owner and repo, respectively. The `-l` option includes all links, including those that are closed. The `-m` option specifies the milestone. If no milestone is specified, the current milestone is used.

*Note:  You might need to manually create the IssuePr link file. It will be automated in the future.*

### Update the Documentation

The [Release Notes](xref:frameworkreleasenotes) section of the documentation site should match the content of the `CHANGES.md` file except for any format differences.

For any significant changes to how NUnit is used or what it does, the appropriate pages of the documentation should be updated or new pages created. For new features or changes to features, include the version of NUnit that the feature was implemented in.

### Push All Changes

Push all changes to the files in git as part of the preceding steps. Make sure you have pushed them and they have been reviewed in the PR.

## Creating the Release Locally

The release **should not** be built on a developers machine, it should be built by the build servers. The following steps are only for reproducing the steps locally.

1. Clear the package directory to avoid confusion:

      `erase package\*`

   This is not absolutely required, but will be helpful if you have other release packages present
   in the directory.

2. You should be working on the release branch. Do a pull to make sure you have everything up to date. If changes of any significance were merged, you should test again before creating the release.

3. Ensure that the release build is up to date. If you have any doubt whether the latest code changes
   have actually been built, do a clean build. If the build is up to date you may skip this step.

      `.\build.ps1 --Target Build`

4. Create the image directory

      `.\build.ps1 ---Target CreateImage`

   You do this to ensure that the latest build is used for packaging. If the `images` directory does
   not already contain a subdirectory named for this release (package version and suffix) you may skip
   this step as a new one will be created automatically.

5. Create the packages by running:

      `.\build.ps1 --Target Package`

6. Verify that the correct packages have been created in the `package` sub-directory:

* NUnit-VERSION.zip
* NUnit.VERSION.nupkg
* NUnit.VERSION.snupkg
* NUnitLite.VERSION.nupkg
* NUnitLite.VERSION.snupkg

## Testing the Release

The degree to which each package needs testing may vary depending on what has been changed. At a minimum,

1. Ensure the [NUnit Framework CI](https://nunit.visualstudio.com/NUnit/_build?definitionId=11) build succeeds on all platforms and that the tests passed.
2. Download `Package.zip` from the build and extract it locally.
3. Five files should be extracted, `NUnit.{version}.nupkg`, `NUnit.{version}.snupkg`, `NunitLite.{version}.nupkg`, `NunitLite.{version}.snupkg` and `NUnit.Framework-{version}.zip`.
4. In Visual Studio, create a test project and add your local directory as a package source. Install the packages and verify that they apply to the project correctly.
5. Run unit tests for platforms or features that have changed in the release.

## Merge the Release PR

Once you have tested the release PR and all checks have passed, merge the PR into the release branch.

## Publishing the Release

Once the [NUnit Framework CI](https://nunit.visualstudio.com/NUnit/_build?definitionId=11) build for the merge to the release branch finishes, once again download and unzip `Package.zip`.

### Github

1. Log onto Github and go to the main NUnit repository at <https://github.com/nunit/nunit>.
2. Select Releases and then click on the "Draft a new release" button.
3. Enter a tag to be used for the release. Currently our tags are simply the version of the release prefixed with a `v`, like `v3.12`. If you start typing with 'v' you'll get a list of earlier release tags so you can see the format. **Select the release branch** as the target for the tag.
4. Enter a title for the release, like NUnit 3.13. If you type 'N' you'll get some hints.
5. Use the preamble from the release notes for the description and add a link to the full release notes on the docs website.
6. If this is an Alpha or Beta release, check the box that indicates a pre-release.
7. Upload the five files from `Package.zip` that you downloaded. Note that we upload all the packages, including those that are also published on NuGet.
8. Click the "Publish release" button to publish the release on Github.

### NuGet

1. Sign on to nuget.org.
2. Select Upload package.
3. Browse to the location of the `NUnit.VERSION.nupkg` you created and upload it.
4. Verify that the info is correct and click the "Submit" button.
5. Repeat steps 2-4 for `NUnitLite.VERSION.nupkg` and the two `snupkg` files.

### Website

Create a PR to update the NUnit.org website with the release.

### Notify Users

Send notifications to the mailing list and twitter.

### Close the Milestone

The milestone representing this release should be closed at this time.

[semantic versioning]:https://semver.org/

## Update Master with Changes from Release

### Create a Merge Branch

On your local machine, change to the release branch, fetch latest, pull, then create a branch to merge the release changes back to master.

```sh
git checkout release
git fetch -p
git pull
git checkout release313-merge
```

### Update Assembly Versioning

`AssemblyVersion` and `AssemblyFileVersion` are set for all projects in the framework in one file. Update the version in `FrameworkVersion.cs` to the next planned release number.

### Update Package Versions

The package version is updated in the `build.cake` file. The following lines appear near the beginning of the file. Update the versions and modifiers as necessary.

```csharp
var version="3.14.0";
var modifier=""
```

The version variables are three-part version numbers that follow the basic principles of [semantic versioning]. Since we publish a number of NuGet packages, we use the NuGet implementation of semantic versioning.

For NUnit, the major version is updated only rarely. Normal releases will update the minor version and set the third component to zero. The third component is incremented when "hot fixes" are made to a production release or for builds created for a special purpose.

For pre-release versions, a non-empty modifier is specified. This is a suffix added to the version. Our standard suffixes are currently `-alpha-n`, `-beta-n` and `-rc-n` The build script adds an additional suffix of -dbg to any packages created using a Debug build.

> [!NOTE]
> The first alpha, beta or rc release may omit the `-n`. In that case, any following alpha, beta or rc should use `-2`.

### Create a PR to Merge to Master

Push your local changes to GitHub and create a PR to merge the changes back to master. You can do this in the web or using the GitHub CLI.

```sh
gh pr create -a rprouse -B master -t "Merge 3.13 release changes to master"
```

Once the PR is built, approved and passes all checks, merge to master.
