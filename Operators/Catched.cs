using System.Reflection;
using Fluents.TryCatch.IOperators;
using Fluents.TryCatch.Models;

namespace Fluents.TryCatch.Operators;

/// <inheritdoc cref="ICatched"/>
public class Catched : Catchabble, ICatched
{
    public Catched(ICatchabble catchabble)
    {
        var properties = typeof(Catchabble)
            .GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
            .ToList();
        properties.ForEach(pi =>
        {
            if (pi.CanWrite)
                pi.SetValue(this, pi.GetValue(catchabble, null), null);
        });
    }

    public ICatchabble When(Func<Exception, bool> filter)
    {
        if (_catchBlocks.Count == 0)
        {
            throw new InvalidOperationException("No catch blocks available!");
        }

        CatchBlock last = _catchBlocks[^1];
        last.When = filter;

        return this;
    }
}
