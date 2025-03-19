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
    public class ProductReposiotory : Repository<Product>, IProductRepository
    {
        private readonly IDocumentSession _documentSession;

        public ProductReposiotory(IDocumentSession documentSession) : base(documentSession)
        {
            _documentSession = documentSession;
        }

        public IEnumerable<Product> Get(string name = null, ProductCategories? category = null, string description = null)
        {
            var query = _documentSession.Advanced.DocumentQuery<Product, ProductListIndex>();

            var hasFirstParameter = false;
            if (category != null)
            {
                query = query.WhereEquals("Category", (int)category);
                hasFirstParameter = true;
            }

            if (name != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                else
                {
                    hasFirstParameter = true;
                }
                query = query.Where($"Name:*{name}*");
            }

            if (description != null)
            {
                if (hasFirstParameter)
                {
                    query = query.AndAlso();
                }
                query = query.Where($"Description:*{description}*");
            }
            return query.ToList();
        }


        public IEnumerable<Product> UsersWithCategory(ProductCategories? category)
        {
            List<Product> values = new List<Product>();
            var query = _documentSession.Advanced.DocumentQuery<Product, ProductListIndex>();
            values = query.ToList().Where(x => x.Category == category).ToList();
            return values;
        }

        public void DeleteAll()
        {
            base.DeleteAll<ProductListIndex>();
        }
    }
}
