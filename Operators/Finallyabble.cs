using Fluent.TryCatch.IOperators;

namespace Fluent.TryCatch.Operators;

/// <inheritdoc cref="IFinallyabble"/>
public class Finallyabble : Executabble, IFinallyabble
{
    public IExecutabble Finally(Action finallyBlock)
    {
        _finally = finallyBlock;

        return this;
    }
}
