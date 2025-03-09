# Framework Extensibility

The NUnit Framework is the part of NUnit that is referenced by user tests. It contains the definition of all of NUnit's
Attributes, Constraints and Asserts as well as the code that discovers and executes tests. Most extensions to exactly
how tests are recognized and how they execute are Framework extensions.

In this documentation, we refer to three different types of Framework extension:

[Custom Attributes](Custom-Attributes.md) allow creation of new types of tests and suites, new sources of data and
modification of the environment in which a test runs as well as its final result.

[Action Attributes](Action-Attributes.md) are an NUnit V2 feature, still supported in NUnit 3. They were designed to
better enable composability of test logic by creating attributes that encapsulate specific actions to be taken before or
after a test is run. For most work, [Custom Attributes](Custom-Attributes.md) are the way to go, but [Action
Attributes](Action-Attributes.md) continue to be the only way to apply an attribute at a higher level and have it apply
to many tests.

[Custom Constraints](Custom-Constraints.md) allow the user to define new constraints for use in tests along with the
associated fluent syntax that allows them to be used with `Assert.That`.

## Links to Blog Posts

### On Custom constraints

[How to extend the NUnit constraints](https://hermit.no/how-to-extend-the-nunit-constraints/)
