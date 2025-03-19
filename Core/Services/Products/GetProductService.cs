using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    [AutoRegister]
    public class GetProductService : IGetProductService
    {
        private readonly IProductRepository _productRepository;

        public GetProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProduct(Guid id)
        {
            return _productRepository.Get(id);
        }

        public IEnumerable<Product> GetProducts(string name = null, ProductCategories? category = null, string description = null)
        {
            return _productRepository.Get(name, category, description);
        }

        public IEnumerable<Product> GetProductsWithCategory(ProductCategories? category = null)
        {
            return _productRepository.UsersWithCategory(category);
        }
    }
}
