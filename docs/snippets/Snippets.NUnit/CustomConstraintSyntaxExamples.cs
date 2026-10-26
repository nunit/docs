using NUnit.Framework;
using NUnit.Framework.Constraints;
using static Snippets.NUnit.CustomConstraints;

#pragma warning disable CA1822

namespace Snippets.NUnit.CustomSyntax
{
    #region ReferenceEqualsConstraint
    public class ReferenceEqualsConstraint : Constraint
    {
        public ReferenceEqualsConstraint(object expected) : base(expected)
        {
        }

        public override string Description => $"the same instance as {Arguments[0]}";

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            return new ConstraintResult(this, actual, ReferenceEquals(actual, Arguments[0]));
        }
    }
    #endregion

    public class ReferenceEqualsConstraintTests
    {
        [Test]
        public void MatchesOnlyTheSameInstance()
        {
            var expected = new object();

            Assert.That(expected, new ReferenceEqualsConstraint(expected));
            Assert.That(new object(), Is.Not.Matches(new ReferenceEqualsConstraint(expected)));
        }

        [Test]
        public void StringRepresentationUsesTheDisplayName()
        {
            var constraint = new ReferenceEqualsConstraint("expected");

            Assert.That(constraint.ToString(), Is.EqualTo("<referenceequals \"expected\">"));
        }
    }

    namespace ExtensionMembers
    {
        #region Syntax_Is_ExtensionMember
        public static class CustomConstraintExtensions
        {
            extension(Is)
            {
                public static CustomConstraint Custom(string expected)
                {
                    return new CustomConstraint(expected);
                }
            }
        }
        #endregion

        #region Syntax_Expression_ExtensionMember
        public static class CustomConstraintExpressionExtensions
        {
            extension(ConstraintExpression expression)
            {
                public CustomConstraint Custom(string expected)
                {
                    var constraint = new CustomConstraint(expected);
                    expression.Append(constraint);
                    return constraint;
                }
            }
        }
        #endregion

        public class ExtensionMemberSyntaxTests
        {
            #region Syntax_ExtensionMember_Usage
            [Test]
            public void CustomConstraintReadsLikeABuiltInOne()
            {
                Assert.That("Hello", Is.Custom("Hello"));
                Assert.That("Hello", Is.Not.Custom("Goodbye"));
                Assert.That("Hello", Is.Not.Null.And.Custom("Hello"));
            }
            #endregion
        }
    }

    namespace Inheritance
    {
        #region Syntax_Is_Inheritance
        public class Is : global::NUnit.Framework.Is
        {
            public static CustomConstraint Custom(string expected)
            {
                return new CustomConstraint(expected);
            }
        }
        #endregion

        public class InheritanceSyntaxTests
        {
            [Test]
            public void CustomConstraintReadsLikeABuiltInOne()
            {
                Assert.That("Hello", Is.Custom("Hello"));
                Assert.That("Hello", Is.Not.Custom("Goodbye"));
                Assert.That("Hello", Is.Not.Null.And.Custom("Hello"));
            }
        }
    }
}
