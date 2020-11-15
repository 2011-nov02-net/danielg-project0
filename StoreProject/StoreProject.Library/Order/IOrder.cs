using System;
using System.Collections.Generic;
using StoreProject.Library;
using StoreProject.Library.Customer;

namespace StoreProject
{
    public interface IOrder
    {

        public string Location { get; set; }
        public CustomerClass Customer { get; set; }
        public IDictionary<Product, int> CurrentOrder { get; set; }


    }
}
