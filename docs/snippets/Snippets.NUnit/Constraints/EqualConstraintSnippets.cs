using NUnit.Framework;

#pragma warning disable CA1822
#pragma warning disable NUnit2045

namespace Snippets.NUnit.Constraints;

public class EqualConstraintSnippets
{
    #region EqualConstraintIgnoreWhiteSpace
    [Test, Explicit("Fails on purpose to show the IgnoreWhiteSpace failure message")]
    public void CompareJsonIgnoringWhiteSpace()
    {
        const string prettyJson = """
            "persons":[
              {
                "name": "John",
                "surname": "Smith"
              },
              {
                "name": "Jane",
                "surname": "Doe"
              }
            ]
            """;

        const string condensedJson = """
            "persons":[{"name":"John","surname":"Smith",},{"name": "Jane","surname": "Doe"}]
            """;

        Assert.That(condensedJson, Is.EqualTo(prettyJson).IgnoreWhiteSpace);
    }
    #endregion

    [Test]
    public void IgnoreWhiteSpaceFailureMessageShowsBothCarets()
    {
        const string prettyJson = """
            "persons":[
              {
                "name": "John",
                "surname": "Smith"
              }
            ]
            """;
        const string condensedJson = """
            "persons":[{"name":"John","surname":"Smith",}]
            """;

        Assert.That(() => Assert.That(condensedJson, Is.EqualTo(prettyJson).IgnoreWhiteSpace),
            Throws.TypeOf<AssertionException>()
                .With.Message.Contains("ignoring white-space")
                .And.Message.Contains("^"));

        // The same strings pass once the stray comma is removed.
        Assert.That(condensedJson.Replace(",}", "}"), Is.EqualTo(prettyJson).IgnoreWhiteSpace);
    }

    #region EqualConstraintDateTime
    [Test]
    public void CompareDateTimesWithTolerance()
    {
        DateTime now = DateTime.Now;
        DateTime later = now + TimeSpan.FromHours(1.0);

        Assert.That(now, Is.EqualTo(now));
        Assert.That(later, Is.EqualTo(now).Within(TimeSpan.FromHours(3.0)));
        Assert.That(later, Is.EqualTo(now).Within(3).Hours);
    }
    #endregion

    #region EqualConstraintArrays
    [Test]
    public void CompareArraysAndCollections()
    {
        int[] i3 = [1, 2, 3];
        double[] d3 = [1.0, 2.0, 3.0];
        int[] iunequal = [1, 3, 2];
        Assert.That(i3, Is.EqualTo(d3));
        Assert.That(i3, Is.Not.EqualTo(iunequal));

        int[,] array2x2 = { { 1, 2 }, { 3, 4 } };
        int[] array4 = [1, 2, 3, 4];
        Assert.That(array2x2, Is.Not.EqualTo(array4));
        Assert.That(array2x2, Is.EqualTo(array4).AsCollection);
    }
    #endregion

    #region EqualConstraintTuples
    [Test]
    public void CompareTuples()
    {
        // Members are compared one by one, with the same rules as for standalone values
        Assert.That(("Hello", 3), Is.EqualTo(("Hello", 3)));
        Assert.That(Tuple.Create(1, 2, 3), Is.EqualTo(Tuple.Create(1.0, 2.0, 3.0)));

        // A tolerance is applied to the members that can take one; the string is compared exactly
        Assert.That(("Hello", 3), Is.EqualTo(("Hello", 4)).Within(1));

        // Tuples with a different number of members are never equal
        Assert.That(("Hello", 3), Is.Not.EqualTo(("Hello", 3, 1)));
    }
    #endregion

    #region EqualConstraintClasses
    private sealed class Person
    {
        public Person(string name, int yearOfBirth)
        {
            Name = name;
            YearOfBirth = yearOfBirth;
        }

        public string Name { get; }
        public int YearOfBirth { get; }
    }

    [Test, Explicit("Fails on purpose: the two instances are different references")]
    public void ComparePersons()
    {
        var person1 = new Person("Charlie", 1985);
        var person2 = new Person("Charlie", 1985);

        Assert.That(person2, Is.EqualTo(person1));
    }
    #endregion

