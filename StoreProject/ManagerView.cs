using System;
using System.Collections.Generic;
using System.Linq;
using StoreProject.Library;

namespace StoreProject
{
    public class ManagerView
    {

        List<Location> locations = new List<Location>();

        //In here(and customer view, I can set up initial state. )
        public ManagerView()
        {
            locations = DataHolderClass.storeLocations;
            BeAManager();
        }




        public void BeAManager()
        {
            Console.WriteLine("-------------");
            Console.WriteLine("Hello Manager");

            while (true)
            {
                //list out all of the locations
                Console.WriteLine("Would you like to: ");
                Console.WriteLine("View all Store Locations: (v)");
                Console.WriteLine("Exit to Main Screen: (x)");

                var input = Console.ReadLine();
                // If user wants to view locations
                if (input == "v")
                {
                    // Print all locations
                    Console.WriteLine("All of the Locations: ");
                    foreach (var loc in locations)
                    {
                        Console.WriteLine("Location: {0}", loc.City);
                    };
                    // Let user view location orders or exit to all locations
                    Console.WriteLine("Type in a city to view past orders, or exit(x): ");

                    var city = Console.ReadLine();
                    if (city == "boston")
                    {
                        Location result;
                        try
                        {
                            result = (Location)(from l in locations where l.City == "Boston" select l);
                            var orders = result.Orders;
                            foreach (var order in orders)
                            {
                                //Add function in Location class to print out order history
                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Location not found, Error Message: " + e.Message);
                        }
             
                        
                    }
                    else if (city == "new york")
                    {
                        Location result;
                        try
                        {
                            result = (Location)(from l in locations where l.City == "Boston" select l);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Location not found");
                        }
                    }
                }
                else if (input == "x")
                {
                    break;
                }

            }
        }
    }
}
