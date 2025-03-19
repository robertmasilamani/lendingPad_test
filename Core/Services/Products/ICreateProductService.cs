﻿using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Products
{
    public interface ICreateProductService
    {
        Product Create(Guid id, string name, string description, ProductCategories category, MeasurementTypes measurementType, decimal? unitPrice);
    }
}
