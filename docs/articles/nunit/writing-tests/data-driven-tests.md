---
uid: datadriventests
---

# Data Driven Tests

A data driven test runs the same test code several times, with different input data each time. Instead of copying a
test to try another value, you write the test once and give NUnit the list of values. Each set of values shows up as
its own test in the test explorer, so you can see exactly which case failed.

NUnit calls these *parameterized tests*: the test method takes parameters, and the data is supplied from outside.

## Inline data with [TestCase]

Use [`[TestCase]`](xref:attribute-testcase) when you have a handful of cases that are easy to write out. Each
attribute is one test case, and its arguments are passed to the method parameters in order.

[!code-csharp[DataDrivenTestCase](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#DataDrivenTestCase)]

If the test simply computes a value, you can let the method return it and put the expected value in the attribute
with `ExpectedResult`:

[!code-csharp[DataDrivenExpectedResult](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#DataDrivenExpectedResult)]

## Data from code with [TestCaseSource]

Use [`[TestCaseSource]`](xref:attribute-testcasesource) when the data is larger, needs code to build, or comes from
somewhere else, such as a file. Point the attribute at a static method, property or field that returns the cases.

[!code-csharp[DataDrivenTestCaseSource](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#DataDrivenTestCaseSource)]

Returning [`TestCaseData`](xref:testcasedata) objects is optional, but it lets you give each case a readable name, a
description, categories and more.

## Data for a single parameter with [ValueSource]

Use [`[ValueSource]`](xref:attribute-valuesource) when you want to supply the values for one parameter from a
reusable list.

[!code-csharp[DataDrivenValueSource](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#DataDrivenValueSource)]

## Running a whole class with different data

You can also pass data to the test class itself. Every test in the class then runs once for each set of arguments given
with [`[TestFixture]`](xref:attribute-testfixture).

[!code-csharp[DataDrivenFixture](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#DataDrivenFixture)]

For data built in code, use [`[TestFixtureSource]`](xref:attribute-testfixturesource) and
[`TestFixtureData`](xref:testfixturedata).

## Next steps

- [Automating tests](xref:automatingtests) lets NUnit generate combinations of values for you.
- [Parameterized tests](xref:parameterizedtests) describes all the details of how parameterized tests work.
