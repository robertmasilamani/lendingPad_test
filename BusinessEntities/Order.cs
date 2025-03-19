using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class Order: IdObject
    {
        public int OrderId { get; set; }
        public Guid UserId { get; set; }
        public List<OrderItem> Productlist { get; set; }
    }

    public class OrderItem { 
        public int ProductId { get; set; }
        public decimal Qiuantity { get; set; }   
    }
}
