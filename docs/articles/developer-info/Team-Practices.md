---
uid: teampractices
---

# Teams and Practices

## The Teams in the NUnit Project

The NUnit project is made up of several teams, each with its own focus and responsibilities, and with a set of team
members.

The team members are a bunch of dedicated people from all over the globe, who are passionate about NUnit and want to
make it better. They are all volunteers, and they do this in their spare time.

### The current teams

#### Core Team

This team has overall responsibility for the NUnit organization. It defines the vision for NUnit, decides what projects
should be included, appoints leads for other teams and maintainers for projects, sets standards and ensures we follow
them.

Team Lead: [Terje Sandstrom](https://github.com/osiristerje)

#### Framework Team

This team maintains the NUnit framework, which is the assembly referenced by user tests, as well as NUnitLite.

Team Lead: [Rob Prouse](https://github.com/rprouse)

#### Engine Team

The Engine Team maintains the NUnit3-Console runner, the Engine, and a number of extensions.

Team Lead: [Charlie Poole](https://github.com/charliepoole)

#### VS Extensions Team

NUnit's extensions to the Visual Studio IDE and dotnet.

Team Lead: [Terje Sandstrom](https://github.com/osiristerje)

#### Analyzer Team

The team that works on the NUnit Analyzers Project.

Team Lead: [Mikkel Nylander Bundgaard](https://github.com/mikkelbu)

#### Documentation Team

The team that works on the documentation for NUnit.

Team Lead: [Sean Killeen](https://github.com/seankilleen)

### Membership matrix

#### Current team memberships, listed in a kind of chronological order

| Name                                                                 | Core Team          | Framework          | Engine             | VS Extensions      | Analyzer           | Documentation      |
| -------------------------------------------------------------------- | ------------------ | ------------------ | ------------------ | ------------------ | ------------------ | ------------------ |
| [Charlie Poole](https://github.com/charliepoole) :us:                | :heavy_check_mark: |                    | :heavy_check_mark: |                    |                    |                    |
| [Rob Prouse](https://github.com/rprouse) :canada:                    | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: |                    |                    |
| [Terje Sandstrom](https://github.com/osiristerje) :norway:           | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: |                    |                    |
| [Mikkel Nylander Bundgaard](https://github.com/mikkelbu) :denmark:   | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: |                    | :heavy_check_mark: |                    |
| [Sean Killeen](https://github.com/SeanKilleen) :us:                  | :heavy_check_mark: |                    |                    |                    | :heavy_check_mark: | :heavy_check_mark: |
| [Steven Weerdenburg](https://github.com/stevenaw) :canada:           | :heavy_check_mark: | :heavy_check_mark: |                    |                    |                    |                    |
| [Ihor Sychevskyi](https://github.com/Arhell) :ukraine:               |                    |                    |                    |                    |                    | :heavy_check_mark: |
| [Manfred Brands](https://github.com/manfred-brands) :australia:      | :heavy_check_mark: | :heavy_check_mark: |                    |                    | :heavy_check_mark: |                    |
| [Neil Colvin](https://github.com/oznetmaster) :australia: :scotland: |                    |                    | :heavy_check_mark: |                    |                    |                    |

#### Former members and honorable mentions

| Name                                                  | NUnit membership period |
| ----------------------------------------------------- | ----------------------- |
| [Chris Maddock](https://github.com/ChrisMaddock) :gb: | 2016 - 2022             |
| [Joseph Musser](https://github.com/jnm2) :us:         | 2017 - 2026             |

## How We Work As a Team

|                                     |                                                                      |
| ----------------------------------- | -------------------------------------------------------------------- |
| [Issue Tracking](Issue-Tracking.md) | How we track bugs, enhancements and features on GitHub.              |
| [Contributions](Contributions.md)   | Explains how to review and merge code submitted by other developers. |
| [How to Develop and Fix Bugs](Developing-NUnit.md) | How to reproduce a bug, fix it and check the fix.   |

## Technical Practices

|                                                                                 |                                                                        |
| ------------------------------------------------------------------------------- | ---------------------------------------------------------------------- |
| Building and testing                                                            | See BUILDING.md in each repository.                                    |
| [Coding Standards](Coding-Standards.md)                                         | Describes coding standards used in NUnit.                              |
| [Best practices for XML documentation](Best-practices-for-XML-documentation.md) | Guidelines to consider when dealing with public APIs.                  |
| [Packaging the Framework](Packaging-the-Framework.md)                           | How to create the packages for a new NUnit Framework release.          |
| [Packaging the Console and Engine](Packaging-the-Console-and-Engine.md)         | How to create the packages for a new NUnit Console and Engine release. |
| [Packaging Extensions](Packaging-Extensions.md)                                 | How to create the packages and release NUnit Extensions.               |
| [Packaging the Installer](Packaging-the-Installer.md)                           | How to create and release the NUnit MSI Installer.                     |
| [Packaging the V2 Adapter](Packaging-the-V2-Adapter.md)                         | How to create the packages for a new NUnit 2 VS Adapter release.       |
| [Packaging the V3 Adapter](Packaging-the-V3-and-V4-Adapter.md)                  | How to create the packages for a new NUnit 3 VS Adapter release.       |
