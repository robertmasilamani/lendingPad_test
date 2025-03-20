using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Core.Services.Orders
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateOrderService:IUpdateOrderService
    {
        public void update(Order order, OrderType orderType, Guid userId, IEnumerable<OrderItem> productlist, decimal price, decimal tax, decimal totalPrice, Address addrerss)
        {
            order.setAddress(addrerss);
            order.setOrderType(orderType);
            order.setUserID(userId);
            order.setProducts(productlist);
            order.setPrice(price);
            order.setTax(tax);
            order.setTotalPrice(totalPrice);
            
        }
    }
}