    [Test]
    public void ComparePersonsFailsWithoutPropertiesComparer()
    {
        var person1 = new Person("Charlie", 1985);
        var person2 = new Person("Charlie", 1985);

        Assert.That(() => Assert.That(person2, Is.EqualTo(person1)), Throws.TypeOf<AssertionException>());
        Assert.That(person2, Is.EqualTo(person1).UsingPropertiesComparer());
    }

    #region EqualConstraintUsingComparer
    private sealed class ListOfIntComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int>? x, List<int>? y)
        {
            if (x is null || y is null)
                return x is null && y is null;

            return x.SequenceEqual(y);
        }

        public int GetHashCode(List<int> obj) => obj.Count;
    }

    [Test]
    public void CompareListsWithUserSpecifiedComparer()
    {
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 1, 2, 3 };
        var myComparer = new ListOfIntComparer();

        Assert.That(list1, Is.EqualTo(list2).Using(myComparer));
    }
    #endregion
}

public class PropertiesComparerDifferentTypes
{
    #region PropertiesComparerAllowDifferentTypes
    private record struct PersonDto(string Name, int YearOfBirth);
    private record struct PersonEntity(string Name, int YearOfBirth);

    [Test]
    public void CompareDifferentTypes()
    {
        var dto = new PersonDto("Hejlsberg", 1960);
        var entity = new PersonEntity("Hejlsberg", 1960);

        Assert.That(dto, Is.EqualTo(entity)
                           .UsingPropertiesComparer(o => o.AllowDifferentTypes()));
    }
    #endregion
}

public class PropertiesComparerCommonProperties
{
    #region PropertiesComparerCommonProperties
    private record struct PersonDto(string Name, int YearOfBirth);
    private record struct PersonEntity(Guid Id, string Name, int YearOfBirth);

    [Test]
    public void CompareDifferentTypesWithExcessFields()
    {
        var dto = new PersonDto("Hejlsberg", 1960);
        var entity = new PersonEntity(Guid.NewGuid(), "Hejlsberg", 1960);

        Assert.That(dto, Is.EqualTo(entity)
                           .UsingPropertiesComparer(o => o.CompareOnlyCommonProperties()));
    }
    #endregion
}

public class PropertiesComparerUsingProperties
{
    #region PropertiesComparerUsing
    private record struct PersonDto(string Name, int YearOfBirth);

    [Test]
    public void CompareOnNameOnly()
    {
        var dto1 = new PersonDto("Hejlsberg", 1960);
        var dto2 = new PersonDto("Hejlsberg", 1966);

        // Specify name as a string
        Assert.That(dto2, Is.EqualTo(dto1).UsingPropertiesComparer(
            o => o.Using("Name")));

        // Specify name as an expression
        Assert.That(dto2, Is.EqualTo(dto1).UsingPropertiesComparer<PersonDto>(
            o => o.Using(x => x.Name)));
    }
    #endregion
}

public class PropertiesComparerExcludingProperties
{
    #region PropertiesComparerExcluding
    private record struct PersonEntity(Guid Id, string Name, int YearOfBirth);

    [Test]
    public void CompareExcludingId()
    {
        var entity1 = new PersonEntity(Guid.NewGuid(), "Hejlsberg", 1960);
        var entity2 = new PersonEntity(Guid.NewGuid(), "Hejlsberg", 1960);

        Assert.That(entity2, Is.EqualTo(entity1).UsingPropertiesComparer(
            o => o.Excluding(nameof(PersonEntity.Id))));
        Assert.That(entity2, Is.EqualTo(entity1).UsingPropertiesComparer<PersonEntity>(
            o => o.Excluding(x => x.Id)));
    }
    #endregion
}

public class PropertiesComparerMappingNames
{
    #region PropertiesComparerMapNames
    private record struct PersonDto(string Name, int YearOfBirth);
    private record struct PersonEntity(string LastName, int BirthYear);

