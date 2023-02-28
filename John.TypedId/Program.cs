using John.TypedId;
using John.TypedId.Services;

var service = new OrderServices();
var guid = Guid.NewGuid();
service.GetOrderById(new OrderId(guid));