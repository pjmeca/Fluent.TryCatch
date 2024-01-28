using Fluents.TryCatch.Operators;

namespace Fluents.TryCatch.IOperators;

/// <summary>
/// Represents a <c>catch</c> block. It's the second step of <see cref="Fluent"/> <c>try...catch</c> statements.
/// </summary>
public interface ICatchabble : IIgnorabble
{
    /// <summary>
    /// Adds a new <c>catch</c> block to the current <c>try...catch</c> statement.
    /// <br/><strong>Note:</strong> in a secuence containing multiple <c>catch</c> blocks only the first block
    /// that can handle the exception, if any, will be executed.
    /// </summary>
    /// <typeparam name="TException">The <see cref="Exception"/> type you want to catch.</typeparam>
    /// <param name="catchBlock">The code that should be executed if <typeparamref name="TException"/> is raised.</param>
    /// <returns>A <see cref="Catchabble"/> object.</returns>
    public ICatched Catch<TException>(Action<Exception> catchBlock) where TException : Exception;

    /// <inheritdoc cref="Catch{TException}(Action{Exception})"/>
    public ICatched Catch<TException>(Func<Exception, object> catchBlock) where TException : Exception;

    /// <summary>
    /// Adds a new empty <c>catch</c> block to the current <c>try...catch</c> statement.
    /// <br/><strong>Note:</strong> in a secuence containing multiple <c>catch</c> blocks only the first block
    /// that can handle the exception, if any, will be executed.
    /// </summary>
    /// <typeparam name="TException">The <see cref="Exception"/> type you want to catch.</typeparam>
    /// <returns>A <see cref="Catchabble"/> object.</returns>
    public ICatched Catch<TException>() where TException : Exception;

    /// <summary>
    /// Adds a new <c>catch</c> block to the current <c>try...catch</c> statement that catches the default <see cref="Exception"/> type.
    /// <br/><strong>Note:</strong> in a secuence containing multiple <c>catch</c> blocks only the first block
    /// that can handle the exception, if any, will be executed.
    /// </summary>
    /// <param name="catchBlock">The code that should be executed if <see cref="Exception"/> is raised.</param>
    /// <returns>A <see cref="Catchabble"/> object.</returns>
    public ICatched Catch(Action<Exception> catchBlock);

    /// <inheritdoc cref="Catch(Action{Exception})"/>
    public ICatched Catch(Func<Exception, object> catchBlock);

    /// <summary>
    /// Adds a new empty <c>catch</c> block to the current <c>try...catch</c> statement that catches the default <see cref="Exception"/> type.
    /// <br/><strong>Note:</strong> in a secuence containing multiple <c>catch</c> blocks only the first block
    /// that can handle the exception, if any, will be executed.
    /// </summary>
    /// <param name="catchBlock">The code that should be executed if <see cref="Exception"/> is raised.</param>
    /// <returns>A <see cref="Catchabble"/> object.</returns>
    public ICatched Catch();
}
