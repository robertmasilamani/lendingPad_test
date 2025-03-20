using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> OrderWithType(OrderType? orderType = null);
        IEnumerable<Order> Get(OrderType? orderType = null, Guid? userId = null);
        void DeleteAll();
    }
}
