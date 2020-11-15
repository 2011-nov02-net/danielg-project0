using System;
using System.Collections.Generic;
using StoreProject.Library.Customer;

namespace StoreProject.Library.Order
{
    public class Order : IOrder
    {
        /// <summary>
        /// Private fields to store data pertaining to an order
        /// </summary>
        private string _location;
        private CustomerClass _customer;
        
        private IDictionary<Product, int> _currentOrder;
        private int[] _amounts;
        private static int _orderNumberStatic = 100;
        private int _orderNumber;

        /// <summary>
        /// Constructor used to create an order
        /// </summary>
        public Order(string location, CustomerClass customer, int[] amounts)
        {
            Location = location;
            Customer = customer;
            CurrentOrder = new Dictionary<Product, int>();
            Amounts = amounts;
        }

        /// <summary>
        /// roperty to get or set the location of an order
        /// </summary>
        public string Location { get => _location; set => _location = value; }

        /// <summary>
        /// Property to get or set the customer of an order
        /// </summary>
        public CustomerClass Customer { get => _customer; set => _customer = value; }

        /// <summary>
        /// Property to get or set the Current Order
        /// </summary>
        public IDictionary<Product, int> CurrentOrder { get => _currentOrder; set => _currentOrder = value; }

        /// <summary>
        /// Set the order number with the static amount so that it is incremented each new order
        /// </summary>
        public int OrderNumber { get => _orderNumber; set { _orderNumber = _orderNumberStatic++; } }

        /// <summary>
        /// Set the amounts of each product to buy
        /// </summary>
        public int[] Amounts { get => _amounts; set => _amounts = value; }
        


        public void AddToOrder(Product product, int amount)
        {
            CurrentOrder.Add(product, amount);
        }




    }
}
