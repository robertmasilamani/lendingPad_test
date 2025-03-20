using BusinessEntities;
using Common;
using Data.Indexes;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    [AutoRegister]
    public class OrderRepository: Repository<Order>, IOrderRepository
    {
        private readonly IDocumentSession _documentSession;

        public OrderRepository(IDocumentSession documentSession) : base(documentSession) {
            _documentSession = documentSession;
        }

        public IEnumerable<Order> Get(OrderType? orderType, Guid? userId)
        {
            var query = _documentSession.Advanced.DocumentQuery<Order, OrderListIndex>();

            var hasFirstParameter = false;
            if (orderType != null)
            {
                query = query.WhereEquals("OrderType", (int)orderType);
                hasFirstParameter = true;
            }

            if (userId != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                else
                {
                    hasFirstParameter = true;
                }
                query = query.Where($"UserId:*{userId}*");
            }
            return query.ToList();
        }

        public IEnumerable<Order> OrderWithType(OrderType? orderType)
        {
            List<Order> values = new List<Order>();
            var query = _documentSession.Advanced.DocumentQuery<Order, OrderListIndex>();
            values = query.ToList().Where(x => x.OrderType == orderType).ToList();
            return values;
        }

        public void DeleteAll()
        {
            base.DeleteAll<OrderListIndex>();
        }
    }
}
