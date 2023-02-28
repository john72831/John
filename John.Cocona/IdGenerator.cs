using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace John.Cocona
{
    public class IdGenerator
    {
        public Guid Id => Guid.NewGuid();
    }
}
