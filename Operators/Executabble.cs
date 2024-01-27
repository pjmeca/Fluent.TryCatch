
using Fluent.TryCatch.IOperators;
using Fluent.TryCatch.Models;

namespace Fluent.TryCatch.Operators;

/// <inheritdoc cref="IExecutabble"/>
public class Executabble : IExecutabble
{
    protected Action? _action { get; set; }
    protected Func<object>? _func { get; set; }

    protected List<CatchBlock> _catchBlocks { get; set; } = new();

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
                .Find(x => x.Type.IsAssignableFrom(ex.GetType()));

            if (catchBlock != null)
            {
                return catchBlock.Invoke<T>(ex);
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
