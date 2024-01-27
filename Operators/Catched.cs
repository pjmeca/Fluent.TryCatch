using System.Reflection;
using Fluent.TryCatch.IOperators;

namespace Fluent.TryCatch.Operators;

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
        return this;
    }
}
