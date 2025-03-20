using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Orders
{
    public class OrderData : IdObjectData
    {
        public OrderData(Order order) : base(order)
        {
            OrderType = order.OrderType;
            UserId = order.UserId;
            Price = order.Price;
            Tax = order.Tax;
            TotalPrice = order.TotalPrice;
            Address = order.Address;
        }

        public OrderType OrderType { get; set; }
        public Guid UserId { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalPrice { get; set; }
        public Address Address { get; set; }
     }
}