# Types of Automated Tests

## Before We Begin: A Note on Opinions on Test Types

The below is a summary of a lot of different schools of thought. It is by no means the only way of thinking about test types; we intend only to ground you in some general terms.vWe also don't cover every single type of test here; there are many specialized kinds of tests (security, smoke tests, sanity tests, verification tests, etc.).

If you place a group of experienced developers in a room, they'll likely have several overlapping terms and would have to figure out how to use that language as a team. We recommend any team have these conversations early and often to ensure you're using the same terms in the same way.

With that said, we do recommend that you try to use each test type correctly as it pertains to your team, because different types of tests come with different trade-offs and considerations, and it's important to consider those.

## Unit Tests

These are typically meant as the "lowest level" of automated tests. They aim to test a specific, isolated class. Any dependencies that class has on other classes would be faked in unit tests, so that they can execute quickly and with a clear understanding of how the class will behave. There will be more on this later when we discuss [test doubles and mocks](TODO).

## Integration Tests

Integration tests cover a wide variety of tests. It's often fair to say an integration test is to say "any test that tests two or more classes together". You may have a test that instantiates two different classes and makes assertions about them, or it may be a much larger test that tests 10 real classes together but where one of the 10 classes is faked (e.g. a database). It could be that an integration test uses all real components.

## Acceptance/Functional Tests

Unit and integration tests are often thought of as a developer "proving the code works the way I intend it to". Acceptance tests -- sometimes called "functional tests" -- shift that focus a little bit, and instead think about "proving the code is working the way an end-user expects it to."

Typically in these tests, _no_ (or as few as possible) fake components are used, because we are trying to verify that things work when the entire system is put together.

These kinds of tests, when not directly related to UI, can often be accomplished at a slightly lower level, such as an API level.

## End-to-End / UI-Based Tests

Some tests require interaction with the UI in order to prove things out. These are typically called "end-to-end" or UI tests.

These tests spin up an actual GUI or browser window and execute commands against a running system in order to assert their results.

## The Good News

...You can use one test framework for all of these!

All of the automated test types above still run in the standard unit test framework mindset -- set up a test, arrange the test, make an action, make an assertion, and tear down the test. Other tools can be used during these steps in conjunction with NUnit -- for example, during an NUnit test, you might manipulate a browser using Selenium or Playwright. But you can rely on a standard test framework to accomplish all of these tests.

## Which are Right for You?

The types of tests you employ and their mixture will depend highly on your team's context and the trade-offs and optimizations they're making. But, it's important to understand the trade-offs between the different tests, which we'll talk about next.
