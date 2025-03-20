using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    public interface ICreateOrderService
    {
        Order create(Guid orderId, OrderType orderType, Guid userId, IEnumerable<OrderItem> productlist, decimal price, decimal tax, decimal totalPrice, Address addrerss);
    }
}
