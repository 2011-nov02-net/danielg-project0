using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreProject.Library;
using StoreProject.Library.Customer;
using StoreProjectDB.DataModel;

namespace StoreProject
{
    public class ManagerView
    {
        /// <summary>
        /// Create a List field to fill with locations the manager can view
        /// </summary>
        List<Location> locations;
        /// <summary>
        /// Creating the field that I will assign the Manager Repository with
        ///     Context options to
        /// </summary>
        private ManagerRepository manRepo;

        

        /// <summary>
        /// Constructor passing in dbcontextoptions so I can create a Manager Repository
        ///     and pass in the context options that I set up in the Main method
        /// </summary>
        public ManagerView(DbContextOptions<danielGProj0DBContext> contextOptions)
        {

            manRepo = new ManagerRepository(contextOptions);
            
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
                    Console.WriteLine("-------------");
                    Console.WriteLine("Choose a Store: ");

                    // Get list of stores from database
                    var stores = manRepo.GetStores();
                    // Iterate through store list and print out stores
                    foreach (var store in stores)
                    {
                        store.PrintDetails();
                    }

                    Console.WriteLine("------------------------------------------------");
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
                    if (city == "new york")
                    {
                        Location result;
                        try
                        {
                            result = (Location)(from l in locations where l.City == "New York" select l);
                            var orders = result.Orders;
                            foreach (var order in orders)
                            {
                                //Add function in Location class to print out order history
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Location not found, Error Message: " + e.Message);
                        }


                    }
                    if (city == "norwich")
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
                        catch (Exception e)
                        {
                            Console.WriteLine("Location not found, Error Message: " + e.Message);
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
