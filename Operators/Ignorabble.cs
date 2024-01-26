namespace Fluent.TryCatch.Operators;

/// <summary>
/// Represents a generic <c>catch</c> block. It's the third step of <see cref="Fluent"/> <c>try...catch</c> statements.
/// </summary>
public class Ignorabble : Finallyabble
{
    /// <summary>
    /// Ignores any exception thrown that is not already handled.
    /// </summary>
    /// <returns>A <see cref="Finallyabble"/> object.</returns>
    public Finallyabble Ignore()
    {
        _ignore = true;

        return this;
    }
}
