
using Fluent.TryCatch.Models;
using Fluents.TryCatch.IOperators;
using Fluents.TryCatch.Models;

namespace Fluents.TryCatch.Operators;

/// <inheritdoc cref="IExecutabble"/>
public class Executabble : IExecutabble
{
    protected Action? _action { get; set; }
    protected Func<object>? _func { get; set; }

    protected RethrownException? _throwAs { get; set; }

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
                .Find(x => x.Match(ex));

            if (catchBlock != null)
            {
                return catchBlock.Invoke<T>(ex);
            }
            else
            {
                _throwAs?.Throw(ex);

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
