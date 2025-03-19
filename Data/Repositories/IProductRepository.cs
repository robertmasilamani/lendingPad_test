using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> UsersWithCategory(ProductCategories? category = null);
        IEnumerable<Product> Get(string name = null, ProductCategories? categoty = null, string email = null);
        void DeleteAll();
    }
}
