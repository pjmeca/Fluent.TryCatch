using Fluent.TryCatch.IOperators;

namespace Fluent.TryCatch.Operators;

/// <inheritdoc cref="IIgnorabble"/>
public class Ignorabble : Finallyabble, IIgnorabble
{
    public IFinallyabble Ignore()
    {
        _ignore = true;

        return this;
    }
}
