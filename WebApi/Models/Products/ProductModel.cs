using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Products
{
    public class ProductModel
    {
        public string Name { get; set; }
        public ProductCategories Category { get; set; }
        public string Description { get; set; }
        public MeasurementTypes MeasurementType { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}