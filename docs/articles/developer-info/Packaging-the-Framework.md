# Packaging the Framework

This note describes how to create release packages for the NUnit Framework. Currently, all the builds and packaging must
be done on a single Windows machine.

## Software Prerequisites

Various software combinations and environments may be used to build NUnit components. The following software is what we
have used and tested for building everything and creating the release packages. We'll add options to the list as we find
them.

1. Visual Studio 2022 17.10 or newer with the NuGet Package manager.
2. .NET 6.0 SDK
1. .NET 8.0 SDK

## Preparing for Release

### Create a Release Branch

All work on releases should be done on a branch.

1. On master `git switch main`, Pull latest `git pull`
2. Create a branch to prepare the release `git switch -c releaseXYZ`, where `XYZ` is the release number, e.g. `4.2.0`.
3. Push the branch to GitHub `git push -u origin releaseXYZ`
4. As you make the changes below, push the changes to GitHub and create a Pull Request targeting the `main` branch to
   allow other team members to review your changes.
5. The PR can be created in the web or using the GitHub CLI with `gh pr create -a rprouse -B release -t "Release 3.13"`

### Make Sure it Works

1. Close all instances of Visual Studio or other IDE to ensure that no changes are left unsaved.

2. Do a clean build and run all the tests on Windows. You may use the command below or three separate commands if
   preferred. If you encounter errors at any stage, you're not actually ready to release!

    ```cmd
    build --target clean
    build --target test
    ```

3. Repeat the build on a Linux system, if available. If this is not possible, be sure to scrutinize the results from the
   Linux Github actions build carefully. On Linux, you may use the command

      `build -target=test`

### Review Milestone Status

1. Check the milestone for the current release to see that there are no open issues. Any issues that are not going to be
   in this release should be moved to a future milestone. This may be the time to create the next milestone.
2. Check all future open milestones for completed issues. Anything that is completed will be included in this release so
   change its milestone to the current release.
3. Review all closed issues without a milestone. Move them to the current milestone if they were fixed in this release,
   or set their milestone to `Closed without action` for questions and issues that were closed without a fix. You can
   use the following query to find issues that need to be reviewed:

```cmd
    is:issue no:milestone is:closed -label:closed:sep -label:closed:notabug -label:is:question -label:closed:wontfix -label:closed:noresponsefromreporter -label:closed:fixedin_newer_version -label:closed_moved_to_discussion -label:closed:duplicate -label:closed:byDesign
```

### Update Copyright Year

If necessary, update the year in the general copyright notice LICENSE.txt. Note that these copyright notices refer to
each of the packages in their entirety.
Each of the `.nuspec` files in the `nuget` subdirectory contains a copyright
line, which should also be updated.

### Update the version number if needed

