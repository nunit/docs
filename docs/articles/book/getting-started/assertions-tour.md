# A Quick Tour of Assertions

In this guide, we'll begin a new sample application in order to work through some TDD and explore some of NUnit's assertions in tests.

We're going to build on this sample in the coming guides to explore NUnit concepts.

## Creating the Project Structure for a "Checkout Machine"

* Create a new, empty folder somewhere that you want to practice this exercise
* Open a command prompt and go to that folder.
* Run the following commands:

```cmd
dotnet new sln --name Supermarket
dotnet new classlib --name Checkout
dotnet new nunit --name Checkout.Tests
dotnet sln add .\Checkout\
dotnet sln add .\Checkout.Tests\
cd .\Checkout.Tests\
dotnet add reference ..\Checkout\Checkout.csproj
```

Let's break down what this command does.

* Adds a new solution named `Supermarket.sln`
* Adds a new class library called `Checkout.csproj` (this will be our production code project)
* Adds a new test project using the `nunit` template, called `Checkout.Tests.csproj` (this will be our unit test project)
* Adds a reference from the test project to the production code project so that we can see its contents.

## Creating our First Test

* In your `Checkout.Tests` project, create a `CheckoutMachineTests.cs` file.
* Replace the code in that file with the below:

```csharp
public class CheckoutMachineTests
{
    [Test]
    public void Total_NoItemsScanned_Returns0(){}
}
```

Let's pause for a moment before proceeding. What does this test name tell us?

We use a standard convention in this case, and with good reason -- the name conveys a lot of information at a glance. This follows the format `[MethodUnderTest]_[Scenario]_[ExpectedResult]`. So from this name, we know our checkout machine will have a method called `Total`, and when no items are scanned, that method should return `0`.

TODO: Finish Assertion & Prod Code
TODO: Show scanning an item & Prod Code (easiest possible)
TODO: Show scanning a different item & Prod Code (update scan method to include a number of some kind)
TODO: First refactoring - extracting the idea of a SKU

TODO: idea of TotalItems so we can explore a GreaterThan assertion. Or maybe something like capturing the time a checkout starts and then asserting items were added after the start?