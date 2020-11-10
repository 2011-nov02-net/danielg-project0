using System;
using System.Collections.Generic;

namespace StoreProject.Library.Order
{
    public class Order : IOrder
    {
        private string location;
        private string customer;
        private string dateAndTime;

        private IDictionary<Product, int> _currentOrder;


        public Order(string location, string customer, string dateAndTime)
        {
            Location = location;
            Customer = customer;
            DateAndTime = dateAndTime;
        }


        public string Location { get => location; set => location = value; }
        public string Customer { get => customer; set => customer = value; }
        public string DateAndTime { get => dateAndTime; set => dateAndTime = value; }

        public void AddToOrder(Product product, int amount)
        {
            //if ()
        }


    }
}
