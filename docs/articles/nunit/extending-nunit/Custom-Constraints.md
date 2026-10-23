---
uid: customconstraints
---

# Custom Constraints

> [!NOTE]
> Page Under Development

You can implement your own custom constraints by creating a class that inherits from the `Constraint` abstract class,
which supports performing a test on an actual value and generating appropriate messages.

## `Constraint` Abstract Class

Implementations must override the one abstract method `ApplyTo<TActual>` which evaluates the previously stored expected
value (if any) against the method's parameter, the actual value. There are also several virtual methods that may be
overridden to change some default behaviors.

The relevant portions of the `Constraint` class are represented below.

```csharp
namespace NUnit.Framework.Constraints
{
    public abstract class Constraint
    {
        protected Constraint(params object[] args) {}
        public abstract ConstraintResult ApplyTo<TActual>(TActual actual);
        /* ... */
        public virtual ConstraintResult ApplyTo<TActual>(Func<TActual> code) {}
        public virtual Task<ConstraintResult> ApplyToAsync<TActual>(Func<Task<TActual>> taskDel) {}
        protected virtual object GetTestObject<TActual>(Func<TActual> code) {}
        public abstract string Description { get; }
        protected virtual string GetStringRepresentation() {}
    }
}
```

> [!NOTE]
> In NUnit 4 and earlier, the delegate overloads took an `ActualValueDelegate<TActual>` instead of a `Func<TActual>`,
> and there was also an `ApplyTo<TActual>(ref TActual actual)` overload. Both were removed in NUnit 5, so custom
> constraints that override these methods must be updated. `Description` was also a virtual property with a
> protected setter; in NUnit 5 it is abstract, so every custom constraint must override it.

## `Constraint` Constructor

The `Constraint` constructor accepts zero or more arguments and saves them to be used in the printed description later.
Constraints like `NullConstraint` or `UniqueItemsConstraint` take no arguments and simply state some condition about the
actual value supplied. Constraints with a single argument usually treat it as the expected value resulting from some
operation. Multiple arguments can be provided where the semantics of the constraint call for it.

## `ApplyTo` Implementation

The `ApplyTo<TActual>(TActual actual)` method must be overridden and provides for the core implementation of the custom
constraint. Whatever logic defines pass or fail of the constraint and actual/expected values goes into the
`ApplyTo<TActual>(TActual actual)` method.

For example, a very naive implementation of a reference equality constraint might look like this:

