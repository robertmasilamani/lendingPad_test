﻿using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    public interface IUpdateProductService
    {
        void Update(Product product, string name, string description, ProductCategories category, MeasurementTypes measurementType, decimal? unitPrice);
    }
}
