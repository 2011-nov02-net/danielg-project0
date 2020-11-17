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
        private List<int> orders;


        /// <summary>
        /// Constructor to make new Locations
        /// </summary>
        public Location(string city, Dictionary<string, int> inventory)
        {
            City = city;
            Inventory = inventory;
            Orders = new List<int>();
        }


        public Location(string location, int id)
        {
            CityLocation = location;
            Id = id;

        }

        /// <summary>
        /// Constructor to create store from db with an inventory.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="id"></param>
        /// <param name="inventory"></param>
        public Location(string location, int id, Dictionary<string, int> inventory)
        {
            CityLocation = location;
            Id = id;
            Inventory = inventory;
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
        public List<int> Orders { get => orders; set => orders = value; }

        /// <summary>
        /// Generated property to set the city of a Store
        /// </summary>
        public string CityLocation { get; }
        /// <summary>
        /// Generated Property to set the ID of a store
        /// </summary>
        public int Id { get; }


        /// <summary>
        /// Check if store has enough inventory to staisfy an order
        /// </summary>
        public bool CheckInventory(IOrder order)
        {
            foreach (var product in order.CurrentOrder)
            {
                var quantityStocked = Inventory[product.Key];
                if (product.Value > quantityStocked)
                {
                    return false;
                }
                
            }
            return true;
        }


        public void OrderPlaced(IOrder order)
        {
            if (CheckInventory(order))
            {

            }
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


    }
}