[!code-csharp[ReferenceEqualsConstraint](~/snippets/Snippets.NUnit/CustomConstraintSyntaxExamples.cs#ReferenceEqualsConstraint)]

The key here is there needs to be some evaluation of the constraint logic, and the return value must be a
`ConstraintResult` or subclass thereof. Custom subclasses of `ConstraintResult` may be used to further customize the
message provided upon failure, as described below.

## `ApplyTo` Overloads

Constraints may be called with a delegate to return the actual value instead of the actual value itself. This serves to
delay evaluation of the value. The default implementation of `ApplyTo<TActual>(Func<TActual> code)` waits
for the delegate to complete if it's an async operation, other immediately calls the delegate if synchronous, and then
calls the abstract `ApplyTo<TActual>(TActual actual)` method with the value.

In NUnit 4 and earlier, another overload also existed, `ApplyTo<TActual>(ref TActual actual)`. The default
implementation dereferenced the value and then called the abstract `ApplyTo<TActual>(TActual actual)` method with the
value. It was not used by NUnit itself, and was removed in NUnit 5.

## `GetTestObject` Optional Override

The default implementation of `ApplyTo<TActual>(Func<TActual> code)` does not simply execute the delegate
but actually calls out to another virtual method, `GetTestObject<TActual>(Func<TActual> code)`. This
method can be overridden to keep the default behavior of `ApplyTo<TActual>(Func<TActual> code)` while
still customizing how the actual value delegate is invoked.

## `Description` Property

This abstract property provides a description of the constraint for messages. Override it to return a constant
for simple constraints, or build the description from the constraint's arguments when more logic is needed.

Here are a few simple examples from built-in constraints.

```csharp
public class FalseConstraint : Constraint
{
    public override string Description => "False";
}

public class NullConstraint : Constraint
{
    public override string Description => "null";
}
```

Here are a few complex examples from built-in constraints.

```csharp
public class AndConstraint : BinaryConstraint
{
    public override string Description
    {
        get { return Left.Description + " and " + Right.Description; }
    }
}

public abstract class PrefixConstraint : Constraint
{
    public override string Description
    {
        get
        {
            return string.Format(
                baseConstraint is EqualConstraint ? "{0} equal to {1}" : "{0} {1}",
                descriptionPrefix,
                baseConstraint.Description);
        }
    }
}
```

## `GetStringRepresentation` Method

NUnit calls the `GetStringRepresentation` method to return a string representation of the constraint, including the
expected value(s). The default implementation returns the lowercase display name of the constraint followed by all
expected values, separated by a space.

For example, a custom constraint `ReferenceEqualsConstraint` with an instance of a custom `MyObject` class as expected
value would result in a default string representation of `<referenceequals MyObject>`.

You can override the initial display name only by setting `DisplayName` in your constructor. This public property cannot
be overridden, but the `Constraint` base class sets it in the base constructor to be the name of the class, minus the
"Constraint" suffix and minus any generic suffixes.

## Custom Constraint Usage Syntax

The examples in this section use the following custom constraint, which checks that a string equals an expected
value:

[!code-csharp[SampleConstraint](~/snippets/Snippets.NUnit/CustomConstraints.cs#SampleConstraint)]

Having written a custom constraint class, you can use it directly through its constructor:

```csharp
Assert.That(myObject, new CustomConstraint());
```

You may also use it in expressions through NUnit's `Matches` syntax element:

```csharp
Assert.That(myObject, Is.Not.Null.And.Matches(new CustomConstraint());
```

The direct construction approach is not very convenient or easy to read. For its built-in constraints, NUnit includes
classes that implement a special constraint syntax, allowing you to write things like...

```csharp
Assert.That(actual, Is.Custom(x, y));
```

To fully utilize your custom constraint the same way built-in constraints are used, you'll need to implement two additional integration points (which can cover all your constraints, not for each custom constraint):

* Provide a static method patterned after NUnit's `Is` class that can construct your custom
   constraint.

```csharp
Assert.That(actual, Is.Custom(x, y));
```

* Provide a method for NUnit's `ConstraintExpression` to allow chaining with other constraints, allowing you to write things like:

```csharp
Assert.That(actual, Is.Not.Custom(x, y));
```

### Example 1 (Using C#14 Extension Members)

Provide a static extension method on NUnit's `Is` class.

[!code-csharp[Syntax_Is_ExtensionMember](~/snippets/Snippets.NUnit/CustomConstraintSyntaxExamples.cs#Syntax_Is_ExtensionMember)]

Provide an extension method for NUnit's `ConstraintExpression`.

[!code-csharp[Syntax_Expression_ExtensionMember](~/snippets/Snippets.NUnit/CustomConstraintSyntaxExamples.cs#Syntax_Expression_ExtensionMember)]

With both in place, the custom constraint reads like a built-in one:

[!code-csharp[Syntax_ExtensionMember_Usage](~/snippets/Snippets.NUnit/CustomConstraintSyntaxExamples.cs#Syntax_ExtensionMember_Usage)]

### Example 2 (Using Extension Methods and Inheritance)

Extend NUnit's `Is` class and provide a static method. If you like, you can even call it `Is` and extend NUnit's `Is`, provided you place it in your own namespace and avoid any conflicts.

[!code-csharp[Syntax_Is_Inheritance](~/snippets/Snippets.NUnit/CustomConstraintSyntaxExamples.cs#Syntax_Is_Inheritance)]

Provide an extension method for NUnit's `ConstraintExpression`.

[!code-csharp[Syntax_Expression_ClassicExtension](~/snippets/Snippets.NUnit/CustomConstraints.cs#Syntax_Expression_ClassicExtension)]
