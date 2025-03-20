using BusinessEntities;
using Core.Services.Orders;
using System;
using System.Configuration;
using System.Configuration.Internal;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models.Orders;

namespace WebApi.Controllers
{
    [RoutePrefix("Order")]
    public class OrderController : BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IUpdateOrderService _updateOrderService;

        public OrderController(ICreateOrderService createOrderService, IDeleteOrderService deleteOrderService, IGetOrderService getOrderService, IUpdateOrderService updateOrderService)
        {
            _createOrderService = createOrderService;
            _deleteOrderService = deleteOrderService;
            _getOrderService = getOrderService;
            _updateOrderService = updateOrderService;
        }

        [Route("{orderId:guid}/create")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage CreateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            var order = _createOrderService.create(orderId, model.OrderType, model.UserId, model.Productlist, model.Price, model.Tax, model.TotalPrice, model.Address);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(Guid orderId, [FromBody] OrderModel model)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }
            _updateOrderService.update(order, model.OrderType, model.UserId, model.Productlist, model.Price, model.Tax, model.TotalPrice, model.Address);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage Deleteorder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }
            _deleteOrderService.Delete(order);
            return Found();
        }

        [Route("{orderId:guid}")]
        [HttpGet]
        public HttpResponseMessage Getorder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            return Found(new OrderData(order));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetOrders(int skip, int take, OrderType? orderType = null, Guid? userId = null)
        {
            var orders = _getOrderService.GetOrders(orderType, userId)
                                       .Skip(skip).Take(take)
                                       .Select(q => new OrderData(q))
                                       .ToList();
            return Found(orders);
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllOrders()
        {
            _deleteOrderService.DeleteAll();
            return Found();
        }

        [Route("list/OrderType")]
        [HttpGet]
        public HttpResponseMessage GetUsersByCategory(OrderType? orderType)
        {
            var orders = _getOrderService.GetOrderWithType(orderType);

            return Found(orders);
        }
    }
}