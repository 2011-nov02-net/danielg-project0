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
            while (true)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Welcome to Dumb McDonald's inc.");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Are You A: ");
                Console.WriteLine("Manager: (m)");
                Console.WriteLine("Customer: (c)");

                var input = Console.ReadLine();

                if (input == "m")
                {
                    ManagerView manView = new ManagerView();
                }
                else if (input == "c")
                {

                }


                /*
                Console.WriteLine("Place an Order: (o)");
                Console.WriteLine("Create New Customer: (c)");
                Console.WriteLine("Search for a Customer by Name: (sc)");
                Console.WriteLine("Search for a Location: (sl)");
                Console.WriteLine("Quit: (q)");

                var input = Console.ReadLine();

                

                Location loc = new Location("New York", 29, 48, 84, 79);
                Location loc1 = new Location("Boston", 74, 28, 64, 93);

                loc.Orders.Add(1);
                loc.Orders.Add(2);
                loc.Orders.Add(3);

                loc1.Orders.Add(11);
                loc1.Orders.Add(21);
                loc1.Orders.Add(31);

                List<Location> locs = new List<Location>();
                locs.Add(loc);
                locs.Add(loc1);

                //JsonFilePersistence.WriteLocation(locs);

                Console.ReadLine();

                List<Location> locats = JsonFilePersistence.ReadLocation();

                for (int i = 0; i < locats.Count; i++)
                {
                    Location currLoc = locats[i];
                    if (currLoc.City.Equals("Atlanta")) {
                        currLoc.Orders.Add(100);
                    }
                    
                }
                
                Location locN = new Location("Norwich", 58, 39, 29, 22);

                locN.Orders.Add(1);
                locN.Orders.Add(2);
                locN.Orders.Add(3);

                locats.Add(locN);

                //JsonFilePersistence.WriteLocation(locats);

                Console.WriteLine(locats);
                */
            }
        }
    }
}
