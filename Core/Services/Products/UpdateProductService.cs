﻿using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.Services.Products
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateProductService : IUpdateProductService
    {
        public void Update(Product product, string name, string description, ProductCategories category, MeasurementTypes measurementType, decimal? unitPrice)
        {
            product.setName(name);
            product.setDescription(description);
            product.setProductCategories(category);
            product.setMeasurementType(measurementType);
            product.setUnitPrice(unitPrice);
        }
    }
}
