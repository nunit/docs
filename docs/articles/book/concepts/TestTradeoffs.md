# Test Trade-offs

Different types of tests have different trade-offs in their usage.

Typically, automated tests are thought of as a pyramid or a funnel.

* In a pyramid visualization, unit tests comprise the base of the pyramid (the largest part). On top of them are integration tests, then acceptance/functional tests, then UI tests.
* In a funnel visualization, the pyramid is inverted, and we think about unit tests as catching a majority of potential issues, followed by integration tests and acceptance/functional tets.

The thinking behind both of these visualizations is that you want most of the tests in your project to be unit tests, followed by integration tests and acceptance/functional tests because of the trade-offs we're about to get into.

While the approaches above offer a generalized, the reasoning behind them is the important part to consider.

## The Journey Away from Fine-Grained Tests

The further we move away from unit tests toward coarser-grained tests, a few things happen:

* **Tests require more setup**. The further away you go from unit tests, typically the more setup those tests require. Instantiating a new database for each test run is much more setup than using a fake dependency.
* **Tests can fail for more than one reason**. When a unit test fails, you almost always can pinpoint exactly what's happening. But an integration test may comprise many units; when it fails, how do you know which unit is responsible for the failure, unless you also have a failing unit test?
* **Tests can fail for unrelated reasons**. For example, if you have a UI test that refers to a certain element, and the name or position of that element changes, your UI test may fail even though the UI is actually in perfectly working order.
* **Tests take (much) longer to run**. As a rule of thumb, I can run approximately 500-1,000 unit tests per second. However, if I have to instantiate a real database and make round trips of data to that database, a given test will take substantially longer. I once worked on a project where a few thousand unit tests took a few seconds to execute, but a few hundred integration tests took a few hours.
* **Tests take longer to fix**. Because of the longer execution time, multiple possible failure points, and potential for flakiness, troubleshooting these tests are often more difficult, which can lead to tem being left flaky for a long time or (worse) ignored or deleted altogether.

With that said, having a project that completely neglects a layer is likely to suffer as well:

* The team may make assumptions about how units of code work together, only to find that real components behave differently in practice.
* The team may miss important considerations of coarser-grained tests, such as the contracts for an API
* If there are no UI tests at all, it could be possible to deploy an application that passes and yet has a UI that is completely inoperable.

## Finding the Right Trade-offs for Your Team

Each codebase has a different context and set of trade-offs that might inform test types to use. Examples:

* Teams with the ability to minimize the setup and execution time of their tests may benefit from more integration tests
* Legacy projects with little test coverage often start with UI tests to establish a baseline of confidence, and then take some of those tests and "push them down" into several API tests or integration tests to alleviate some of the trade-offs
* Teams with a high degree of non-coder collaboration may write a higher number of acceptance/functional tests because the language of the tests is closer to the language they use with their stakeholders.

Keep some of the below in mind and you may avoid some pitfalls:

* **Actively talk about and re-evaluate test types**. For example:
  * If a number of UI tests have built up confidence and you've seen no failures, and those tests are appropriately covered by finer-grained tests, it may make sense to retire them.
  * If you keep getting caught off-guard by integration issues, it may make sense to invest more time in integration or acceptance tests.
  * If you've discovered a way to reduce the execution time and maintenance burden of a given layer of tests, it may make sense to invest more in that layer.
* **Remember: The goal is _confidence_**.
  * If a test fails, it should be treated as an issue until it can be proven otherwise.
  * Don't settle for flaky tests if you can at all avoid doing so.
  * If a test no longer serves to improve confidence in the system (and doesn't meaningfully play into the living documentation of the system), consider removing it or pushing it into finer grained tests.
  * If the maintenance of a set of unit tests is costly and things are well-covered by integration tests that provide a high degree of confidence, perhaps some of those unit tests can be retired.
* **Keep execution times as fast as possible**. The goal is to run as many tests as possible as often as possible. If a set of tests takes 6 hours to run, how will you be able to get confidence in pushing a branch of code prior to merging it in? More often than not, those tests will be skipped.
