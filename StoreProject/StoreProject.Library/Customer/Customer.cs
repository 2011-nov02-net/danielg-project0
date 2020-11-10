using System;
using System.Collections.Generic;

namespace StoreProject.Library.Customer
{
    public class Customer : ICustomer
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
            Id = ID;
        }


        // Public Properties to get the value of the Customers
        public string NameFirst { get { return _nameFirst; } set { value = _nameFirst; } }
        public string NameLast { get { return _nameLast; } set { value = _nameLast; } }
        public string Id { get { return _id; } set { value = _id; } }

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
