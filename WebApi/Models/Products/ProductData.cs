using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.Products
{
    public class ProductData : IdObjectData
    {
        public ProductData(Product product) : base(product)
        {
            Name = product.Name;
            Category = product.Category;
            Description = product.Description;
            MeasurementType = new EnumData(product.MeasurementType);
            UnitPrice = product.UnitPrice;

        }
        public string Name { get; set; }
        public ProductCategories Category { get; set; }
        public string Description { get; set; } 
        public EnumData MeasurementType { get; set; }
        public decimal? UnitPrice { get; set; } 
 
    }
}    
