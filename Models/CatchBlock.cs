namespace Fluent.TryCatch.Models;

/// <summary>
/// Represents a <c>catch</c> block.
/// </summary>
public class CatchBlock
{
    /// <summary>
    /// The <see cref="Exception"/> type to be catched.
    /// </summary>
    public Type Type { get; private set; }

    /// <summary>
    /// The code that should be executed if an <see cref="Exception"/> of type <see cref="Type"/> is raised.
    /// </summary>
    public Action<Exception>? Action { get; private set; }
    /// <summary>
    /// Indicates whether this <c>catch</c> block executes an <see cref="Action{T}"/> or a <see cref="Func{T, TResult}"/>.
    /// </summary>
    public bool IsAction => Action != null;

    /// <inheritdoc cref="Action"/>
    public Func<Exception, object>? Func { get; private set; }
    /// <summary>
    /// Indicates whether this <c>catch</c> block executes a <see cref="Func{T, TResult}"/> or an <see cref="Action{T}"/>.
    /// </summary>
    public bool IsFunc => Func != null;

    /// <summary>
    /// Additional logic to apply during <c>catch</c> blocks discrimination.
    /// </summary>
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

    /// <summary>
    /// Checks if the current <c>catch</c> block can be applied to the given <paramref name="exception"/>.
    /// </summary>
    /// <param name="exception">The <see cref="Exception"/> to be checked.</param>
    public bool Match(Exception exception)
    {
        return Type.IsAssignableFrom(exception.GetType()) &&
            (When == null || When.Invoke(exception));
    }

    /// <summary>
    /// Invokes the body code of the current <c>catch</c> block.
    /// </summary>
    /// <typeparam name="T">Value type expected to be returned from the <c>catch</c> code.</typeparam>
    /// <param name="ex"><see cref="Exception"/> raised from the <c>try</c> clause.</param>
    /// <returns></returns>
    public T Invoke<T>(Exception ex)
    {
        if (!Match(ex))
        {
            throw new InvalidOperationException("Cannot handle this exception!");
        }

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
