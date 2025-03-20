using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        public OrderType OrderType { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<OrderItem> Productlist { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalPrice { get; set; }
        public Address Address { get; set; }
    }
}