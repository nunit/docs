using NUnit.Framework;
using NUnit.Framework.Constraints;
using static Snippets.NUnit.CustomConstraints;

namespace Snippets.NUnit;

public static class CustomConstraints
{
    #region SampleConstraint
    public class CustomConstraint : Constraint
    {
        private readonly string _expected;

        public CustomConstraint(string expected)
        {
            _expected = expected;
        }

        public override string Description => "Custom";

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            if (actual is not string actualString)
            {
                return new ConstraintResult(this, actual, false);
            }

            bool success = _expected == actualString;
            return new ConstraintResult(this, actual, success);
        }
    }
    #endregion
}

#region Syntax_Expression_ClassicExtension
public static class CustomConstraintClassicExtensions
{
    public static CustomConstraint Custom(this ConstraintExpression expression, string expected)
    {
        var constraint = new CustomConstraint(expected);
        expression.Append(constraint);
        return constraint;
    }
}
#endregion