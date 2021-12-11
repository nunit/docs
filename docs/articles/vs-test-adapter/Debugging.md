# Debugging the NUnit3TestAdapter

Debugging the adapter is done by first creating a debug version of the adapter.
You can then enable a debug run by passing one of the NUnit Debug settings using runsettings. 

The symbols are:
```
NUnit.DebugExecution
NUnit.DebugDiscovery
NUnit.Debug
```

The last setting is equal to setting both of the two above.

From command line, you can set these by adding
```
dotnet test -- NUnit.DebugExecution=true
```

If you want to do this using Visual Studio, you must add a runsettings file, and add these settings there to the NUnit section.

A detailed explanation of the process can be found in [this blog post](http://hermit.no/debugging-the-nunit3testadapter-take-2/)

### Debugging earlier versions

See [this blog post](http://hermit.no/debugging-the-nunit3testadapter/) for details on that process.