    [Test]
    public void CompareDifferentTypesWithDifferentPropertyNames()
    {
        var dto = new PersonDto("Hejlsberg", 1960);
        var entity = new PersonEntity("Hejlsberg", 1960);

        Assert.That(dto, Is.EqualTo(entity).UsingPropertiesComparer(
            o => o.Map(nameof(PersonEntity.LastName), nameof(PersonDto.Name))
                  .Map(nameof(PersonEntity.BirthYear), nameof(PersonDto.YearOfBirth))));

        Assert.That(dto, Is.EqualTo(entity).UsingPropertiesComparer<PersonEntity>(
            o => o.Map<PersonDto>(entity => entity.LastName, dto => dto.Name)
                  .Map<PersonDto>(entity => entity.BirthYear, dto => dto.YearOfBirth)));
    }
    #endregion
}

public class PropertiesComparerMappingValues
{
    #region PropertiesComparerMapValues
    private sealed record Address(string House, string Street, string City, string PostalCode, string Country);
    private sealed record USAddress(string House, string Street, string City, string ZipCode);

    [Test]
    public void CompareMatchingDifferentAddresses()
    {
        var address = new Address("10", "CSI", "Las Vegas", "89030", "U.S.A.");
        var usAddress = new USAddress("10", "CSI", "Las Vegas", "89030");

        // We can supply a Value for the missing property 'Country'
        Assert.That(usAddress, Is.EqualTo(address).UsingPropertiesComparer<Address>(
            o => o.Map<Address, USAddress>(world => world.PostalCode, usa => usa.ZipCode)
                  .Map<Address>(world => world.Country, "U.S.A.")));
    }
    #endregion
}

public class PropertiesComparerNestedTypes
{
    #region PropertiesComparerNested
    private sealed record Address(string House, string Street, string City, string AreaCode, string Country);
    private sealed record Person(string Name, Address Address);

    private sealed record USAddress(string House, string Street, string City, string ZipCode);
    private sealed record USPerson(string Name, USAddress USAddress);

    [Test, Explicit("Fails on purpose to show how mapped properties appear in the failure message")]
    public void CompareMismatchedDifferentTypes()
    {
        var person = new Person("John Doe", new Address("10", "CSI", "Las Vegas", "89030", "U.S.A."));
        var usPerson = new USPerson("John Doe", new USAddress("10", "CSI", "Las Vegas", "89031"));

        Assert.That(usPerson, Is.EqualTo(person).UsingPropertiesComparer<Person>(
            o => o.Map<Person, USPerson>(x => x.Address, y => y.USAddress)
                  .Map<Address, USAddress>(x => x.AreaCode, y => y.ZipCode)
                  .Map<Address>(x => x.Country, "U.S.A.")));
    }
    #endregion

    [Test]
    public void MismatchedNestedTypesReportTheMappedProperty()
    {
        var person = new Person("John Doe", new Address("10", "CSI", "Las Vegas", "89030", "U.S.A."));
        var usPerson = new USPerson("John Doe", new USAddress("10", "CSI", "Las Vegas", "89031"));

        Assert.That(() => Assert.That(usPerson, Is.EqualTo(person).UsingPropertiesComparer<Person>(
                o => o.Map<Person, USPerson>(x => x.Address, y => y.USAddress)
                      .Map<Address, USAddress>(x => x.AreaCode, y => y.ZipCode)
                      .Map<Address>(x => x.Country, "U.S.A."))),
            Throws.TypeOf<AssertionException>()
                .With.Message.Contains("Values differ at property Person.Address => USPerson.USAddress")
                .And.Message.Contains("Values differ at property Address.AreaCode => USAddress.ZipCode"));
    }

    [Test]
    public void MatchingNestedTypesPass()
    {
        var person = new Person("John Doe", new Address("10", "CSI", "Las Vegas", "89030", "U.S.A."));
        var usPerson = new USPerson("John Doe", new USAddress("10", "CSI", "Las Vegas", "89030"));

        Assert.That(usPerson, Is.EqualTo(person).UsingPropertiesComparer<Person>(
            o => o.Map<Person, USPerson>(x => x.Address, y => y.USAddress)
                  .Map<Address, USAddress>(x => x.AreaCode, y => y.ZipCode)
                  .Map<Address>(x => x.Country, "U.S.A.")));
    }
}
