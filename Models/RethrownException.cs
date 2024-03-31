namespace Fluent.TryCatch.Models;

/// <summary>
/// Encapsulator for rethrowing exceptions.
/// </summary>
public class RethrownException
{
    /// <summary>
    /// The <see cref="Exception"/> type to be rethrown.
    /// </summary>
    public Type Type { get; private set; }
    /// <summary>
    /// A message to be thrown with the new exception. Otherwise it will be inherited from the original exception.
    /// </summary>
    public string? Message { get; private set; } = null;
    /// <summary>
    /// Original exception thrown by the <c>try</c> clause.
    /// </summary>
    public Exception? InnerException { get; private set; }

    public RethrownException(Type type, string? message = null)
    {
        if (!typeof(Exception).IsAssignableFrom(type))
        {
            throw new ArgumentException($"{nameof(type)} not valid!");
        }

        Type = type;
        Message = message;
    }

    public void Throw(Exception? InnerException = null)
    {
        if (Message == null && InnerException != null)
        {
            Message = InnerException.Message;
        }

        Exception rethrownException = (Exception)Activator.CreateInstance(Type, Message, InnerException);
        throw rethrownException;
    }
}
