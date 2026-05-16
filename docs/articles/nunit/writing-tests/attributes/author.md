---
uid: attribute-author
---

# Author

`AuthorAttribute` adds information about the author of tests. This metadata can be used by test runners and reporting tools to track test ownership and contact information.

## Constructors

```csharp
AuthorAttribute(string name)
AuthorAttribute(string name, string email)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `name` | `string` | The name of the test author. |
| `email` | `string` | The email address of the author. When provided, stored as `"name <email>"`. |

## Applies To

| Test Methods | Test Fixtures (Classes) | Assembly |
|--------------|--------------------------|----------|
| ✅ | ✅ | ✅ |

## Alternative Syntax

`Author` can also be specified as a named parameter on `[TestFixture]` or `[Test]` attributes (name only, no email):

```csharp
[TestFixture(Author = "Jane Doe")]
[Test(Author = "Joe Developer")]
```

## Example

[!code-csharp[AuthorAttributeExample](~/snippets/Snippets.NUnit/Attributes/AuthorAttributeExamples.cs#AuthorAttributeExample)]

## Notes

1. This attribute inherits from `PropertyAttribute` and sets the `Author` property.
2. Multiple `Author` attributes can be applied to the same fixture or test (since **NUnit 3.7**).
3. Prior to NUnit 3.7, only one Author attribute was allowed per fixture or test.
4. When using the named parameter syntax (`Author = "name"`), only the name can be specified, not the email.

## See Also

* [Property Attribute](xref:attribute-property)
* [Description Attribute](xref:attribute-description)
* [TestOf Attribute](xref:attribute-testof)
