NUnit provides three different runners, which may be used to load and
run your tests.

 * The [[Console Runner]], 
    nunit-console.exe, is used for batch execution.
 * The [[Gui Runner]], nunit.exe,
    provides interactive loading and running of tests.

### NUnit Agent

When running tests in a separate process, the console and gui runners make use of the [[NUnit Agent]] program, nunit-agent.exe. Although not directly run by users, nunit-agent does load and execute tests and users need to be aware of it, especially when debugging is involved.

### Third-Party Runners

Various third-party applications are available for loading and running NUnit tests. Some of these actually use NUnit to load the tests, while others provide their own emulation and may not work in the same way that NUnit does.
   
Because the status of such projects may change from time to time, we don't discuss them individually here. For the latest information, consult the manufacturer of any third-party software or ask other users on our
[discussion list](http://groups.google.com/group/nunit-discuss).
   
### Additional Information

For additional general information on how tests are loaded and run, see

 * [[Runtime Selection]]
 * [[Assembly Isolation]]
 * [[Configuration Files]]
 * [[Multiple Assemblies]]
 * [[Visual Studio Support]]
