# Towards NUnit Version 4

NUnit 4 have been long in coming, but we now start to see the outline of it.
Along with NUnit 4 we will also change the release cadence, and turn more towards a [Semver](https://semver.org) based versioning scheme.  This means we will try to release a version 4 as soon as we can, and then just move forward with new major releases faster than earlier.

There are some interesting issues around NUnit 4 we would like to point you to.  First of all is the [NUnit 4 planning issue](https://github.com/nunit/nunit/issues/3325).  Then we have the upcoming [release notes page](https://github.com/nunit/docs/blob/62c43cbbd32b8424c974d5ec50d5463a5c4cd621/docs/articles/nunit/release-notes/framework.md), currently as a PR. There are also a [list of issues](https://github.com/nunit/nunit/issues/4431) related to changes in supported frameworks and assert messages.  We have also added a milestone for version 4, so this [list of open issues](https://github.com/nunit/nunit/issues?q=is%3Aopen+is%3Aissue+milestone%3A4.0) could be useful.

**Now to some highlights, and not necessarily in chronological order.**

## Improved assert result messages

The result messages in case of a failure has been improved to include the Assert statement that is used.

Earlier code like:
```cs
    [TestCase(42)]
    public void TestInt(int val)
    {
        Assert.That(val, Is.EqualTo(4));
    }
```
resulted in:
```txt
Message: 
  Expected: 4
  But was:  42
```
Not a very descriptive message. 

In version 4 this is improved to also include the assert statement itself.

The result will then be:
```txt
Message: 
  Assert.That(val, Is.EqualTo(4))
  Expected: 4
  But was:  42
```

This also handles more complex statements, like for the following code:
```cs
 [Test]
    public void TestDouble()
    {
        var sut = new Math();
        Assert.That(sut.Add(4.0, 2.0), Is.EqualTo(42.0).Within(0.1d), "Add double failed");
    }
```
which then results in:
```txt
Message: 
  Add double failed
  Assert.That(sut.Add(4.0, 2.0), Is.EqualTo(42.0).Within(0.1d))
  Expected: 42.0d +/- 0.10000000000000001d
  But was:  6.0d
  Off by:   36.0d
```
Note that the custom message is added before the Assert statement

This becomes even more useful in Multiple Asserts, where there is a list of results from the different asserts, but very little information on which actual assert results in which message.

Given the code:
```cs
[Test]
    public void TestMultiple()
    {
        var x = 2;
        Assert.Multiple(() =>
        {
            Assert.That(x*2, Is.EqualTo(42));
            Assert.That(x*1+40, Is.EqualTo(42));
            Assert.That(x*3+42, Is.EqualTo(42));
        });
    }
```
which in version 3 results in:
```txt
Message: 
Multiple failures or warnings in test:
  1)   Expected: 42
  But was:  4

  2)   Expected: 42
  But was:  48
```
This is with only 3 asserts hard to figure out, but with version 4 we get:
```txt
Message: 
Multiple failures or warnings in test:
  1)   Assert.That(x*2, Is.EqualTo(42))
  Expected: 42
  But was:  4

  2)   Assert.That(x*3+42, Is.EqualTo(42))
  Expected: 42
  But was:  48
```

### Breaking change
* There is a breaking change with respect to the assert messages.  The format with params args are no longer supported.  If you need to create a message like that, you need to convert it to an interpolated string.
  
### Developer details
The improved result messages have been implemented using the new [CallerArgumentExpression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/caller-argument-expression) together with using a [FormattableString](https://learn.microsoft.com/en-us/dotnet/api/system.formattablestring?view=net-6.0) as the class for the message.  

## Nullability
Version 4 have implemented stricter nullability all over.  We still have some places that needs to be fixed up, but all in all, it should be conformant to the nullability requirements.  See [3376](https://github.com/nunit/nunit/issues/3376) for details.

This has also, together with the improved assert messages, caused null values to be no longer allowed for messages. Code like the below will not compile (resulting in [CS0121](https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs0121?f1url=%3FappId%3Droslyn%26k%3Dk(CS0121))):
![](AssertNull.png)

## Platform support

The lowest framework platforms support in Version 4 are **.net framework 4.6.2** and **.net 6.0**.

## Classic/Legacy asserts

The classic/legacy asserts, like `Assert.AreEqual`, have now been moved into its own project, and may be released as a separate package.  They are now in the namespace `NUnit.Framework.Classic`. 
In the early V4 alpha version they will be delivered in the standard NUnit package.

This means that the default assert library going forward will be the `Constraint based` asserts.



