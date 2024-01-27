using Fluent.TryCatch.IOperators;

namespace Fluent.TryCatch.Operators;

/// <inheritdoc cref="ICatchabble"/>
public class Catchabble : Ignorabble, ICatchabble
{
    public ICatchabble Catch<TException>(Action<Exception> catchBlock) where TException : Exception
    {
        _catchActions.Add((typeof(TException), catchBlock));

        return this;
    }

    public ICatchabble Catch<TException>(Func<Exception, object> catchBlock) where TException : Exception
    {
        _catchFuncs.Add((typeof(TException), catchBlock));

        return this;
    }

    public ICatchabble Catch<TException>() where TException : Exception
    {
        _catchActions.Add((typeof(TException), e => { }));

        return this;
    }

    public ICatchabble Catch(Action<Exception> catchBlock)
    {
        _catchActions.Add((typeof(Exception), catchBlock));

        return this;
    }

    public ICatchabble Catch(Func<Exception, object> catchBlock)
    {
        _catchFuncs.Add((typeof(Exception), catchBlock));

        return this;
    }

    public ICatchabble Catch()
    {
        _catchActions.Add((typeof(Exception), e => { }));

        return this;
    }
}
