using System.Collections;
using NUnit.Framework;

namespace Snippets.NUnit;

// These tests fail on purpose to show what NUnit to expose the exception data
// Marked the tests as Explicit to avoid failing the doc build and test runs
public class ExceptionDataExamples
{
    #region ExceptionDataOuterAndInner
    [Test, Explicit("Fails on purpose to show the failure message")]
    public void TestWithOuterAndInnerExceptionData()
    {
        var inner = new FormatException("Invalid number");
        inner.Data["Column"] = "Amount";

        var outer = new InvalidOperationException("Import failed", inner);
        outer.Data["Row"] = 42;
        throw outer;
    }
    #endregion

    #region ExceptionDataCustomException
    public class ImportException : Exception
    {
        private readonly Dictionary<string, object?> _details = new();

        public ImportException(string message, int row, string column)
            : base(message)
        {
            _details["Row"] = row;
            _details["Column"] = column;
        }

        // NUnit reads Data, so overriding it keeps test-only detail out of the
        // dictionary that production error reporting would otherwise see.
        public override IDictionary Data => _details;
    }

    [Test, Explicit("Fails on purpose to show the failure message")]
    public void TestWithCustomExceptionData()
    {
        throw new ImportException("Import failed", row: 42, column: "Amount");
    }
    #endregion
}