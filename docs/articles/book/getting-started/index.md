# Beginning Our NUnit TDD Journey

In this exercise, we'll introduce you to NUnit and some NUnit concepts by doing some introductory test-driven development at the same time.

## Introducing the Exercise: A Temperature Converter

_This exercise comes to us via [Fadi Stephan](https://www.linkedin.com/in/fadistephan/) of [Kaizenko](https://www.kaizenko.com/) who first taught it to the author. Used here with his permission. Thanks, Fadi!_

Let's imagine a scenario in which we have to convert Celsius temperatures to Fahrenheit.

Before jumping in, we think a little about the problem space and some things we might know about the conversion:

* We'll probably have something that converts temperatures, probably called `TemperatureConverter`.
* We're converting Celsius to Fahrenheit, so we'll probably have a method in that called `ConvertCToF`, or similar.
* That method will probably take in a decimal and return a decimal, e.g. `public decimal ConvertCToF(decimal celius)`.
* We also probably know at least some of these common conversions:

| Celsius Temperature | Fahrenheit Temperature |
| ------------------- | ---------------------- |
| 0 | 32 |
| 100 | 212 |
| 37 | 98.6 |
| -40 | -40 |

## Creating the Project Structure

* Create a new, empty folder somewhere that you want to practice this exercise
* Open a command prompt and go to that folder.
* Run the following commands:

```cmd
dotnet new sln --name Conversions
dotnet new classlib --name Conversions
dotnet new nunit --name Conversions.Tests
dotnet sln add .\Conversions\
dotnet sln add .\Conversions.Tests\
cd .\Conversions.Tests\
dotnet add reference ..\Conversions\Conversions.csproj
```

Let's break down what this command does.

* Adds a new solution named `Conversions.sln`
* Adds a new class library called `Conversions.csproj` (this will be our production code project)
* Adds a new test project using the `nunit` template, called `Conversions.Tests.csproj` (this will be our unit test project)
* Adds a reference from the test project to the production code project so that we can see its contents.

As for the `nunit` template, what does that do for us "out of the box"? In the `Conversions.Tess.csproj` file, we can see that a few libraries have been added for us:

[!code-xml[PackageListing](~/snippets/book/getting-started/Converter.Tests/Converter.Tests.csproj#L11-L23)]

* `Microsoft.NET.Test.Sdk` brings the test platform along and allows tests to be run using the `dotnet test` command. It's a good idea to add this to any .NET automated test project.
* `NUnit` brings in the core NUnit library.
* `NUnit3TestAdapter` surfaces NUnit3 tests for the Visual Studio / `dotnet test` runner. It essentially allows NUnit tests to be discovered.
* `NUnit.Analyzers` are Roslyn analyzers that provide helpful tips and surface warnings at development time. They catch common errors and guide you toward an idiomatic NUnit experience.
* `coverlet.collector` is a popular .NET tool for collecting test coverage metrics.

## A First Test to Ensure Everything is in Order

Before writing our actual tests, we'll write one demo test to ensure the test runner is working.

* Open the `Converter.Tests` project
* Find the `UniTest1.cs` file and open it.
* You'll see a test exists there for the out of the box template:

[!code-csharp[OutOfTheBoxTest](~/snippets/book/getting-started/Converter.Tests/UnitTest1.cs#OutOfTheBoxTest)]

Below that test, add a new test consisting of a basic assertion:

[!code-csharp[FirstTest](~/snippets/book/getting-started/Converter.Tests/UnitTest1.cs#FirstTest)]

Run the tests using your runner of choice (Visual Studio's test runner, `dotnet test` from the console, etc.). You should see two tests that both pass.

With those tests passing, we're ready to tackle our first test case.

## Test Case 1: 0 Degrees Celsius == 32 Degrees Fahrenheit

With this first test case, we're ready to create our first test that fails, before we've created any production code -- the "red" in our "red, green, refactor" cycle.

Since we said earlier that we'll end up creating a class called `TemperatureConverter`, we'll start by creating a class in our test project called `TemperatureConverterTests.cs`.

Next, let's think about how we might name our test. There are two common approaches we could take:

* Put the method name we're testing in the name of the test. Our Test name method names would start with `ConvertCToF_`.
* Create a sub-class for each method name. We'd create a class within `TemperatureConverterTests` called `ConvertCToF` and put tests under that.

Since we'll only have a handful of tests, I'm going to choose the first option for this example.

Next, we want to think about what the circumstances are of the test, and what the expected output is. This we can we can put it right in the test name. A common format is `[MethodName]_[Situation]_[ExpectedResult]`. In our case, we expect to pass `0` into `ConvertCToF` and have it return `32`. So a safe bet for our test name is `ConvertCToF_Zero_Returns32`.

So, in our test project we will:

* Create a class named `TemperatureConverterTests.cs`
* Set it up to look like the below:

[!code-csharp[ConvertCToF_Zero_Returns32](~/snippets/book/getting-started/Converter.Tests/TemperatureConverterTests.cs#ConvertCToF_Zero_Returns32)]

Let's break this down line by line.

* We define a test by putting the `[Test]` attribute above the method. This lets NUnit know we have a test. If you don't include this attribute, your test won't be run.
  * (another way that TDD is helpful -- by seeing the test fail first, we know it's running.)
* We define the test name `public void ConvertCToF_Zero_Returns32()`
* We define the `sut`, or "situation under test": `var sut = new TemperatureConverter();`
  * This is a common shorthand name. You don't have to use it, but we'll use it throughout this guide for consistency.
  * This definition is sometimes considered to be part of the "Arrange" in [Arrange / Act / Assert](~/articles/book/concepts/TestingConcepts.md#aaa-arrange--act--assert).
* We take an action on the SUT, calling a method and getting a result: `var result = sut.ConvertCToF(0);`
* We then make an assertion: `Assert.That(result, Is.EqualTo(32));`

At this point, we've defined our test in terms of how we want our production code (which does not yet exist) to behave. When we try to run our test for the first time now, it will fail with a compiler error, because that class doesn't yet exist. This is a valid "red" state, and so we move onto the next step: writing just enough production code to get the test to a "green" (passing) state.

In our case, this means that in the production code project we:

* Create a `TemperatureConverter.cs` class
* Define a `public decimal ConvertCToF(decimal celsius)` method
* Hard-code that method to return `32`;
  * This might seem silly at first, but by doing the simplest thing possible, it forces us to write more tests which we might otherwise skip over. This step saves me headaches all the time.

```csharp
public class TemperatureConverter
{
    public decimal ConvertCToF(decimal celsius)
    {
        return 32;
    }
}
```

We run our tests and -- they pass! With that in mind, we look to see if there's anything we can refactor at this point. Nothing comes to mind, which means we're done our first cycle of "Red, Green, Refactor" in TDD.

Clearly, there's more to do.

## Adding our Next Test Case

The next well-known example in our list was that a Celsius temperature of 100 (boiling water) is the equivalent of 212 degrees Fahrenheit.

So we add our next test to the `TemperatureConverterTests.cs` file, keeping our same naming convention as before:

[!code-csharp[ConvertCToF_100_Returns212](~/snippets/book/getting-started/Converter.Tests/TemperatureConverterTests.cs#ConvertCToF_100_Returns212)]

When we run our test, it fails, because the production code is hard-coded to always return `32`.

What's the simplest thing we can do to make the test code pass? We add an `if` statement:

```csharp
public decimal ConvertCToF(decimal celsius)
{
    if (celsius == 100) { return 212; }
    return 32;
}
```

This production code still doesn't look nearly ready for production. We should continue on to our other examples.

## The Remaining Examples

We continue this cycle of "Red, Green, Refactor" for our two remaining exmples:

[!code-csharp[RemainingExamples](~/snippets/book/getting-started/Converter.Tests/TemperatureConverterTests.cs#RemainingExamples)]

And we wind up with prod code that looks like:

```csharp
public decimal ConvertCToF(decimal celsius)
{
    if (celsius == 100) { return 212; }
    if (celsius == 37) { return 98.6m; }
    if (celsius == -40) { return -40; }
    return 32;
}
```

The tests cover our examples, but we know the production code is not ready for prime-time. We can't think of any more examples, so it's time to put in our algorithm. We replace the if statements in our production code with the correct algorithm:

```csharp
public decimal ConvertCToF(decimal celsius)
{
    return celsius * 5 / 9 + 32;
}
```

And we run our tests. They pass!

...Except, wait. They don't.

We know this is the right formula. But we can see the specific tests that are failing and the actual values definitely look off.

We check everything we can over and over again until it's apparent: the formula we _knew_ was correct...isn't. Our tests have given us the confidence to realize that we must have copied the formula incorrectly. Our refactoring was not successful, because all existing tests didn't pass.

When we update our production code to the correct formula:

```csharp
public decimal ConvertCToF(decimal celsius)
{
    return celsius * 9 / 5 + 32;
}
```

The tests now pass. Our refactoring is successful; we have changed the inner workings of the code with a high degree of confidence that we didn't change the code's result, and we've prevented a pretty severe bug. When changing from the `if` statements to the algorithmic example, we were prevented from making a mistake that's all too easy to make.
