using Common.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class Order: IdObject
    {
        private OrderType _OrderType;
        private Guid _UserId;
        private List<OrderItem> _Productlist = new List<OrderItem>();
        private decimal _Price;
        private decimal _Tax;
        private decimal _TotalPrice;
        private Address _Address;

        public OrderType OrderType { 
            get =>_OrderType;
            private set => _OrderType = value; 
        }
        public Guid UserId { 
            get=>_UserId ; 
            private set=> _UserId = value;
        }
        public Decimal Price
        {
            get => _Price;
            private set => _Price = value;
        }

        public Decimal Tax  
        {
            get => _Tax;
            private set => _Tax = value;
        }

        public Decimal TotalPrice
        {
            get => _TotalPrice;
            private set => _TotalPrice = value;
        }

        public List<OrderItem> Productlist
        {
            get => _Productlist;
            private set => _Productlist.Initialize(value);
        }
        
        public Address Address
        {
            get => _Address;
            private set => _Address = value;
        }

        public void setUserID(Guid guid) { 
            _UserId = guid;
        }

        public void setOrderType(OrderType orderType) {
            if (orderType == OrderType.shipping)
            {
                if (_Address != null)
                {
                    setAddress(_Address);
                }
                else
                {
                    throw new ArgumentNullException("Address is manadatory for Shipping Order");
                }
            }
            else if (orderType == OrderType.pickup)
            {
                setAddress(null);
            }
            _OrderType = orderType;
        }

        public void setProducts(IEnumerable<OrderItem> products)
        {
            _Productlist.Initialize(products);
        }

        public void setPrice(decimal price) { 
            _Price = price;
        }

        public void setTax(decimal tax) { 
            _Tax = tax;
        }

        public void setTotalPrice(decimal totalPrice) { 
            _TotalPrice = totalPrice;
        }
                
        public void setAddress(Address address) { 
            _Address = address;
        }

    }

    public class OrderItem { 
        public Guid ProductId { get; set; }
        public decimal Quantity { get; set; }   
    }

    public class Address {
        public string AddressLine1;
        public string AddressLine2;
        public string city;
        public string State;
        public string Zip;
    }
}
