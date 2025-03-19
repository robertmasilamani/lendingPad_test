using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    public interface IGetProductService
    {
        Product GetProduct(Guid id);
        IEnumerable<Product> GetProductsWithCategory(ProductCategories? category = null);
        IEnumerable<Product> GetProducts(string name = null, ProductCategories? categoty = null, string email = null);
    }
}
