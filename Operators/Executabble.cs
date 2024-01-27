using Fluent.TryCatch.IOperators;

namespace Fluent.TryCatch.Operators;

/// <inheritdoc cref="IExecutabble"/>
public class Executabble : IExecutabble
{
    protected Action? _action { get; set; }
    protected Func<object>? _func { get; set; }

    protected List<(Type Type, Action<Exception> Action)> _catchActions { get; set; } = new();
    protected List<(Type Type, Func<Exception, object> Action)> _catchFuncs { get; set; } = new();

    protected bool _ignore { get; set; }

    protected Action? _finally { get; set; }

    public T Execute<T>()
    {
        try
        {
            if (_func != null)
            {
                return (T)_func.Invoke();
            }

            _action?.Invoke();
        }
        catch (Exception ex)
        {
            var catchAction = _catchActions
                .Where(x => x.Type.IsAssignableFrom(ex.GetType()))
                .Select(x => x.Action)
                .FirstOrDefault();
            var catchFunc = _catchFuncs
                .Where(x => x.Type.IsAssignableFrom(ex.GetType()))
                .Select(x => x.Action)
                .FirstOrDefault();

            if (catchFunc != null)
            {
                return (T)catchFunc.Invoke(ex);
            }
            else if (catchAction != null)
            {
                catchAction.Invoke(ex);
            }
            else
            {
                if (!_ignore)
                    throw;
            }
        }
        finally
        {
            _finally?.Invoke();
        }

        return default;
    }

    public void Execute()
    {
        _ = Execute<object>();
    }
}
