namespace Fluent.TryCatch.Operators;

/// <summary>
/// Represents a generic <c>finally</c> block. It's the fourth step of <see cref="Fluent"/> <c>try...catch</c> statements.
/// </summary>
public class Finallyabble : Executabble
{
    /// <summary>
    /// Adds a <c>finally</c> clause to the current <c>try...catch</c> statement.
    /// </summary>
    /// <param name="finallyBlock">The code that should be executed after the <c>try...catch</c> statement finishes.</param>
    /// <returns>A <see cref="Executabble"/> object.</returns>
    public Executabble Finally(Action finallyBlock)
    {
        _finally = finallyBlock;

        return this;
    }
}
