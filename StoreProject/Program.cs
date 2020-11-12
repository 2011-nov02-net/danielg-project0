using System;
using System.Collections;
using System.Collections.Generic;
using StoreProject.Library;
using StoreProject.Library.Order;

namespace StoreProject
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonFilePersistence JsonFilePersistence = new JsonFilePersistence();
            XMLFilePersistence XMLFilePersistence = new XMLFilePersistence();
            while (true)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Welcome to Dumb McDonald's. Pick Up Orders Only");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Would You Like To: ");
                Console.WriteLine("Place an Order: (o)");
                Console.WriteLine("Create New Customer: (c)");
                Console.WriteLine("Search for a Customer by Name: (sc)");
                Console.WriteLine("Search for a Location: (sl)");
                Console.WriteLine("Quit: (q)");

                var input = Console.ReadLine();

                //List<string> words = new List<string>();
                //words.Add("word1");
                //words.Add("word2");
                //words.Add("word3");
                //JsonFilePersistence.WriteStrings(words);


                //Console.ReadLine();

                //List<string> retWords = JsonFilePersistence.ReadStrings();
                //retWords.Add("words4");

                //JsonFilePersistence.WriteStrings(retWords);

                //Console.WriteLine(retWords);

                

                Location loc = new Location("New York", 29, 48, 84, 79);
                Location loc1 = new Location("Boston", 74, 28, 64, 93);

                List<Location> locs = new List<Location>();
                locs.Add(loc);
                locs.Add(loc1);

                JsonFilePersistence.WriteLocation(locs);

                Console.ReadLine();

                List<Location> locats = JsonFilePersistence.ReadLocation();
                
                Location locN = new Location("Norwich", 58, 39, 29, 22);
                locats.Add(locN);

                JsonFilePersistence.WriteLocation(locats);

                Console.WriteLine(locats);








                //var order1 = new Order("a", "b", "c");
                //Console.WriteLine(order1.Customer);

                //JsonFilePersistence.WriteOrder(order1);





                // To make sure my Json writer is working, I need to create a Location
                //   with an inventory and write that to the file

                //Create a few products then add them to the dictionary

                Product prod = new Product("Dumb Big Mac", 5);
                Product prodQ = new Product("Dumb Quarter Pounder", 4);
                Product prodM = new Product("Dumb McFlurry", 3);
                Product prodC = new Product("Dumb CheeseBurger", 1);


                string city = "New York";
                //Location loc = new Location(city, InventoryDict);


                // Put other methods like this (add order, add customer) into another file so i can just call the method
                //      when the user wants that to happen.
                //JsonFilePersistence.WriteLocation(loc);



                //JsonFilePersistence.ReadLocation();


                //XMLFilePersistence.LocationToXML(loc);

            }
        }
    }
}
