---
uid: ordinarytests
---

# Ordinary Tests

Most of the tests you write will be *ordinary* tests: a method that sets something up, does one thing and checks the
result. This page shows what such a test looks like in NUnit, and where to go from there.

## Your first test

A test is a public method marked with the [`[Test]`](xref:attribute-test) attribute, inside a public class. The class
is called a *test fixture*.

[!code-csharp[OrdinaryTest](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#OrdinaryTest)]

The test follows the common **Arrange, Act, Assert** pattern:

- **Arrange** creates the object you want to test, often called the *system under test*.
- **Act** calls the method you want to test.
- **Assert** checks that the result is what you expected. `Assert.That` takes the actual value and a *constraint*
  that describes the expected value, such as `Is.EqualTo(5)`.

If the assertion fails, NUnit reports the test as failed and shows both the expected and the actual value.

## Sharing setup between tests

When several tests need the same starting point, move the common code into a method marked with
[`[SetUp]`](xref:attribute-setup). NUnit runs it before each test in the class, so every test gets a fresh object.

[!code-csharp[OrdinarySetUp](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#OrdinarySetUp)]

Use [`[TearDown]`](xref:attribute-teardown) for cleanup after each test, and
[`[OneTimeSetUp]`](xref:attribute-onetimesetup) for expensive setup that should run only once for the whole class.

## Next steps

- [Data driven tests](xref:datadriventests) run the same test with different inputs.
- [Automating tests](xref:automatingtests) lets NUnit generate the inputs for you.
- [Constraints](xref:constraints) lists everything you can check with `Assert.That`.
- [Attributes](attributes.md) describes all the ways you can mark and control tests.
