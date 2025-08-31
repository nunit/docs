# Description

The Description attribute is used to apply descriptive text to a Test, TestFixture or Assembly. The text appears in the
XML output file.

## Example

[!code-csharp[DescriptionTestExample](~/snippets/Snippets.NUnit/AttributeExamples.cs#DescriptionTestExample)]

> [!NOTE]
> The Test and TestFixture attributes continue to support an optional Description property. The Description
> attribute should be used for new applications. If both are used, the Description attribute takes precedence.
