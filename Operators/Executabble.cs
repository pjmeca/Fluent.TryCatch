namespace Fluent.TryCatch.Operators;

/// <summary>
/// Performs the <c>try...catch</c> statement. It's the final step of <see cref="Fluent"/> <c>try...catch</c> statements.
/// </summary>
public class Executabble
{
    protected Action? _action { get; set; }
    protected Func<object>? _func { get; set; }

    protected List<(Type Type, Action<Exception> Action)> _catchActions { get; set; } = new();
    protected List<(Type Type, Func<Exception, object> Action)> _catchFuncs { get; set; } = new();

    protected bool _ignore { get; set; }

    protected Action? _finally { get; set; }

    /// <inheritdoc cref="Execute()" select="summary"/>
    /// <typeparam name="T">Value type expected to be returned from the <c>try</c> clause.</typeparam>
    /// <returns>A value of type <typeparamref name="T"/> that should be returned from the <c>try</c> clause or its default value.
    /// An exception may be thrown if the casting cannot be done.</returns>
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

    /// <summary>
    /// Performs the <c>try...catch</c> statement.
    /// </summary>
    public void Execute()
    {
        _ = Execute<object>();
    }
}
