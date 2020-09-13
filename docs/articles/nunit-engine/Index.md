---
uid: nunitengine
---

# NUnit Engine

The NUnit Engine is the component used as the foundation of any test runner. It contains all the logic required to run tests built against both NUnit 3.X and other frameworks, and exposes an API allowing test runners to interact with the engine and run tests as required.

> [!NOTE]
> The NUnit Engine is a component targeted at advanced users of NUnit, who are building their own test runner, rather than using one of the many existing test runners in the ecosystem. If you are looking to simply run tests that you have written, see the [running tests](xref:runningtests) section.

The engine exposes [an API](xref:testengineapi) designed to be used by test runners, which will be maintained in a backwards-compatible fashion wherever possible. The engine also hosts various extension points, to allow further customisation.