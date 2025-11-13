# Supported Frameworks

The table below shows the supported adapter versions for a given framework version.

|Framework version|Supported by Adapter versions|Comment|
|---|---|---|
|Net Core 1.0|3.8 - 3.15.1||
|Net Core 2.0|3.8 - 3.15.1||
|Net Core 2.1|3.8 - 4.3.0||
|Net Core 2.2|3.8 - 4.3.0||
|Net Core 3.0|3.8 - 4.3.0||
|Net Core 3.1|3.8 - 5.X ||
|Net Framework 3.5|All up to 4.3.X||
|Net Framework 4.X-4.6.1|All up to 4.3.X||
|Net Framework 4.6.2 - 4.8|3.8 - up to latest ||
|Net 5|3.15.1 - 5.X | May also work with earlier versions, but not tested|
|Net 6|4.1 - 5.X |May also work with earlier versions, but not tested|
|Net 7|4.3 - 5.X ||
|Net 8+|Works with 4.3.2 and upwards||

The adapter is shipped with three different versions of the test framework. The first is the full framework version, 
which is used for .NET Framework based test projects.  The second is the .NET version 6.0, which is used for .NET 
6.0, and the third is .NET 8.0 which is used for .net 7.0, 8.0, 9.0, 10.0 and upwards.  
The different versions of the adapter supports different versions of the test framework.  
The table above shows the supported versions.

Version 4.3.2 of the adapter will support future versions of .net, as long as there are no breaking changes.  (Earlier
versions have been blocking that based on the table above).

The included versions are as shown below, only the versions where changes are done are listed.

| Adapter version | .NET framework version | .NET (core) version | Comment |
|---|---|---|---|
| 3.8 | 3.5 | 1.0 | Some versions included 2.0 too |
| 3.16.0 | 3.5 | 2.1 | |
|4.3.1|3.5|3.1||
|4.4.0|4.6.2|3.1||
|6.0.0|4.6.2|net8.0||

## Traps

* Microsoft.NET.Test.Sdk 17.4.0 is not compatible with .NET Framework lower than 4.6.2

## Tips

See [Adapter/Engine compatibility](Adapter-Engine-Compatibility.md) for information on which engine versions are being
used with the adapter.
