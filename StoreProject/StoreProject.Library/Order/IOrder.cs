using System;
using System.Collections.Generic;
using StoreProject.Library;
using StoreProject.Library.Customer;

namespace StoreProject
{
    public interface IOrder
    {

        public Location Location { get; set; }
        public CustomerClass Customer { get; set; }
        //public IDictionary<string, int> CurrentOrder { get; set; }

        public void CalculateTotal(List<Product> products);


    }
}
