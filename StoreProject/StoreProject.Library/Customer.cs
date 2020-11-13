using System;
using System.Collections.Generic;

namespace StoreProject.Library.Customer
{
    public class Customer 
    {
        // Private fields to store data specific to the customer.
        private string _nameFirst;
        private string _nameLast;
        private int _id;
        private static int _idStatic = 001;
        private List<IOrder> _pastOrders;

        /// <summary>
        /// Constructor giving Customer initial state of full name and an ID. Plus
        ///    initialize the pastOrders list.
        /// </summary>
        public Customer(string firstName, string lastName)
        {
            NameFirst = firstName;
            NameLast = lastName;
            PastOrders = new List<IOrder>();
            _idStatic++;
        }

        /// <summary>
        /// Public Properties to get the Name of the Customers
        /// </summary>
        public string NameLast { get => _nameLast; set => _nameLast = value; }
        public string NameFirst { get => _nameFirst; set => _nameFirst = value; }

        /// <summary>
        /// Property using static field to increment the customer id
        /// </summary>
        public int ID { get => _idStatic; set { _id = _idStatic++; } }

        /// <summary>
        /// Property to get or set the pastOrders list
        /// </summary>
        public List<IOrder> PastOrders { get => _pastOrders; set => _pastOrders = value; }
        

        public void printDetails()
        {
            Console.WriteLine("First Name: " + NameFirst + ", Last Name: " + NameLast + ", ID: " + ID.ToString());
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
