using Raven.Abstractions.Indexing;
using System;
using System.Collections.Generic;
using System.Text;
using Raven.Client.Indexes;
using BusinessEntities;
using System.Linq;

namespace Data.Indexes
{
    internal class OrderListIndex : AbstractIndexCreationTask<Order>
    {

        public OrderListIndex()
        {
            Map = orders => from order in orders
                            select new
                            {
                                order.UserId,
                                order.OrderType
                            };

            Index(x => x.OrderType, FieldIndexing.NotAnalyzed);
        }
    }
}
