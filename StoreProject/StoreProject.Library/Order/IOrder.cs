using System;
using System.Collections.Generic;
using StoreProject.Library;

namespace StoreProject
{
    public interface IOrder
    {

        public string Location { get; set; }
        public string Customer { get; set; }
        public IDictionary<Product, int> CurrentOrder { get; set; }


    }
}
