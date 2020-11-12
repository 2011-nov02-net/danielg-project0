using System;
using System.Collections;
using System.Collections.Generic;
using StoreProject.Library.Order;

namespace StoreProject.Library
{
    public class Location
    {

        //The inventory dictionary. This contains the products and the number in stock
        
        private string _city;
        private int _bigMac;
        private int _quarterPounder;
        private int _cheeseBurger;
        private int _mcflurry;
        private List<int> orders;

        public Location()
        {
            Console.WriteLine("Paramaterless Constructor");
        }


        //Constructor to make new Locations
        public Location(string city, int macs, int qps, int burgers, int flurry)
        {
            City = city;
            BigMac = macs;
            QuarterPounder = qps;
            CheeseBurger = burgers;
            Mcflurry = flurry;
            Orders = new List<int>();
        }


        // These are the properties for the stock.
        public int Mcflurry { get => _mcflurry; set => _mcflurry = value; }
        public int CheeseBurger { get => _cheeseBurger; set => _cheeseBurger = value; }
        public int QuarterPounder { get => _quarterPounder; set => _quarterPounder = value; }
        public int BigMac { get => _bigMac; set => _bigMac = value; }
        //Property to get and set the City.
        public string City { get => _city; set => _city = value; }
        //Set/Access the List of Orders
        public List<int> Orders { get => orders; set => orders = value; }

        public void OrderPlaced(IOrder order)
        {

        }


        //I will implement this later but for now it is not as important to getting the functionality done.
        //public void AddInventory(Product product, int amount)
        //{

        //}
    }
}
