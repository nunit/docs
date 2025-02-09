# Debugging the NUnit3TestAdapter

## Enable Tracing

Before debugging the adapter, check the trace outputs, which can be enabled using runsettings, either from a file or 
the command line.

Enable the following [features](https://docs.nunit.org/articles/vs-test-adapter/Tips-And-Tricks.html#dumpxmltestdiscovery-and-dumpxmltestresults):

```xml
    <DumpXmlTestDiscovery>true</DumpXmlTestDiscovery>
    <DumpXmlTestResults>true</DumpXmlTestResults>
```

This will create a Dump folder under the executing bin directory, containing one file for each setting. These files 
include both the input from the testhost and the resulting data returned by the framework/engine.

## Enabling debugging

Debugging the adapter is done by first creating a debug version of the adapter.
You can then enable a debug run by passing one of the NUnit debug settings using runsettings.

The symbols are:

```cmd
NUnit.DebugExecution
NUnit.DebugDiscovery
NUnit.Debug
```

The last setting is equal to setting both of the two above.

From command line, you can set these by adding

```cmd
dotnet test -- NUnit.DebugExecution=true
```

If you want to do this using Visual Studio, you must add a runsettings file, and add these settings there to the NUnit 
section.

A detailed explanation of the process can be found in [this blog post](https://hermit.no/debugging-the-nunit3testadapter-take-2/)

## Debugging earlier versions

See [this blog post](https://hermit.no/debugging-the-nunit3testadapter/) for details on that process.
