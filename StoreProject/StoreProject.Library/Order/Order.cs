using System;
using System.Collections.Generic;

namespace StoreProject.Library.Order
{
    public class Order : IOrder
    {
        /// <summary>
        /// Private fields to store data pertaining to an order
        /// </summary>
        private string _location;
        private string _customer;
        private int _cost;
        private IDictionary<Product, int> _currentOrder;
        private static int _orderNumberStatic = 100;
        private int _orderNumber;

        /// <summary>
        /// Constructor used to create an order
        /// </summary>
        public Order(string location, string customer, int cost)
        {
            Location = location;
            Customer = customer;
            Cost = cost;
        }

        /// <summary>
        /// roperty to get or set the location of an order
        /// </summary>
        public string Location { get => _location; set => _location = value; }

        /// <summary>
        /// Property to get or set the customer of an order
        /// </summary>
        public string Customer { get => _customer; set => _customer = value; }

        /// <summary>
        /// Property to get or set the Cost of an order
        /// </summary>
        public int Cost { get => _cost; set => _cost = value; }

        /// <summary>
        /// Property to get or set the Current Order
        /// </summary>
        public IDictionary<Product, int> CurrentOrder { get => _currentOrder; set => _currentOrder = value; }

        /// <summary>
        /// Set the order number with the static amount so that it is incremented each new order
        /// </summary>
        public int OrderNumber { get => _orderNumber; set { _orderNumber = _orderNumberStatic++; } }


        public void AddToOrder(Product product, int amount)
        {
            //if ()
        }




    }
}
