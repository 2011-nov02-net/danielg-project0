using System;
using System.Collections;
using System.Collections.Generic;
using StoreProject.Library.Order;

namespace StoreProject.Library
{
    public class Location
    {

        /// <summary>
        /// Private fields to store city, the inventory dictionary, and the list of orders.
        /// </summary>
        private string _city;
        private Dictionary<string, int> _inventory;
        private List<IOrder> orders;


        /// <summary>
        /// Constructor to make new Locations
        /// </summary>
        public Location(string city, Dictionary<string, int> inventory)
        {
            City = city;
            Inventory = inventory;
            Orders = new List<IOrder>();
        }

        public Location(string location, int id)
        {
            CityLocation = location;
            Id = id;

        }


        /// <summary>
        /// Property to get and set the City.
        /// </summary>
        public string City { get => _city; set => _city = value; }

        /// <summary>
        /// Property to get and set the inventory
        /// </summary>
        public Dictionary<string, int> Inventory { get => _inventory; set => _inventory = value; }

        /// <summary>
        /// Property to get and set the Orders list
        /// </summary>
        public List<IOrder> Orders { get => orders; set => orders = value; }

        /// <summary>
        /// Generated property to set the city of a Store
        /// </summary>
        public string CityLocation { get; }
        /// <summary>
        /// Generated Property to set the ID of a store
        /// </summary>
        public int Id { get; }



        public void OrderPlaced(IOrder order)
        {

        }

        public void createInventory(Dictionary<Product, int> inventory)
        {

        }

        public void PrintOrderHistory()
        {
            foreach (var order in orders)
            {
                // Add function in order to print its details out.
                
            }
        }


        public void PrintDetails()
        {
            Console.WriteLine($"Dumb Mcdonalds in: ({CityLocation}), StoreID: ({Id})");
        }


        //I will implement this later but for now it is not as important to getting the functionality done.
        //public void AddInventory(Product product, int amount)
        //{

        //}
    }
}
