using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace John.TypedId.Services
{
    public class OrderServices
    {
        private List<Order> _orders = new() { new(), new() };

        public IEnumerable<Order> GetOrderById(OrderId id)
        {
            return _orders.Where(order => order.Id == id);
        }
    }
}
