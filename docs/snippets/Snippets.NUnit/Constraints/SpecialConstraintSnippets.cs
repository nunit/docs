using NUnit.Framework;

#pragma warning disable NUnit2045

namespace Snippets.NUnit.Constraints;

public class SpecialConstraintSnippets
{
    #region MultipleOfConstraintExamples
    [Test]
    public void MultipleOfConstraint_Examples()
    {
        // Test for multiples
        Assert.That(12, Is.MultipleOf(3));    // 12 is a multiple of 3
        Assert.That(12, Is.MultipleOf(4));    // 12 is a multiple of 4
        Assert.That(12, Is.Not.MultipleOf(5)); // 12 is not a multiple of 5

        // Even numbers
        Assert.That(0, Is.Even);
        Assert.That(2, Is.Even);
        Assert.That(100, Is.Even);
        Assert.That(-4, Is.Even);
        Assert.That(3, Is.Not.Even);

        // Odd numbers
        Assert.That(1, Is.Odd);
        Assert.That(3, Is.Odd);
        Assert.That(99, Is.Odd);
        Assert.That(-7, Is.Odd);
        Assert.That(4, Is.Not.Odd);
    }
    #endregion

    #region NaNConstraintExamples
    [Test]
    public void NaNConstraint_Examples()
    {
        // NaN results from undefined operations
        Assert.That(double.NaN, Is.NaN);
        Assert.That(float.NaN, Is.NaN);
        Assert.That(0.0 / 0.0, Is.NaN);
        Assert.That(Math.Sqrt(-1), Is.NaN);

        // Regular numbers are not NaN
        Assert.That(42.0, Is.Not.NaN);
        Assert.That(double.PositiveInfinity, Is.Not.NaN);
        Assert.That(double.NegativeInfinity, Is.Not.NaN);
    }
    #endregion

    #region AnyOfConstraintExamples
    [Test]
    public void AnyOfConstraint_Examples()
    {
        // Value must equal one of the options
        Assert.That(42, Is.AnyOf(0, -1, 42, 100));
        Assert.That("red", Is.AnyOf("red", "green", "blue"));

        // With string comparison modifiers
        Assert.That("RED", Is.AnyOf("red", "green", "blue").IgnoreCase);

        // Negative test
        Assert.That("yellow", Is.Not.AnyOf("red", "green", "blue"));
    }
    #endregion

    #region ThrowsNothingConstraintExamples
    [Test]
    public void ThrowsNothingConstraint_Examples()
    {
        // Test that method completes without throwing
        Assert.That(() => Add(1, 2), Throws.Nothing);

        // Verify cleanup doesn't throw
        var resource = new DisposableResource();
        Assert.That(() => resource.Dispose(), Throws.Nothing);
    }

    private static int Add(int a, int b) => a + b;

    private class DisposableResource : IDisposable
    {
        public void Dispose() { }
    }
    #endregion

    #region DelayedConstraintExamples
    [Test]
    public void DelayedConstraint_Examples()
    {
        var flag = false;
        Task.Run(async () =>
        {
            await Task.Delay(50);
            flag = true;
        });

        // Poll until condition is true (or timeout)
        Assert.That(() => flag, Is.True.After(500).MilliSeconds.PollEvery(50).MilliSeconds);
    }
    #endregion

    #region DelayedConstraintFluentExamples
    [Test]
    public void DelayedConstraint_Fluent_Examples()
    {
        var counter = 0;
        Task.Run(async () =>
        {
            await Task.Delay(50);
            counter = 10;
        });

        // Fluent time syntax
        Assert.That(() => counter, Is.GreaterThan(0).After(1).Seconds.PollEvery(100).MilliSeconds);
    }
    #endregion

    #region PropertyConstraintExamples
    public class Person
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
    }

    [Test]
    public void PropertyConstraint_Examples()
    {
        // Test property values
        Assert.That("Hello", Has.Property("Length").EqualTo(5));
        Assert.That(new int[] { 1, 2, 3 }, Has.Property("Length").EqualTo(3));

        // Common properties have shortcuts
        Assert.That("Hello", Has.Length.EqualTo(5));
        Assert.That(new List<int> { 1, 2, 3 }, Has.Count.EqualTo(3));

        // Exception properties
        var ex = new InvalidOperationException("Test error", new ArgumentException());
        Assert.That(ex, Has.Message.EqualTo("Test error"));
        Assert.That(ex, Has.InnerException.InstanceOf<ArgumentException>());

        // Custom object properties
        var person = new Person { Name = "Alice", Age = 30 };
        Assert.That(person, Has.Property("Name").EqualTo("Alice"));
        Assert.That(person, Has.Property("Age").GreaterThan(18));
    }
    #endregion

    #region PropertyExistsConstraintExamples
    [Test]
    public void PropertyExistsConstraint_Examples()
    {
        // Check that property exists
        Assert.That("Hello", Has.Property("Length"));
        Assert.That(new List<int>(), Has.Property("Count"));

        // Negative test
        Assert.That("Hello", Has.No.Property("NonExistent"));

        // Check that multiple properties exist
        var person = new Person { Name = "Alice", Age = 30 };
        Assert.That(person, Has.Property("Name").And.Property("Age"));
    }
    #endregion

    #region SameAsConstraintExamples
    [Test]
    public void SameAsConstraint_Examples()
    {
        var obj1 = new object();
        var obj2 = obj1;
        var obj3 = new object();

        // Same reference
        Assert.That(obj2, Is.SameAs(obj1));

        // Different objects (even if equal)
        Assert.That(obj3, Is.Not.SameAs(obj1));

        // String interning example
        var str1 = "Hello";
        var str2 = "Hello";
        Assert.That(str2, Is.SameAs(str1));  // Interned strings are same reference
    }
    #endregion

    #region FileOrDirectoryExistsConstraintExamples
    [Test]
    public void FileOrDirectoryExistsConstraint_Examples()
    {
        var tempFile = Path.GetTempFileName();
        var tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempDir);

        try
        {
            // Test file or directory existence
            Assert.That(tempFile, Does.Exist);
            Assert.That(tempDir, Does.Exist);
            Assert.That("nonexistent.txt", Does.Not.Exist);

            // Test with FileInfo/DirectoryInfo
            Assert.That(new FileInfo(tempFile), Does.Exist);
            Assert.That(new DirectoryInfo(tempDir), Does.Exist);
        }
        finally
        {
            File.Delete(tempFile);
            Directory.Delete(tempDir);
        }
    }
    #endregion

    #region EmptyDirectoryConstraintExamples
    [Test]
    public void EmptyDirectoryConstraint_Examples()
    {
        var tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempDir);

        try
        {
            // Test directory is empty
            Assert.That(new DirectoryInfo(tempDir), Is.Empty);

            // Add a file and verify not empty
            File.WriteAllText(Path.Combine(tempDir, "test.txt"), "content");
            Assert.That(new DirectoryInfo(tempDir), Is.Not.Empty);
        }
        finally
        {
            Directory.Delete(tempDir, recursive: true);
        }
    }
    #endregion
}
