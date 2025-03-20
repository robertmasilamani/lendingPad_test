using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    public interface IGetOrderService
    {
        Order GetOrder(Guid id);
        IEnumerable<Order> GetOrderWithType(OrderType? orderType = null);
        IEnumerable<Order> GetOrders(OrderType? orderType = null, Guid? userId = null);
    }
}
