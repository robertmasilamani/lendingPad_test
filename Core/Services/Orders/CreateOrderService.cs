using BusinessEntities;
using Common;
using Core.Factories;
using Core.Services.Products;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class CreateOrderService:ICreateOrderService
    {

        private readonly IUpdateOrderService _updateOrderService;
        private readonly ICreateOrderService _createOrderService;
        private readonly IIdObjectFactory<Order> _OrderFactory;
        private readonly IOrderRepository _OrderRepository;


        public CreateOrderService(IIdObjectFactory<Order> OrderFactory, IOrderRepository OrderRepository, IUpdateOrderService updateOrderService) {
            _OrderFactory = OrderFactory;
            _OrderRepository = OrderRepository;
            _updateOrderService = updateOrderService;
        }

        public Order create(Guid id, OrderType orderType, Guid userId, IEnumerable<OrderItem> productlist, decimal price, decimal tax, decimal totalPrice, Address addrerss)
        {
            var order = _OrderFactory.Create(id);
            _updateOrderService.update(order, orderType, userId, productlist, price, tax, totalPrice, addrerss);
            _OrderRepository.Save(order);
            return order;
        }

    }
}
