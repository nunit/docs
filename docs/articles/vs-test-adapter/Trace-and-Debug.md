# How to enable Trace and Debug output

Trace and Debug output is by default not sent to the console output, or anywhere else.  If you want to have this output, you must add your own tracelistener.

## Implementing the tracelistener in your code

This is easy to do, and you can do it per assembly, per namespace or per test.  All it takes is to add the necessary initialization of the tracelistener.

To add it to a namespace, place the following class inside that namespace, and it will apply to all tests inside that namespace and below.  The code shown adds the output to console output.  If you like you can change that to another kind of listener.

```cs
[SetUpFixture]
public class SetupTrace
{
    [OneTimeSetUp]
    public void StartTest()
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
    }

    [OneTimeTearDown]
    public void EndTest()
    {
        Trace.Flush();
    }
}
```

If you place the code above `outside any namespace` it will apply to the whole assembly.

If you just want it to apply to a given test fixture/class, then you just add the `StartTest and EndTest` methods to the given test fixture/class.

## Example outputs

Given the following verbose test

```cs
        [Test]
        public void Test1()
        {
            Debug.WriteLine("This is Debug.WriteLine");
            Trace.WriteLine("This is Trace.WriteLine");
            Console.WriteLine("This is Console.Writeline");
            TestContext.WriteLine("This is TestContext.WriteLine");
            TestContext.Out.WriteLine("This is TestContext.Out.WriteLine");
            TestContext.Progress.WriteLine("This is TestContext.Progress.WriteLine");
            TestContext.Error.WriteLine("This is TestContext.Error.WriteLine");
            Assert.Pass();
        }
```

With a tracelistener, the output in Visual Studio Test Explorer is:

![Trace Debug output](../../images/TraceDebug1.png)

Without the tracelistener, the blocks in red will not be present.

Running ``dotnet test -v n`, the output will be:

![DotNet Trace Debug output showing the lines outputted by the TraceListener](../../images/TraceDebug2.png)

## Discussion and source

This issue have been discussed at [Issue 718](https://github.com/nunit/nunit3-vs-adapter/issues/718) and [Issue 301](https://github.com/nunit/nunit3-vs-adapter/issues/301). Use of tracelistener suggested by [Frans Bouma](https://github.com/FransBouma).

The repro code for the issue can be found [here](https://github.com/nunit/nunit3-vs-adapter.issues/tree/master/Issue718).
