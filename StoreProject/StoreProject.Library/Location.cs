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

        public Location()
        {
            Console.WriteLine("Paramaterless Constructor");
        }

        public Location(string city, int macs, int qps, int burgers, int flurry)
        {
            City = city;
            BigMac = macs;
            QuarterPounder = qps;
            CheeseBurger = burgers;
            Mcflurry = flurry;
        }

        // This is shorthand syntax for getting the city/inventory
        //   No curly braces are needed because there is no set only get
        


        // These are the properties for the stock.
        public int Mcflurry { get => _mcflurry; set => _mcflurry = value; }
        public int CheeseBurger { get => _cheeseBurger; set => _cheeseBurger = value; }
        public int QuarterPounder { get => _quarterPounder; set => _quarterPounder = value; }
        public int BigMac { get => _bigMac; set => _bigMac = value; }
        public string City { get => _city; set => _city = value; }

        public void OrderPlaced(IOrder order)
        {

        }


        //I will implement this later but for now it is not as important to getting the functionality done.
        //public void AddInventory(Product product, int amount)
        //{

        //}
    }
}
