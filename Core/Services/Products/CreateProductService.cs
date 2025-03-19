using BusinessEntities;
using Common;
using Core.Factories;
using Core.Services.Products;
using Core.Services.Users;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{

    [AutoRegister]
    public class CreateProductService : ICreateProductService
    {
        private readonly IUpdateProductService _updateProductService;
        private readonly ICreateProductService _createProductService;
        private readonly IIdObjectFactory<Product> _ProductFactory;
        private readonly IProductRepository _ProductRepository;

        public CreateProductService(IIdObjectFactory<Product> ProductFactory, IProductRepository ProductRepository, IUpdateProductService updateProductService)
        {
            _ProductFactory = ProductFactory;
            _ProductRepository = ProductRepository;
            _updateProductService = updateProductService;

        }

        public Product Create(Guid id, string name, string description, ProductCategories category, MeasurementTypes measurementType, decimal? unitPrice)
        {
            var product = _ProductFactory.Create(id);
            _updateProductService.Update(product, name, description, category, measurementType, unitPrice);
            _ProductRepository.Save(product);
            return product;
        }
    }
}
