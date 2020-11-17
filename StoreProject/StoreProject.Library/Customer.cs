using System;
using System.Collections.Generic;

namespace StoreProject.Library.Customer
{
    public class CustomerClass 
    {
        // Private fields to store data specific to the customer.
        private string fullName;
        private List<int> _pastOrders;
        private Dictionary<string, int> shoppingCart;


        /// <summary>
        /// Constructor giving Customer initial state of full name. Plus
        ///    initialize the pastOrders list.
        ///    Use this constructor when creating a Customer from the ConsoleApp
        /// </summary>
        public CustomerClass(string name)
        {
            Name = name;
            PastOrders = new List<int>();
        }

        /// <summary>
        /// Constructor to use when creating customers from the database.
        ///     The database is what gives them the ID
        /// </summary>
        public CustomerClass(string name, int id)
        {
            Name = name;
            Id = id;
            PastOrders = new List<int>();
            ShoppingCart = new Dictionary<string, int>();
        }


        /// <summary>
        /// Property to get or set the pastOrders list
        /// </summary>
        public List<int> PastOrders { get => _pastOrders; set => _pastOrders = value; }

        /// <summary>
        /// Property to change or get the value of the shopping cart
        /// </summary>
        public Dictionary<string, int> ShoppingCart { get => shoppingCart; set => shoppingCart = value; }

        /// <summary>
        /// Property to get or set the name of a customer.
        /// </summary>
        public string Name { get; }
        public int Id { get; }


        /// <summary>
        /// Print customer details (Name and ID)
        /// </summary>
        public void printDetails()
        {
            Console.WriteLine($"Name: ({Name}) ID: ({Id})");
        }

        /// <summary>
        /// I might want to put this logic in order eventually
        /// </summary>
        public bool AddToCart(string productName, int amountDesired)
        {
            if (amountDesired > 10)
            {
                Console.WriteLine($"Too many {productName}'s");
                return false;
            }
            else if (amountDesired < 0)
            {
                Console.WriteLine($"Please enter a valid number of {productName}'s");
                return false;
            }
            ShoppingCart.Add(productName, amountDesired);
            return true;
        }


        public IEnumerable<IOrder> RecallOrders(string id)
        {
            throw new NotImplementedException();
        }
    }
}
