namespace Fluent.TryCatch.Models;

public class CatchBlock
{
    public Type Type { get; private set; }

    public Action<Exception>? Action { get; private set; }
    public bool IsAction => Action != null;

    public Func<Exception, object>? Func { get; private set; }
    public bool IsFunc => Func != null;

    public Func<Exception, bool>? When { get; set; }

    public CatchBlock(Type type)
    {
        Type = type;
    }

    public CatchBlock(Type type, Action<Exception> action) : this(type)
    {
        Action = action;
    }

    public CatchBlock(Type type, Func<Exception, object>? func) : this(type)
    {
        Func = func;
    }

    public bool Match(Exception exception)
    {
        return Type.IsAssignableFrom(exception.GetType()) &&
            (When == null || When.Invoke(exception));
    }

    public T Invoke<T>(Exception ex)
    {
        if (IsFunc)
        {
            return (T)Func!.Invoke(ex);
        }
        else if (IsAction)
        {
            Action!.Invoke(ex);
        }
        return default;
    }
}
