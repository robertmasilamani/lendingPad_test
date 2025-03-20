using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class DeleteOrderService:IDeleteOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public DeleteOrderService(IOrderRepository orderRepository) { 
            _orderRepository = orderRepository;
        }

        void IDeleteOrderService.Delete(Order order)
        {
            _orderRepository.Delete(order);
        }

        void IDeleteOrderService.DeleteAll()
        {
            _orderRepository.DeleteAll();
        }
    }
}
