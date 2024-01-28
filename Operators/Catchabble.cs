using Fluents.TryCatch.IOperators;
using Fluents.TryCatch.Models;

namespace Fluents.TryCatch.Operators;

/// <inheritdoc cref="ICatchabble"/>
public class Catchabble : Ignorabble, ICatchabble
{
    private ICatched BaseCatch(CatchBlock catchBlock)
    {
        _catchBlocks.Add(catchBlock);
        return new Catched(this);
    }

    public ICatched Catch<TException>(Action<Exception> catchBlock) where TException : Exception
    {
        return BaseCatch(new(typeof(TException), catchBlock));
    }

    public ICatched Catch<TException>(Func<Exception, object> catchBlock) where TException : Exception
    {
        return BaseCatch(new(typeof(TException), catchBlock));
    }

    public ICatched Catch<TException>() where TException : Exception
    {
        return BaseCatch(new(typeof(TException)));
    }

    public ICatched Catch(Action<Exception> catchBlock)
    {
        return BaseCatch(new(typeof(Exception), catchBlock));
    }

    public ICatched Catch(Func<Exception, object> catchBlock)
    {
        return BaseCatch(new(typeof(Exception), catchBlock));
    }

    public ICatched Catch()
    {
        return BaseCatch(new(typeof(Exception)));
    }
}
