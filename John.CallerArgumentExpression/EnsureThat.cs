using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace John.CallerArgumentExpression;

public static  class EnsureThat
{
    public static void ItIsNotEmpty<T>(IEnumerable<T> value, [CallerArgumentExpression("value")] string message = "")
    {
        if(!value .Any())
        {
            throw new ArgumentException("Enumerable is empty", message);
        }
    }
}
