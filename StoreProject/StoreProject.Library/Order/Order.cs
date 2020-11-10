using System;
using System.Collections.Generic;

namespace StoreProject.Library.Order
{
    public class Order : IOrder
    {
        private string _location;
        private string _customer;
        private int _cost;

        private IDictionary<Product, int> _currentOrder;


        public Order(string location, string customer, int cost)
        {
            _location = location;
            _customer = customer;
            _cost = cost;
        }


        public string Location => _location;
        public string Customer => _customer;
        public int Cost => _cost;


        public void AddToOrder(Product product, int amount)
        {
            //if ()
        }


    }
}