The version is given using [MinVer](https://github.com/adamralph/minver?tab=readme-ov-file#minver).
If the version number doesn't match you expected XYZ, you update the version number by adding and pushing a tag in main.
**Note that this tag has to be on the commit that you're releasing.**

### Update Release notes in `framework.md`

To generate the change list in the format required, use the **GetChanges** console app from
[NUnit.InternalTools](https://github.com/nunit/NUnit.InternalTools) which fetches and prints all issues in the given
milestone, e.g. for milestone 4.0:

Build a release version of the app, and go to the GetChanges directory. Run the following command, with the appropriate
 version number and milestone number:

`bin\Release\net7.0\getchanges.exe -o nunit -r nunit -l -m 4.2 > changes4.2.md`

The `-o` and `-r` options specify the owner and repo, respectively.
The `-l` option includes all links, including those that are closed. The `-m` option specifies the milestone. If no
milestone is specified, the current milestone is used.

*Note:  You might need to manually create the NUnit.IssuePr.XYZ link file. It will be automated in the future.*

Copy content of the file created to the top of  `framework.md` file in the `docs` directory.

### Update the Documentation

For any significant changes to how NUnit is used or what it does, the appropriate pages of the documentation should be
updated or new pages created. For new features or changes to features, include the version of NUnit that the feature was
implemented in.

### Push All Changes

Push all changes to the files in git as part of the preceding steps. Make sure you have pushed them and they have been
reviewed in the PR.
Then merge the PR to main.
Pull down the changes to your local machine.

## Creating the Release Locally

The release **should not** be built on a developers machine, it should be built by the build servers. The following
steps are only for reproducing the steps locally.

1. Clear the package directory (if it exists) to avoid confusion:

      `del package\*`

   This is not absolutely required, but will be helpful if you have other release packages present in the directory.

2. You should be working on the release branch. Do a pull to make sure you have everything up to date. If changes of any
   significance were merged, you should test again before creating the release.

3. Ensure that the release build is up to date. If you have any doubt whether the latest code changes have actually been
   built, do a clean build. If the build is up to date you may skip this step.

      `build --target build`

4. Optionally create the image directory manually

      `build --target createimage`

   You do this to ensure that the latest build is used for packaging. If the `images` directory does not already contain
   a subdirectory named for this release (package version and suffix) you may skip this step as a new one will be
   created automatically.

5. Create the packages by running:

      `build --target package`

6. Verify that the correct packages have been created in the `package` sub-directory:

* NUnit-VERSION.zip
* NUnit.VERSION.nupkg
* NUnit.VERSION.snupkg
* NUnitLite.VERSION.nupkg
* NUnitLite.VERSION.snupkg

## Testing the Release

The degree to which each package needs testing may vary depending on what has been changed. At a minimum,

1. Ensure the [NUnit Framework CI](https://nunit.visualstudio.com/NUnit/_build?definitionId=11) build succeeds on all
   platforms and that the tests passed.
2. Download `Package.zip` from the build and extract it locally, or use the ones you built locally.
3. Five files should be extracted, `NUnit.{version}.nupkg`, `NUnit.{version}.snupkg`, `NunitLite.{version}.nupkg`,
   `NunitLite.{version}.snupkg` and `NUnit.Framework-{version}.zip`.
4. In Visual Studio, create a test project and add your local directory as a package source. Install the packages and
   verify that they apply to the project correctly.
5. Run unit tests for platforms or features that have changed in the release.

## Publishing the Release

### Github

1. Log onto Github and go to the main NUnit repository at <https://github.com/nunit/nunit>.
2. Select Releases and then click on the "Draft a new release" button.
3. Enter a tag to be used for the release. Currently our tags are simply the version of the release,
   like `4.2.0`.  Don't add a `v` prefix to the tag. MinVer is set up to be used without the prefix. Note that the tag already exists, as you created it when you pushed the commit, or after that push.
4. Enter a title for the release, like NUnit 3.13. If you type 'N' you'll get some hints.
5. Use the preamble from the release notes for the description and add a link to the full release notes on the docs
   website.
6. If this is an Alpha or Beta release, check the box that indicates a pre-release.
7. Upload the five files from `Package` folder that you downloaded or built locally. Note that we upload all the packages, including those
   that are also published on NuGet.
8. Click the "Publish release" button to publish the release on Github.

### NuGet

1. Sign on to nuget.org.
2. Select Upload package.
3. Browse to the location of the `NUnit.VERSION.nupkg` you created and upload it.
4. Verify that the info is correct and click the "Submit" button.
5. Repeat steps 2-4 for `NUnitLite.VERSION.nupkg` and the two `snupkg` files.

### Website

Create a PR to update the [NUnit.org](https://github.com/nunit/nunit.github.io) website with the release.
Use the `_posts` folder and add a new one there.

### Notify Users

Send notifications to twitter, both for NUnit and for your own, add to your LinkedIn and any other relevant SosMed
channels you have.

### Close the Milestone

The milestone representing this release should be closed at this time.

