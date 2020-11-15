using System;
using System.Collections.Generic;

namespace StoreProject.Library.Customer
{
    public class CustomerClass 
    {
        // Private fields to store data specific to the customer.
        private string _nameFirst;
        private string _nameLast;
        private List<IOrder> _pastOrders;
        private List<Product> _shoppingCart;


        /// <summary>
        /// Constructor giving Customer initial state of full name and an ID. Plus
        ///    initialize the pastOrders list.
        /// </summary>
        public CustomerClass(string firstName, string lastName)
        {
            NameFirst = firstName;
            NameLast = lastName;
            PastOrders = new List<IOrder>();
            
        }

        /// <summary>
        /// Public Properties to get the Name of the Customers
        /// </summary>
        public string NameLast { get => _nameLast; set => _nameLast = value; }
        public string NameFirst { get => _nameFirst; set => _nameFirst = value; }


        /// <summary>
        /// Property to get or set the pastOrders list
        /// </summary>
        public List<IOrder> PastOrders { get => _pastOrders; set => _pastOrders = value; }

        /// <summary>
        /// Property to change or get the value of the shopping cart
        /// </summary>
        public List<Product> ShoppingCart { get => _shoppingCart; set => _shoppingCart = value; }

        public void printDetails()
        {
            Console.WriteLine("First Name: " + NameFirst + ", Last Name: " + NameLast);
        }


        public void PlaceOrder()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IOrder> RecallOrders(string id)
        {
            throw new NotImplementedException();
        }
    }
}
