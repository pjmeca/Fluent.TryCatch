using Fluent.TryCatch.IOperators;

namespace Fluent.TryCatch.Operators;

/// <inheritdoc cref="ITryabble"/>
public class Tryabble : Catchabble, ITryabble
{
    /// <summary>
    /// Starts a fluent <c>try...catch</c> statement that expects to return nothing after it's execution.
    /// </summary>
    /// <param name="action">The action you want to protect under the try block.</param>
    /// <returns>A <see cref="Tryabble"/> object.</returns>
    public Tryabble(Action? action)
    {
        _action = action;
    }

    /// <summary>
    /// Starts a fluent <c>try...catch</c> statement that expects to return a value after it's execution.
    /// <br/>The value type will be specified later when <see cref="Executabble.Execute()"/> is called.
    /// </summary>
    /// <param name="func">The func you want to protect under the try block.</param>
    /// <returns>A <see cref="Tryabble"/> object.</returns>
    public Tryabble(Func<object>? func)
    {
        _func = func;
    }
}
