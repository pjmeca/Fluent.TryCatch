namespace Fluents.TryCatch.IOperators;

/// <summary>
/// Represents an intermediate step between a <c>catch</c> instruction and its successors.
/// </summary>
public interface ICatched : ICatchabble
{
    /// <summary>
    /// Applies additional discrimination logic to the current <c>catch</c> block.
    /// </summary>
    /// <param name="filter">The additional logic to apply.</param>
    public ICatchabble When(Func<Exception, bool> filter);
}
