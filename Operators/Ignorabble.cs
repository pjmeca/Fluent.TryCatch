namespace Fluent.TryCatch.Operators;

public class Ignorabble : Finallyabble
{
    public Finallyabble Ignore()
    {
        _ignore = true;

        return this;
    }
}
