namespace Fluent.TryCatch.Operators;

public class Finallyabble : Executabble
{
    public Executabble Finally(Action finallyBlock)
    {
        _finally = finallyBlock;

        return this;
    }
}
