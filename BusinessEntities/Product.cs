using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BusinessEntities
{
    public class Product : IdObject
    {
        private string _Name;
        private ProductCategories _Category;
        private string _Description;    
        private MeasurementTypes _MeasurementType;
        private decimal? _UnitPrice;

        public string Name
        {
            get => _Name;
            private set => _Name = value;
        }

        public string Description{
            get => _Description;
            private set => _Description = value;
        } 

        public MeasurementTypes MeasurementType
        {
            get => _MeasurementType;
            private set => _MeasurementType = value;
        }

        public decimal? UnitPrice
        {
            get => _UnitPrice;
            private set => _UnitPrice  = value;
        }

        public ProductCategories Category { 
            get => _Category;
            private set => _Category = value;
        }

        public void setName(string name) { 
            _Name = name;
        }
        public void setProductCategories(ProductCategories category) {
            _Category = category;
        }
        public void setDescription( string description) {
            _Description = description;
        }
        public void setMeasurementType(MeasurementTypes measurementType) { 
            _MeasurementType = measurementType;
        }
        public void setUnitPrice(decimal? unitPrice) {
            _UnitPrice = unitPrice;
        }

    }
}
