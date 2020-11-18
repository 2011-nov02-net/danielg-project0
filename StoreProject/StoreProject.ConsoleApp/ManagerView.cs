using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StoreProject.Library;
using StoreProjectDB.DataModel;

namespace StoreProject
{
    public class ManagerView
    {

        /// <summary>
        /// Creating the field that I will assign the Manager Repository with
        ///     Context options to
        /// </summary>
        private ManagerRepository manRepo;

        /// <summary>
        /// When the manager picka a location, this field will get filled with orders and
        ///     an inventory that the manager can look at
        /// </summary>
        Location currentLocation;

        /// <summary>
        /// Get list of all of the products a store sells
        /// </summary>
        List<Library.Product> storeProducts;

        /// <summary>
        /// Constructor passing in dbcontextoptions so I can create a Manager Repository
        ///     and pass in the context options that I set up in the Main method
        /// </summary>
        public ManagerView(DbContextOptions<danielGProj0DBContext> contextOptions)
        {

            manRepo = new ManagerRepository(contextOptions);
            
            BeAManager();
        }


        /// <summary>
        /// Method that runs when user picks to be a manager. Has functions such as view locations,
        ///     view orders....
        /// </summary>
        public void BeAManager()
        {
            Console.WriteLine("-------------");
            Console.WriteLine("Hello Manager");

            while (true)
            {
                //list out all of the locations
                Console.WriteLine("-------------------");
                Console.WriteLine("-------------------");
                Console.WriteLine("Would you like to: ");
                Console.WriteLine("-------------------");
                Console.WriteLine("View all Store Locations: (v)");
                Console.WriteLine("Exit to Main Screen: (x)");

                var input = Console.ReadLine();

                if (input == "x")
                {
                    break;
                }
                // If user wants to view locations
                if (input == "v")
                {
                    // Print all locations
                    Console.WriteLine("----------------");
                    Console.WriteLine("----------------");
                    Console.WriteLine("Choose a Store: ");
                    Console.WriteLine("----------------");

                    // Get list of stores from database
                    var stores = manRepo.GetStores();
                    // Iterate through store list and print out stores
                    foreach (var store in stores)
                    {
                        store.PrintDetails();
                    }
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("----------------------------------------");
                    // Let user view location orders or exit to all locations
                    Console.WriteLine("Type in a StoreID to view, or exit(x): ");
                    Console.WriteLine("----------------------------------------");
                    // Get manager choice of store to view.
                    var city = Console.ReadLine();

                    if (city == "x")
                    {
                        break;
                    }


                    int storeID = 0;
                    int storeCount = manRepo.GetNumberOfStores();

                    // Try to parse the string taken from the customer into an int
                    try
                    {
                        storeID = int.Parse(city);
                    }
                    catch (InvalidCastException)
                    {
                        Console.WriteLine("Please Enter a Valid ID");
                        city = Console.ReadLine();
                    }

                    // If storeID that customer provides is not valid, make them re-enter it.
                    if ((storeID < 1) || (storeID > storeCount))
                    {
                        Console.WriteLine("Please Enter a Valid Store ID: ");
                        city = Console.ReadLine();
                    }
                    // Get the storeID and turn it into an int
                    storeID = int.Parse(city);
                    // Get the list of orderd based on the store the manager wanted to see
                    currentLocation = manRepo.GetStoreWithOrdersAndInventory(storeID);

                    // Set the list of all of the products a store sells
                    storeProducts = manRepo.GetProducts();
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine($"Viewing Orders at Location: {currentLocation.CityLocation} Branch");
                    Console.WriteLine("------------------------------------------");
                    foreach (var order in currentLocation.Orders)
                    {
                        decimal orderTotal = order.CalculateTotal(storeProducts);
                        Console.WriteLine($"Order Number {order.OrderID} by {order.Customer.Name}, with total cost: ${orderTotal}. Date: ({order.Date})");
                    }

                    // Allow the manager to look at specific products ordered
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Pick an order to view, or exit");
                    Console.WriteLine("------------------------------");
                    var orderToView = Console.ReadLine();

                    if (orderToView == "x")
                    {
                        break;
                    }
                    // Make the int that I will set the order chosen to view
                    int orderIDHere = 0;
                    // Parse that int
                    orderIDHere = int.Parse(orderToView);
                    // Find the order that the manager chose to view the details of
                    var orderChosen = currentLocation.Orders.Find(o => o.OrderID == orderIDHere);

                    foreach (var product in orderChosen.Customer.ShoppingCart)
                    {
                        // print out the product and amount purchased in that specific order
                        Console.WriteLine($"Product: {product.Key}, Amount: ({product.Value}) ");
                    }
                    Console.WriteLine("Enter any key to return to main menu: ");
                    Console.ReadLine();
                }

            }
        }
    }
}

