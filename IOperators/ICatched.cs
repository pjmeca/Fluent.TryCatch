namespace Fluent.TryCatch.IOperators;

public interface ICatched : ICatchabble
{
    public ICatchabble When(Func<Exception, bool> filter);
}
