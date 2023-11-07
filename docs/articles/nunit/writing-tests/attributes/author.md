---
uid: author-attribute
---

# Author

The **Author** Attribute adds information about the author of the tests. It can be applied to test fixtures and to
tests.

The constructor takes the name of the test author and optionally the author's email address. Author can also be
specified on a TestFixture or Test attribute.

[!code-csharp[AuthorAttributeExample](~/snippets/Snippets.NUnit/Attributes/AuthorAttributeExamples.cs#AuthorAttributeExample)]

> [!NOTE] From NUnit version 3.7, you can have multiple Author attributes per fixture or test. Before version 3.7 you
> could only have one Author attribute  per fixture or test.
