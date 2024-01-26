namespace Fluent.TryCatch.Operators;

public class Tryabble : Catchabble
{
    public Tryabble(Action? action)
    {
        _action = action;
    }

    public Tryabble(Func<object>? func)
    {
        _func = func;
    }
}
