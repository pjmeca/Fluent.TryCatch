namespace Fluent.TryCatch.IOperators;

/// <summary>
/// Performs the <c>try...catch</c> statement. It's the final step of <see cref="Fluent"/> <c>try...catch</c> statements.
/// </summary>
public interface IExecutabble
{
    /// <inheritdoc cref="Execute()" select="summary"/>
    /// <typeparam name="T">Value type expected to be returned from the <c>try</c> clause.</typeparam>
    /// <returns>A value of type <typeparamref name="T"/> that should be returned from the <c>try</c> clause or its default value.
    /// An exception may be thrown if the casting cannot be done.</returns>
    public T Execute<T>();

    /// <summary>
    /// Performs the <c>try...catch</c> statement.
    /// </summary>
    public void Execute();
}
