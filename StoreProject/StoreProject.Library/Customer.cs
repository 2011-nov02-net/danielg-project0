using System;
using System.Collections.Generic;

namespace StoreProject.Library.Customer
{
    public class Customer 
    {
        // Private fields to store data specific to the customer.
        private string _nameFirst;
        private string _nameLast;
        private string _id;

        // Constructor giving Customer initial state of full name and an ID
        public Customer(string firstName, string lastName, string ID)
        {
            NameFirst = firstName;
            NameLast = lastName;
            //Id = ID;
        }


        /// <summary>
        /// Public Properties to get the Name of the Customers
        /// </summary>
        public string NameFirst { get => _nameFirst; set => value = _nameFirst; }
        public string NameLast { get => _nameLast; set => value = _nameLast; }

        /// <summary>
        /// Property using static field to increment the customer id
        /// </summary>
        

        public IEnumerable<IOrder> OrderHistory { get ; set; }



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
