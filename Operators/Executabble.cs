namespace Fluent.TryCatch.Operators;

public class Executabble
{
    protected Action? _action { get; set; }
    protected Func<object>? _func { get; set; }

    protected List<(Type Type, Action<Exception> Action)> _catchBlocks { get; set; } = [];

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
            var catchBlock = _catchBlocks
                .Where(x => x.Type.IsAssignableFrom(ex.GetType()))
                .Select(x => x.Action)
                .FirstOrDefault();

            if (catchBlock != null)
            {
                catchBlock.Invoke(ex);
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
