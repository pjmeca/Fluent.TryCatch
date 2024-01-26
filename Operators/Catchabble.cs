namespace Fluent.TryCatch.Operators;

public class Catchabble : Ignorabble
{
    public Catchabble Catch<TException>(Action<Exception> catchBlock) where TException : Exception
    {
        _catchBlocks.Add((typeof(TException), catchBlock));

        return this;
    }

    public Catchabble Catch(Action<Exception> catchBlock)
    {
        _catchBlocks.Add((typeof(Exception), catchBlock));

        return this;
    }
}
