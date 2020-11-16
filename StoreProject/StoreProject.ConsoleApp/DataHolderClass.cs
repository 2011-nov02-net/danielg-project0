using System;
using System.Collections.Generic;
using StoreProject.Library;
using StoreProject.Library.Customer;

namespace StoreProject
{
    public static class DataHolderClass
    {
        static DataHolderClass()
        {
            AddLocations();
            AddCustomers();
        }

        internal static List<Location> storeLocations = new List<Location>();
        internal static List<CustomerClass> customers = new List<CustomerClass>();
        internal static List<IOrder> orders = new List<IOrder>();




        /// <summary>
        /// Method to add initial state with customers. I am still going to have the option to add customers, but
        ///     I want a way to sign in 
        /// </summary>
        internal static void AddCustomers()
        {
            CustomerClass cust1 = new CustomerClass("Joe");
            customers.Add(cust1);
            CustomerClass cust2 = new CustomerClass("Donald");
            customers.Add(cust2);
            CustomerClass cust3 = new CustomerClass("Barack");
            customers.Add(cust3);

        }














        /// <summary>
        /// Big Method with sole purpose of adding the locations to the locations array.
        ///     Put in constructor so I have the initial state of the locations
        /// </summary>
        internal static void AddLocations()
        {
            // Use this if I need to refresh the dictionary. Not actually sure if it is refreshed each time the program is run or not
            //      But im guessing it is.
            // storeLocations.Clear();

            // Add initial state for Norwich store
            string cityNor = "Norwich";
            Product bigMac = new Product("Big Mac", 5);
            Product cBurger = new Product("Cheeseburger", 1);
            Product qP = new Product("Quarter Pounder", 3);
            Product mCf = new Product("Mcflurry", 2);
            Dictionary<Product, int> inventory = new Dictionary<Product, int>()
            {
                { bigMac, 10 },
                { cBurger,  15},
                {  qP, 10},
                { mCf, 15 }
            };

            Location location = new Location(cityNor, inventory);
            storeLocations.Add(location);

            // Add initial state for New York Store
            string cityNew = "New York";
            Product bigMacNew = new Product("Big Mac", 7);
            Product cBurgerNew = new Product("Cheeseburger", 2);
            Product qPNew = new Product("Quarter Pounder", 4);
            Product mCfNew = new Product("Mcflurry", 2);
            Dictionary<Product, int> inventoryNew = new Dictionary<Product, int>()
            {
                { bigMacNew, 35 },
                { cBurgerNew,  18},
                {  qPNew, 37},
                { mCfNew, 43 }
            };

            Location locationNew = new Location(cityNew, inventoryNew);
            storeLocations.Add(locationNew);

            // Add initial state for Boston Store
            string cityBos = "Boston";
            Product bigMacBos = new Product("Big Mac", 6);
            Product cBurgerBos = new Product("Cheeseburger", 2);
            Product qPBos = new Product("Quarter Pounder", 3);
            Product mCfBos = new Product("Mcflurry", 3);
            Dictionary<Product, int> inventoryBos = new Dictionary<Product, int>()
            {
                { bigMacBos, 27 },
                { cBurgerBos,  35},
                {  qPBos, 22},
                { mCfBos, 31 }
            };

            Location locationBos = new Location(cityBos, inventoryBos);
            storeLocations.Add(locationBos);
        }

        
    }
}
