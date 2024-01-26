using Fluent.TryCatch.Operators;

namespace Fluent.TryCatch;

public static class Fluent
{
    public static Tryabble Try(Action? action)
    {
        return new Tryabble(action);
    }

    public static Tryabble Try(Func<object>? func)
    {
        return new Tryabble(func);
    }
}
