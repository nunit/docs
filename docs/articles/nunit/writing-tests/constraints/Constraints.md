---
uid: constraints
---

# Constraints

This page lists all the constraints available in NUnit.

* [Alphabetical List of Constraints](#alphabetical-list-of-constraints)
* [Constraints by Category](#constraints-by-category)

For additional topics, see:

* [Async Constraint Support](AsyncConstraints.md) - Using constraints with async code
* [Contains Helper](ContainsHelper.md) - The Contains.* syntax helper

## Alphabetical List of Constraints

| Constraint Name                                                                         | Example                                                                                                    |
| --------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------- |
| [AllItemsConstraint](AllItemsConstraint.md)                                             | `Assert.That(numbers, Is.All.GreaterThan(0));`                                                             |
| [AndConstraint](AndConstraint.md)                                                       | `Assert.That(value, Is.GreaterThan(0).And.LessThan(100));`                                                 |
| [AnyOfConstraint](AnyOfConstraint.md)                                                   | `Assert.That(42, Is.AnyOf(0, -1, 42, 100));`                                                               |
| [AssignableFromConstraint](AssignableFromConstraint.md)                                 | `Assert.That("Hello", Is.AssignableFrom<string>());`                                                       |
| [AssignableToConstraint](AssignableToConstraint.md)                                     | `Assert.That("Hello", Is.AssignableTo<object>());`                                                         |
| [AttributeConstraint](AttributeConstraint.md)                                           | `Assert.That(typeof(MyFixture), Has.Attribute<CategoryAttribute>().Property("Name").EqualTo("Database"));` |
| [AttributeExistsConstraint](AttributeExistsConstraint.md)                               | `Assert.That(typeof(MyClass), Has.Attribute<SerializableAttribute>());`                                    |
| [BinarySerializableConstraint](BinarySerializableConstraint.md)                         | `Assert.That(someObject, Is.BinarySerializable);`                                                          |
| [CollectionEquivalentConstraint](CollectionEquivalentConstraint.md)                     | `Assert.That(new[] { 3, 2, 1 }, Is.EquivalentTo(new[] { 1, 2, 3 }));`                                      |
| [CollectionOrderedConstraint](CollectionOrderedConstraint.md)                           | `Assert.That(new[] { 1, 2, 3 }, Is.Ordered);`                                                              |
| [CollectionSubsetConstraint](CollectionSubsetConstraint.md)                             | `Assert.That(new[] { 1, 3 }, Is.SubsetOf(new[] { 1, 2, 3 }));`                                             |
| [CollectionSupersetConstraint](CollectionSupersetConstraint.md)                         | `Assert.That(new[] { 1, 2, 3 }, Is.SupersetOf(new[] { 1, 3 }));`                                           |
| [ContainsConstraint](ContainsConstraint.md)                                             | `Assert.That("Hello World", Does.Contain("World"));`                                                       |
| [DefaultConstraint](DefaultConstraint.md)                                               | `Assert.That(default(DateTime), Is.Default);`                                                              |
| [DelayedConstraint](DelayedConstraint.md)                                               | `Assert.That(() => flag, Is.True.After(500).MilliSeconds.PollEvery(50).MilliSeconds);`                     |
| [DictionaryContainsKeyConstraint](DictionaryContainsKeyConstraint.md)                   | `Assert.That(dictionary, Does.ContainKey("Alice"));`                                                       |
| [DictionaryContainsKeyValuePairConstraint](DictionaryContainsKeyValuePairConstraint.md) | `Assert.That(dictionary, Does.ContainKey("Hello").WithValue("World"));`                                    |
| [DictionaryContainsValueConstraint](DictionaryContainsValueConstraint.md)               | `Assert.That(dictionary, Does.ContainValue(85));`                                                          |
| [EmptyCollectionConstraint](EmptyCollectionConstraint.md)                               | `Assert.That(new List<string>(), Is.Empty);`                                                               |
| [EmptyConstraint](EmptyConstraint.md)                                                   | `Assert.That(value, Is.Empty);`                                                                            |
| [EmptyDirectoryConstraint](EmptyDirectoryConstraint.md)                                 | `Assert.That(new DirectoryInfo(path), Is.Empty);`                                                          |
| [EmptyStringConstraint](EmptyStringConstraint.md)                                       | `Assert.That("", Is.Empty);`                                                                               |
| [EndsWithConstraint](EndsWithConstraint.md)                                             | `Assert.That("Hello World!", Does.EndWith("World!"));`                                                     |
| [EqualConstraint](EqualConstraint.md)                                                   | `Assert.That(2 + 2, Is.EqualTo(4));`                                                                       |
| [ExactCountConstraint](ExactCountConstraint.md)                                         | `Assert.That(numbers, Has.Exactly(2).GreaterThan(3));`                                                     |
| [ExactTypeConstraint](ExactTypeConstraint.md)                                           | `Assert.That("Hello", Is.TypeOf<string>());`                                                               |
| [FalseConstraint](FalseConstraint.md)                                                   | `Assert.That(2 + 2 == 5, Is.False);`                                                                       |
| [FileOrDirectoryExistsConstraint](FileOrDirectoryExistsConstraint.md)                   | `Assert.That(new FileInfo(path), Does.Exist);`                                                             |
| [GreaterThanConstraint](GreaterThanConstraint.md)                                       | `Assert.That(7, Is.GreaterThan(3));`                                                                       |
| [GreaterThanOrEqualConstraint](GreaterThanOrEqualConstraint.md)                         | `Assert.That(7, Is.GreaterThanOrEqualTo(7));`                                                              |
| [InstanceOfTypeConstraint](InstanceOfTypeConstraint.md)                                 | `Assert.That("Hello", Is.InstanceOf<object>());`                                                           |
| [LessThanConstraint](LessThanConstraint.md)                                             | `Assert.That(3, Is.LessThan(7));`                                                                          |
| [LessThanOrEqualConstraint](LessThanOrEqualConstraint.md)                               | `Assert.That(3, Is.LessThanOrEqualTo(7));`                                                                 |
| [MultipleOfConstraint](MultipleOfConstraint.md)                                         | `Assert.That(12, Is.MultipleOf(3));`                                                                       |
| [NaNConstraint](NaNConstraint.md)                                                       | `Assert.That(0.0 / 0.0, Is.NaN);`                                                                          |
| [NoItemConstraint](NoItemConstraint.md)                                                 | `Assert.That(numbers, Has.None.LessThan(0));`                                                              |
| [NotConstraint](NotConstraint.md)                                                       | `Assert.That(42, Is.Not.EqualTo(0));`                                                                      |
| [NullConstraint](NullConstraint.md)                                                     | `Assert.That(obj, Is.Null);`                                                                               |
| [OrConstraint](OrConstraint.md)                                                         | `Assert.That(value, Is.LessThan(10).Or.GreaterThan(40));`                                                  |
| [PropertyConstraint](PropertyConstraint.md)                                             | `Assert.That(person, Has.Property("Age").GreaterThan(18));`                                                |
| [PropertyExistsConstraint](PropertyExistsConstraint.md)                                 | `Assert.That("Hello", Has.Property("Length"));`                                                            |
| [RangeConstraint](RangeConstraint.md)                                                   | `Assert.That(5, Is.InRange(1, 10));`                                                                       |
| [RegexConstraint](RegexConstraint.md)                                                   | `Assert.That("555-123-4567", Does.Match(@"^\d{3}-\d{3}-\d{4}$"));`                                         |
| [ReusableConstraint](ReusableConstraint.md)                                             | `ReusableConstraint myConstraint = Is.Not.Null;`                                                           |
| [SameAsConstraint](SameAsConstraint.md)                                                 | `Assert.That(obj2, Is.SameAs(obj1));`                                                                      |
| [SamePathConstraint](SamePathConstraint.md)                                             | `Assert.That("/folder1/./junk/../folder2", Is.SamePath("/folder1/folder2"));`                              |
| [SamePathOrUnderConstraint](SamePathOrUnderConstraint.md)                               | `Assert.That("/folder1/folder2/folder3", Is.SamePathOrUnder("/folder1/folder2"));`                         |
| [SomeItemsConstraint](SomeItemsConstraint.md)                                           | `Assert.That(numbers, Has.Some.GreaterThan(3));`                                                           |
| [StartsWithConstraint](StartsWithConstraint.md)                                         | `Assert.That("Hello World!", Does.StartWith("Hello"));`                                                    |
| [SubPathConstraint](SubPathConstraint.md)                                               | `Assert.That("/folder1/folder2", Is.SubPathOf("/folder1/"));`                                              |
| [SubstringConstraint](SubstringConstraint.md)                                           | `Assert.That("Hello World!", Does.Contain("lo Wor"));`                                                     |
| [ThrowsConstraint](ThrowsConstraint.md)                                                 | `Assert.That(() => int.Parse("abc"), Throws.TypeOf<FormatException>());`                                   |
| [ThrowsNothingConstraint](ThrowsNothingConstraint.md)                                   | `Assert.That(() => Add(1, 2), Throws.Nothing);`                                                            |
| [TrueConstraint](TrueConstraint.md)                                                     | `Assert.That(2 + 2 == 4, Is.True);`                                                                        |
| [UniqueItemsConstraint](UniqueItemsConstraint.md)                                       | `Assert.That(new[] { 1, 2, 3 }, Is.Unique);`                                                               |
| [WhiteSpaceConstraint](WhiteSpaceConstraint.md)                                         | `Assert.That(" ", Is.WhiteSpace);`                                                                         |
| [XmlSerializableConstraint](XmlSerializableConstraint.md)                               | `Assert.That(someObject, Is.XmlSerializable);`                                                             |

## Constraints by Category

### Collection Constraints

| Constraint Name                                                                         | Example                                                                 |
| --------------------------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| [AllItemsConstraint](AllItemsConstraint.md)                                             | `Assert.That(numbers, Is.All.GreaterThan(0));`                          |
| [AnyOfConstraint](AnyOfConstraint.md)                                                   | `Assert.That(42, Is.AnyOf(0, -1, 42, 100));`                            |
| [CollectionEquivalentConstraint](CollectionEquivalentConstraint.md)                     | `Assert.That(new[] { 3, 2, 1 }, Is.EquivalentTo(new[] { 1, 2, 3 }));`   |
| [CollectionOrderedConstraint](CollectionOrderedConstraint.md)                           | `Assert.That(new[] { 1, 2, 3 }, Is.Ordered);`                           |
| [CollectionSubsetConstraint](CollectionSubsetConstraint.md)                             | `Assert.That(new[] { 1, 3 }, Is.SubsetOf(new[] { 1, 2, 3 }));`          |
| [CollectionSupersetConstraint](CollectionSupersetConstraint.md)                         | `Assert.That(new[] { 1, 2, 3 }, Is.SupersetOf(new[] { 1, 3 }));`        |
| [DictionaryContainsKeyConstraint](DictionaryContainsKeyConstraint.md)                   | `Assert.That(dictionary, Does.ContainKey("Alice"));`                    |
| [DictionaryContainsKeyValuePairConstraint](DictionaryContainsKeyValuePairConstraint.md) | `Assert.That(dictionary, Does.ContainKey("Hello").WithValue("World"));` |
| [DictionaryContainsValueConstraint](DictionaryContainsValueConstraint.md)               | `Assert.That(dictionary, Does.ContainValue(85));`                       |
| [EmptyCollectionConstraint](EmptyCollectionConstraint.md)                               | `Assert.That(new List<string>(), Is.Empty);`                            |
| [ExactCountConstraint](ExactCountConstraint.md)                                         | `Assert.That(numbers, Has.Exactly(2).GreaterThan(3));`                  |
| [NoItemConstraint](NoItemConstraint.md)                                                 | `Assert.That(numbers, Has.None.LessThan(0));`                           |
| [SomeItemsConstraint](SomeItemsConstraint.md)                                           | `Assert.That(numbers, Has.Some.GreaterThan(3));`                        |
| [UniqueItemsConstraint](UniqueItemsConstraint.md)                                       | `Assert.That(new[] { 1, 2, 3 }, Is.Unique);`                            |

### Comparison Constraints

| Constraint Name                                                 | Example                                       |
| --------------------------------------------------------------- | --------------------------------------------- |
| [GreaterThanConstraint](GreaterThanConstraint.md)               | `Assert.That(7, Is.GreaterThan(3));`          |
| [GreaterThanOrEqualConstraint](GreaterThanOrEqualConstraint.md) | `Assert.That(7, Is.GreaterThanOrEqualTo(7));` |
| [LessThanConstraint](LessThanConstraint.md)                     | `Assert.That(3, Is.LessThan(7));`             |
| [LessThanOrEqualConstraint](LessThanOrEqualConstraint.md)       | `Assert.That(3, Is.LessThanOrEqualTo(7));`    |
| [MultipleOfConstraint](MultipleOfConstraint.md)                 | `Assert.That(12, Is.MultipleOf(3));`          |
| [RangeConstraint](RangeConstraint.md)                           | `Assert.That(5, Is.InRange(1, 10));`          |

### Compound Constraints

| Constraint Name                   | Example                                                    |
| --------------------------------- | ---------------------------------------------------------- |
| [AndConstraint](AndConstraint.md) | `Assert.That(value, Is.GreaterThan(0).And.LessThan(100));` |
| [NotConstraint](NotConstraint.md) | `Assert.That(42, Is.Not.EqualTo(0));`                      |
| [OrConstraint](OrConstraint.md)   | `Assert.That(value, Is.LessThan(10).Or.GreaterThan(40));`  |

### Condition Constraints

| Constraint Name                                 | Example                                       |
| ----------------------------------------------- | --------------------------------------------- |
| [DefaultConstraint](DefaultConstraint.md)       | `Assert.That(default(DateTime), Is.Default);` |
| [EmptyConstraint](EmptyConstraint.md)           | `Assert.That(value, Is.Empty);`               |
| [FalseConstraint](FalseConstraint.md)           | `Assert.That(2 + 2 == 5, Is.False);`          |
| [NaNConstraint](NaNConstraint.md)               | `Assert.That(0.0 / 0.0, Is.NaN);`             |
| [NullConstraint](NullConstraint.md)             | `Assert.That(obj, Is.Null);`                  |
| [TrueConstraint](TrueConstraint.md)             | `Assert.That(2 + 2 == 4, Is.True);`           |
| [WhiteSpaceConstraint](WhiteSpaceConstraint.md) | `Assert.That(" ", Is.WhiteSpace);`            |

### File and Directory Constraints

| Constraint Name                                                       | Example                                                                            |
| --------------------------------------------------------------------- | ---------------------------------------------------------------------------------- |
| [EmptyDirectoryConstraint](EmptyDirectoryConstraint.md)               | `Assert.That(new DirectoryInfo(path), Is.Empty);`                                  |
| [FileOrDirectoryExistsConstraint](FileOrDirectoryExistsConstraint.md) | `Assert.That(new FileInfo(path), Does.Exist);`                                     |
| [SamePathConstraint](SamePathConstraint.md)                           | `Assert.That("/folder1/./junk/../folder2", Is.SamePath("/folder1/folder2"));`      |
| [SamePathOrUnderConstraint](SamePathOrUnderConstraint.md)             | `Assert.That("/folder1/folder2/folder3", Is.SamePathOrUnder("/folder1/folder2"));` |
| [SubPathConstraint](SubPathConstraint.md)                             | `Assert.That("/folder1/folder2", Is.SubPathOf("/folder1/"));`                      |

### String Constraints

| Constraint Name                                   | Example                                                            |
| ------------------------------------------------- | ------------------------------------------------------------------ |
| [ContainsConstraint](ContainsConstraint.md)       | `Assert.That("Hello World", Does.Contain("World"));`               |
| [EmptyStringConstraint](EmptyStringConstraint.md) | `Assert.That("", Is.Empty);`                                       |
| [EndsWithConstraint](EndsWithConstraint.md)       | `Assert.That("Hello World!", Does.EndWith("World!"));`             |
| [RegexConstraint](RegexConstraint.md)             | `Assert.That("555-123-4567", Does.Match(@"^\d{3}-\d{3}-\d{4}$"));` |
| [StartsWithConstraint](StartsWithConstraint.md)   | `Assert.That("Hello World!", Does.StartWith("Hello"));`            |
| [SubstringConstraint](SubstringConstraint.md)     | `Assert.That("Hello World!", Does.Contain("lo Wor"));`             |

### Type Constraints

| Constraint Name                                         | Example                                              |
| ------------------------------------------------------- | ---------------------------------------------------- |
| [AssignableFromConstraint](AssignableFromConstraint.md) | `Assert.That("Hello", Is.AssignableFrom<string>());` |
| [AssignableToConstraint](AssignableToConstraint.md)     | `Assert.That("Hello", Is.AssignableTo<object>());`   |
| [ExactTypeConstraint](ExactTypeConstraint.md)           | `Assert.That("Hello", Is.TypeOf<string>());`         |
| [InstanceOfTypeConstraint](InstanceOfTypeConstraint.md) | `Assert.That("Hello", Is.InstanceOf<object>());`     |

## See also

* [Constraint Model](xref:constraintmodel)
