using NUnit.Framework;

#pragma warning disable CA1822

namespace Snippets.NUnit;

public class AsyncAssertExamples
{
    #region AssertThatAsync
    [Test]
    public async Task AssertionPasses_CompletedTaskWithResult_EqualsResult()
    {
        await Assert.ThatAsync(() => Task.FromResult(42), Is.EqualTo(42));
    }
    #endregion

    #region AssertMultipleAsync
    [Test]
    public async Task AssertMultipleAsyncSucceeds()
    {
        await Assert.MultipleAsync(async () =>
        {
            await Assert.ThatAsync(() => Task.FromResult(42), Is.EqualTo(42));
            Assert.That("hello", Is.EqualTo("hello"));
            await Assert.ThatAsync(() => Task.FromException(new ArgumentNullException()), Throws.ArgumentNullException);
        });
    }
    #endregion
}
