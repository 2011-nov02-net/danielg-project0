using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StoreProject.Library;
using StoreProject.Library.Customer;
using StoreProject.Library.Order;
using StoreProjectDB.DataModel;

namespace StoreProject
{
    public class CustomerView
    {
        /// <summary>
        /// Create a list field to fill with the customers that have been created
        /// </summary>
        List<CustomerClass> customers = new List<CustomerClass>();

        // Set the count of customers field to 0 so I can use logic to see
        //      if it has been set or not
        private CustomerClass currentCustomer;

        /// <summary>
        /// Creating field that I will assign as the current location when a user picks one
        /// </summary>
        private Location currentLocation;

        /// <summary>
        /// Creating the field that I will assign the Customer Repository
        ///     with context options to
        /// </summary>
        private CustomerRepository cusRepo;

        /// <summary>
        /// Constructor passing in dbcontextoptions so I can create a Customer Repository
        ///     and pass in the context options that I set up in the Main method
        /// </summary>
        public CustomerView(DbContextOptions<danielGProj0DBContext> contextOptions)
        {
            cusRepo = new CustomerRepository(contextOptions);

            BeACustomer();
        }

        /// <summary>
        /// Method that runs when a user picks to be a customer. Has all of the functionality for
        ///     signing in/creating customer, placing orders, viewing past orders, etc.
        /// </summary>
        public void BeACustomer()
        {
            Console.WriteLine("-------------");
            Console.WriteLine("New Customer? (n)");
            Console.WriteLine("Returning Customer? (r)");

            while (true)
            {
                // Let customer make account or find themsleves if returning
                var input = Console.ReadLine();

                if (input == "n")
                {
                    //Create new Customer
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Please Type in Your Full Name: ");
                    var fullName = Console.ReadLine();

                    //Check name string to make sure it somewhat resembles a name
                    if (String.IsNullOrWhiteSpace(fullName))
                    {
                        Console.WriteLine("Please Enter a Valid Full Name");
                        fullName = Console.ReadLine();
                    }
                    // Create new ConsoleApp Customer based on name provided
                    CustomerClass newCust = new CustomerClass(fullName);
                    // Add Customer to DB
                    cusRepo.CreateCustomerInDb(newCust);


                    //Divert control to the account made block below- for "sign in"
                    input = "r";

                }
                if (input == "r")
                {
                    Console.WriteLine("--------------");
                    Console.WriteLine("Find Your ID: ");
                    //make customers array
                    var customers = cusRepo.GetAllCustomers();

                    //print out customer Names and IDs
                    foreach (var cust in customers)
                    {
                        cust.printDetails();
                    }

                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Please Enter Your ID: ");
                    Console.WriteLine("Or Exit: (x)");

                    // Get amount of customers in database
                    var count = cusRepo.GetAmountOfCustomers();

                    // This search might be a problem considering its not by "name", but i have
                    //      the names and Ids displayed so it kind of is the same thing.
                    //      It's just better to search by Primary Key(Id)
                    var id = Console.ReadLine();

                    if (id == "x")
                    {
                        break;
                    }
                    // Create ID as integer because it returns from the console as string
                    //   So i need to cast it in the try
                    int iDInt = 0;

                    // Try and cast the id, if it doesnt work catch the error.
                    try
                    {
                        iDInt = int.Parse(id);
                    }
                    catch (InvalidCastException)
                    {
                        Console.WriteLine("Please Enter a Valid ID");
                        id = Console.ReadLine();
                    }
                    

                    // If id is not in the range of customers, make customer enter again
                    if ((iDInt < 1) || (iDInt > count))
                    {
                        Console.WriteLine("Please Enter a Valid ID: ");
                        id = Console.ReadLine();
                    }
                    iDInt = int.Parse(id);
                    // Set the "logged in" customer based on what the user provided as id
                    currentCustomer = cusRepo.GetCustomerFromID(iDInt);
                    // Divert control to the found block below
                    input = "found";

                }
                if (input == "found")
                {
                    // Customer "Signed in" Welcome Screen
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine($"Welcome {currentCustomer.Name}!!");
                    Console.WriteLine("Would You Like To: ");
                    Console.WriteLine("Place an Order: (p)");
                    Console.WriteLine("View Your Order History: (v)");
                    Console.WriteLine("Exit: (x)");
                    var custChoice = Console.ReadLine();
                    // Customer chooses to place an order
                    if (custChoice == "p")
                    {
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Choose A Location: ");
                        // Ask Customer which store they want to place the order at(still need to print the list of stores)-------------
                        var location = Console.ReadLine();
                        int storeID = 0;
                        int storeCount = cusRepo.GetNumberOfStores();

                        // Try to parse the string taken from the customer into an int
                        try
                        {
                            storeID = int.Parse(location);
                        }
                        catch (InvalidCastException)
                        {
                            Console.WriteLine("Please Enter a Valid ID");
                            location = Console.ReadLine();
                        }

                        // If storeID that customer provides is not valid, make them re-enter it.
                        if ((storeID < 1) || (storeID > storeCount))
                        {
                            Console.WriteLine("Please Enter a Valid Store ID: ");
                            location = Console.ReadLine();
                        }
                        storeID = int.Parse(location);

                        var inventory = cusRepo.CreateStoreInventory(storeID);
                        currentLocation = cusRepo.CreateStoreWithInventory(storeID);
                        // Ask customer how many items they want of each item in stock
                        foreach (var item in currentLocation.Inventory)
                        {
                            while (true)
                            {
                                // For each item in stock, ask customer how many they want then add their choice to
                                //      the customers cart.
                                Console.WriteLine($"How many {item.Key}'s would you like? ");
                                var desired = Console.ReadLine();
                                int tryToParse;
                                var desiredInt = int.TryParse(desired, out tryToParse);
                                var worked = currentCustomer.AddToCart(item.Key, tryToParse);
                                if (worked == true)
                                {
                                    break;
                                }
                            }
                        }
                        // Create the console app order so i can add a price send it to a location and
                        IOrder thisOrder = new Order(currentLocation, currentCustomer);
                        // Get list of products so i can get the total cost of the order and set it
                        List<StoreProject.Library.Product> products = cusRepo.GetProducts();
                        // Set the total cost of the order using the list of products at the current time(Name, price)
                        thisOrder.CalculateTotal(products);

                        // Place Order at location
                        // This might need to return a bool to make sure I even send the order to the database
                        currentLocation.OrderPlaced(thisOrder);

                        // Send the order that the user just made to the database.
                        cusRepo.SendOrderToDB(thisOrder);

                        // Push the Order that was made to 
                        // Stop execution just for a minute(-----------TEMP----------------------)
                        Console.WriteLine("Pause");
                        var read = Console.ReadLine();

                    }
                    // Customer chooses to view their order history
                    if (custChoice == "v")
                    {

                    }
                    // Customer choooses to exit
                    if (custChoice == "x")
                    {
                        break;
                    }
                }

                break;
            }
        }
    }
}
