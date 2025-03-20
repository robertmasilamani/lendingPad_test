using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class GetOrderService : IGetOrderService
    {
        private readonly IOrderRepository _OrderRepository;

        public GetOrderService(IOrderRepository orderRepository)
        {
            _OrderRepository = orderRepository;
        }

        public Order GetOrder(Guid id)
        {
            return _OrderRepository.Get(id); 
        }

        public IEnumerable<Order> GetOrders(OrderType? orderType, Guid? userId)
        {
            return _OrderRepository.Get(orderType, userId);
        }

        public IEnumerable<Order> GetOrderWithType(OrderType? orderType)
        {
            return _OrderRepository.OrderWithType(orderType);
        }
    }
}
