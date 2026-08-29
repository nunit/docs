---
uid: downloading
---

# Downloading

Normally you would install NUnit following the [guidelines for installation](./installation.md).

However, sometimes you need just the little extra!

## Release versions

You can find the latest release package itself at [Nuget](https://www.nuget.org/packages/NUnit), here you will also
find earlier versions, and instructions on how to install using different tools.

This is our latest release ![Release date](https://img.shields.io/github/release-date/nunit/nunit.svg?style=flat),
[![NuGet Version](https://img.shields.io/nuget/v/NUnit.svg)](https://www.nuget.org/packages/NUnit/).  And it has a
high number of ![Downloads](https://img.shields.io/nuget/dt/NUnit.svg?style=flat).

You can also find the release package at the [Release section](https://github.com/nunit/nunit/releases) in
our [github repo](https://github.com/nunit/nunit).

The repo is also where you can raise issues, download code, join discussion or just look around.

## Developer versions

We also release developer versions, they are called `alpha` versions, and you find them at our place at [[MyGet](https://img.shields.io/myget/nunit/vpre/NUnit.svg?label=MyGet%3A%20Latest%20pre-release&style=flat)](<https://www.myget.org/feed/nunit/package/nuget/NUnit>).

A new developer version is created every time we merge a new Pull Request into our main branch.

The easiest way to get the developer versions, is to add it to your nuget.config file, or if you don't have it, just create one.  

The code snippet below is the full content of a nuget.config file which includes the MyGet feed.

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
    <add key="myget" value="https://www.myget.org/F/nunit/api/v3/index.json" />
  </packageSources>
</configuration>
```

Note that if you use [Central Package Management](https://learn.microsoft.com/en-us/nuget/consume-packages/central-package-management) you will get a [NU1507](https://learn.microsoft.com/en-us/nuget/reference/errors-and-warnings/nu1507) warning about having two feeds and not having [package source mapping](https://learn.microsoft.com/en-us/nuget/consume-packages/package-source-mapping).  You can just ignore this warning if you're just going to test it, but if you like to use it over time, you should add it like shown below.

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
    <add key="myget" value="https://www.myget.org/F/nunit/api/v3/index.json" />
  </packageSources>
  <packageSourceMapping>
    <packageSource key="nuget.org">
      <package pattern="*" />
    </packageSource>
    <packageSource key="myget">
      <package pattern="NUnit" />
    </packageSource>
  </packageSourceMapping>
</configuration>
```
