using Fluent.TryCatch.IOperators;
using Fluent.TryCatch.Operators;

namespace Fluent.TryCatch;

/// <summary>
/// Helper class for creating <c>try...catch</c> statements.
/// </summary>
public static class Fluent
{
    /// <inheritdoc cref="Tryabble.Tryabble(Action?)"/>
    public static ITryabble Try(Action? action)
    {
        return new Tryabble(action);
    }

    /// <inheritdoc cref="Tryabble.Tryabble(Func{object}?)"/>
    public static ITryabble Try(Func<object>? func)
    {
        return new Tryabble(func);
    }
}
