using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace John.TypedId
{
    public class Order
    {
        public OrderId Id { get; } = OrderId.New();
    }
}
