using System;
using System.Collections;
using System.Collections.Generic;
using StoreProject.Library.Order;

namespace StoreProject.Library
{
    public class Location
    {

        //The inventory dictionary. This contains the products and the number in stock
        private IDictionary<string, int> _inventory;
        private string _city;



        public Location(string city, IDictionary<string, int> inventory)
        {
            _city = city;
            _inventory = inventory;

        }

        // This is shorthand syntax for getting the city/inventory
        //   No curly braces are needed because there is no set only get
        public string City => _city;
        public IDictionary<string, int> Inventory => _inventory;



        public void OrderPlaced(IOrder order)
        {

        }


        //I will implement this later but for now it is not as important to getting the functionality done.
        //public void AddInventory(Product product, int amount)
        //{

        //}
    }
}
