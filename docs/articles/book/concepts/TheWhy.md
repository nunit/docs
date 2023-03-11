# The "Why"

Documentation often focuses on the "what", but with test automation and TDD it's also very important to focus on why we might apply a certain concept or approach.

## Why Write Automated Tests?

* **Living Documentation**. Tests describe what your code does, in a way that is continually verified. You can read the tests and understand how the code will behave, without worrying if the documentation is out of sync.
* **Reduced Fear**. So, you think your code could be better, and you'd like to change it. "No!" you hear someone say "We can't touch that code; we don't know if it'll break anything." Tests help solve that problem.
* **Better than reduced fear -- confidence**. We want to move faster _without_ breaking things. You can think of each automated test as a strand in a safety harness that helps you and your team move faster.
* **Lower Total Cost of Delivery**. We lower the cost of future change in our code, which means we lower the total cost of delivery. We have more options open to us, and future changes take less time because we are guided by the tests we've created.
* **We are human. (At least, last time we checked)**. Humans make mistakes. It's great if we can prove that the code works how we think it'll work.
* **Triangulating issues -- and proving they're fixed**. Something has gone wrong. How do you pinpoint where that's happened? With tests in place, you can express the issue in terms of one or more failing tests. When all tests pass once more, you can prove that the bug is gone.

And there are the longer-term considerations:

* **Tested code is testable code**. Is our code straight-forward and modular enough to be tested? One sure way to prove this is by testing it.
* **Thinking about how code will be consumed**. Writing tests forces you to think about calling the code you're writing, which helps you see the surface area and usage of the code. This perspective shift can lead to a better experience for someone consuming your code -- even if that someone is you.

## Why TDD?

TDD -- Test-Driven Development (or sometimes Test-Driven _Design_) -- is the art of writing a test before you write the corresponding piece of production code. Why do that?

* **Timeliness**. Returning to code after we've written it to write tests proves how the program works now. But what about our intent? How can we prove that the program works how we intend it to work? This is where TDD comes in; by writing tests at the time we write the code, we gain additional confidence from testing from our intention all the way through to production code.
* **Design Drivers**. As we mentioned earlier, some benefits of tests are that they often keep code simpler and more modular, and that they force the developer to test-drive the usage of their code. TDD takes this to the next level -- from early on, you are engaging with your the shape of your code. As you approach the design of your code with TDD, it often becomes easier to spot dependencies as they emerge and make them explicit. By performing these cycles early and often, you gain many opportunities for insight into your code and its usage, and your design will benefit from that.

## Why NUnit?

NUnit is a testing framework for .NET. Like other frameworks -- xUnit, MSTest -- it provides a few core components that compose such a framework:

* Ways to define tests
* A runner to run the tests (though you can hook into the Visual Studio test runner, the ReSharper test runner, NCrunch, or any other runner of your choice)
* An assertion library to use during testing (though you can substitute for FluentAssertions or the library of your choice)

We believe the concepts we'll discuss here will be able to be applied to any major test framework in most languages. If you couple the concepts in this guide with some documentation in any major test framework, we hope you'll be able to get where you need to be.

So, the question becomes -- who will benefit from NUnit's particular _flavor_ of test framework?

* NUnit benefits in particular from its longevity -- our first NuGet package was published in 2011, 13 years prior to this article being written. In that time, the library has amassed 200+ million downloads and has seen a ton of support from the community. To borrow the Farmers Insurance ad campaign, "We know a thing or two because we've seen a thing or two."
* We think that beginners and newcomers benefit from the _explicitness_ of NUnit and the way it approaches tests with attributes such as `[Test]`, `[SetUp]`, and `[TearDown]`. In some cases, xUnit relies on C# conventions in ways that might not be familiar.
