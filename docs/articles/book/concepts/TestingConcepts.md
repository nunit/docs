# Testing Concepts

Lots of concepts are thrown around when we talk about automated testing. We'll briefly describe some of these here and then we'll work on applying them in the rest of the series.

## SUT / CUT (Situation/Class Under Test)

You might hear the term `SUT` or `CUT` or see these variables in tests you come across. Typically they mean the situation or class under test.

## AAA: Arrange / Act / Assert

Sometimes called the `AAA` approach, this refers to the way we might write a given automated test:

* **Arrange**: Here, we set up the test for the action that will follow. This typically involves setting up the situation/class under test to take a particular action on it. Sometimes some or all of this arrangement is done by a `SetUp` method.
* **Act**: In this step, we take an action. We call some part of our situation/class under test that either returns a value or that we expect to throw an exception.
  * Typically, we try to keep the actions to a minimum -- preferably, 1. If you are testing different actions, that often means you're testing a different path through your code. In that case, we recommend creating two tests -- one for each path.
* **Assert**: In this section of the test, we assert that a value is what we expect, or an exception has been thrown as we expect -- anything that indicates our expectations about the production code are met.
  * Similar to the _action_, we try to keep assertions to a minimum or create additional tests to capture each assertion. That's because if a piece of code fails, seeing which tests fail at the same time can help triangulate the issue and give insight as to what the problem is. Sometimes you'll hear this phrased as "one _logical_ assertion", because multiple assertions may make sense as part of an overall concept (e.g. checking three proprties are what you expect when all three relate to a particular concept.) When in doubt, create multiple tests -- you can always consolidate them later. Oftentimes, we might consolidate assertions in situations where the actions are expensive to run or maintain.
  * Note that if you are making more than one assertion for a test, NUnit has a particular format for that called `Assert.Multiple`. If you don't use that convention, NUnit will only try the first assertion and will fail the test if it fails -- which doesn't provide you any information about the other assertions you make in that test. This could lead to a situation in which you fix one part of a failing test, only to see another assertion in the same test fail.

Sometimes you'll see these actual statements in comments such as `// Arrange`, `// Act`, and `// Assert` in a given test method. This can be helpful for some folks as a mental marker. While we would never begrudge anyone this style, typically these comments can be removed and the different sections can be separated by a blank line.

> [!NOTE]
> This guide will use NUnit's `Assert.That` syntax because it comes out of the box. But, you should know that there are several libraries that can be used with NUnit to craft assertions and return helpful messages upon failure, such as [FluentAssertions](https://fluentassertions.com/) or [Shouldly](https://docs.shouldly.org/)


## Red / Green / Refactor

TDD lifecycle is often known as "Red, Green, Refactor":

* In the **Red** phase, you write a failing test.
  * "Failing" can also mean "not compiling". Since we write tests for production code before that code exists sometimes, there will be a failing test here too.
* In the **Green** phase, you write just enough production code to make the tests pass.
  * "Just enough" is crucial. If you write the simplest version of the code that passes, and you can trick your tests into passing, it's a good indicator that you need additional tests.
* Lastly, you look for opportunities to **Refactor** -- to change the design of your production code and tests while ensuring that all tests pass.
  * You are able to make changes because the tests provide a safety harness that prove you haven't introduced an issue.
  * Attending to this cleanup in small cycles like this is good hygiene for your codebase. Many cycles of red / green / refactor provides opportunities to cleanup as you go and makes this cleanup a part of your muscle memory.

## The FIRST Acronym in Automated Tests

The `FIRST` acronym is often used to describe the goals of automated tests. Tests aim to be:

* **F**ast: We want our tests to run as fast as possible. For example, unit tests should typically execute in no more than a second. Tests at higher levels might take slightly longer, but we want to prioritize speed.
  * Fast tests mean as many tests as possible can be run as often as possible -- this is the source of confidence that automated tests provide.
* **I**solated: Tests should not depend on the output of another test or on a specific order of tests or production code run. We should (theoretically) be able to run all tests at the same time.
* **R**epeatable: The same test, when run many times, should always produce the same result.
* **S**elf-Documenting: The test itself should tell you whether it passed or failed.
  * By this, we mean that a test shouldn't, for example, write out to a file that a human then needs to examine. When we run the test suite, we should gain immediate confidence in whether our code passes those tests or not.
  * Assertions are how we accomplish this in automated test libraries.
* **T**imely: Tests should be written around the same time as production code, so that you are not just documenting what the code does, but _what you intended_ the code to do.
  * In the case of TDD, the tests are guaranteed to be timely, because they're written _before_ the production code.

## Tests Are Production Code, Too

Just because you have tests in a test project doesn't mean they should be programmed in a sloppy manner. Active maintenance and refactoring of tests can pay huge dividends over the life of a project.

## "Flaky" Tests

Sometimes you'll hear tests referred to as "flaky" or experiencing "flakiness". Typically this means a test sometimes fails when we don't expect it to for reasons we don't fully understanding (violating the `R` in `FIRST`, stating that tests should be repeatable).

Typically, we want to fix these tests so that we can trust our test suite and don't start to ignore failures as "probably just a test being flaky". We need to be able to trust what the test results well us.

## DRY vs. DAMP

Because tests are production code, the general programming concept of `DRY` (Don't Repeat Yourself) often comes into play with tests.

However, tests have an important consideration -- they should be understandable quickly, with as little sleuthing as possible. If it serves the readability and understandability of the test, it's perfectly fine to repeat certain logic within a test rather than attempting to abstract it all away. In this way, we often say we prefer `DAMP` (Descriptive and Meaningful Phrasing) to `DRY`.

Like many things, this is a balance that a team should attempt to find and actively maintain. Some parts of tests can be extracted into common methods; other abstractions might make tests too hard to understand. Be willing to re-evaluate these choices as projects evolve.

## Test Coverage

In the realm of automated tests we'll often hear talk of "test coverage" -- sometimes coupled with a percentage, such as "every project should have 90% test coverage". Let's talk about what this means, and why it might be problematic.

"Test coverage" means the percentage of your production code that is called from -- sometimes we say "exercised by" -- tests. There are different methods to measure this. Some tools do a basic calculation of number of lines of code covered by tests divided by the total lines of production code. Others may use more complex methods that calculate test coverage on a per-method or per-statement level. But the general idea is that of seeing what amount of your production code tests actually "touch".

Understanding test coverage is a good thing, and improving it where it's lacking is typically a good thing.

However, there's an important adage known as [Goodhart's Law](https://en.wikipedia.org/wiki/Goodhart%27s_law), which states:

> "When a measure becomes a target, it ceases to be a good measure."

In other words, when a measure is used as the basis of judgment or reward, incentives will always exist to manipulate the measure in order to avoid the harsh judgement or receive the reward.

Thinking about this in terms of test coverage, specifying an arbitrary coverage target (of say, 90%) can lead to some self-defeating practices. Tests may be written for their own sake rather than because they add value and confidence; those tests still carry the same maintenance burden as any other code written in the system. And in many cases, those metrics are easy to game -- one could write a meta-test that visits every method in the system and then claim a high number of test coverage while adding no value. More often than not, teams end up testing libraries and pieces of the frameworks they use in ways that have a high overlap with those those projects already test themselves -- leading to increased test burden and complexity without much benefit.

My advice: Write as many tests as possible that increase confidence and add value, recognize when ROI may be limited, know your test coverage across your application, and avoid test coverage targets except as a thought exercise.

NOTE: It is still helpful to measure test coverage for the purpose of these conversations, and there is nothing wrong with saying that test coverage should not trend downward without a very good reason.
