---
uid: automatingtests
---

# Automating Tests

With [data driven tests](xref:datadriventests) you write out every test case yourself. NUnit can also do that work for
you: you describe the possible values for each parameter, and NUnit generates the test cases. This is a good way to
cover many inputs with very little code.

## Every combination with [Values]

Put [`[Values]`](xref:attribute-values) on each parameter. By default NUnit runs the test once for every combination
of the values, so the example below produces 3 &times; 2 = 6 test cases.

[!code-csharp[AutomatingCombinatorial](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#AutomatingCombinatorial)]

For `bool` and `enum` parameters you can leave out the values: `[Values] bool flag` gives you both `true` and
`false`.

## A range of numbers with [Range]

Use [`[Range]`](xref:attribute-range) to generate numbers from a start value to an end value, with an optional step.
This example runs with -10, -5, 0, 5 and 10.

[!code-csharp[AutomatingRange](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#AutomatingRange)]

## Random numbers with [Random]

Use [`[Random]`](xref:attribute-random) to have NUnit pick values for you. This is useful for checking rules that must
hold for *any* input, such as `a + b == b + a`. NUnit records the random seed it used in the test results, so a failing run can be reproduced.

[!code-csharp[AutomatingRandom](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#AutomatingRandom)]

## Keeping the number of tests down

Combinations grow fast: three parameters with ten values each give a thousand test cases. NUnit has two attributes that
change how the values are combined:

- [`[Pairwise]`](xref:attribute-pairwise) generates just enough cases so that every *pair* of values is tested
  together at least once. Most bugs are caused by one value or by two values together, so this finds most of them
  with far fewer tests.
- [`[Sequential]`](xref:attribute-sequential) uses the first value of each parameter together, then the second values,
  and so on, instead of all combinations.

[!code-csharp[AutomatingPairwise](~/snippets/Snippets.NUnit/WritingTestsGuideExamples.cs#AutomatingPairwise)]

## Theories

A [`[Theory]`](xref:attribute-theory) goes one step further: you state something that must be true for all data
points, and NUnit tries it with every suitable value you have marked with [`[Datapoint]`](xref:attribute-datapoint)
or [`[DatapointSource]`](xref:attribute-datapointsource).

## Next steps

- [Combinatorial](xref:attribute-combinatorial), [Pairwise](xref:attribute-pairwise) and
  [Sequential](xref:attribute-sequential) describe the combining strategies in detail.
- [Parameterized tests](xref:parameterizedtests) describes all the details of how parameterized tests work.
