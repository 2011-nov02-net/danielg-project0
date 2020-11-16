using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StoreProject.Library.Customer;
using StoreProjectDB.DataModel;

namespace StoreProject
{
    public class CustomerView
    {
        List<CustomerClass> customers = new List<CustomerClass>();
        private int customerId;

        private CustomerRepository cusRepo;

        /// <summary>
        /// Constructor passing in dbcontextoptions so I can create a Customer Repository
        /// And pass in the context optoins that I set up in the Main method
        /// </summary>
       
        public CustomerView(DbContextOptions<danielGProj0DBContext> contextOptions)
        {
            cusRepo = new CustomerRepository(contextOptions);

            BeACustomer();
        }

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

                    int iDInt = 0;

                    try
                    {
                        iDInt = int.Parse(id);
                    }
                    catch (InvalidCastException e)
                    {
                        Console.WriteLine("Please Enter a Valid ID");
                        id = Console.ReadLine();
                    }



                    if ((iDInt < 1) || (iDInt > count))
                    {
                        Console.WriteLine("Please Enter a Valid ID");
                        id = Console.ReadLine();
                    }

                    
          
                    


                    // Divert control to the found block below
                    input = "found";

                }
                if (input == "made" || input == "found")
                {
                    Console.WriteLine("-------------------");
                    Console.WriteLine("Would You Like To: ");
                    Console.WriteLine("Place an Order: (p)");
                    Console.WriteLine("View Your Order History: (v)");
                    Console.WriteLine("Exit: (x)");
                    var custChoice = Console.ReadLine();
                    if (custChoice == "p")
                    {
                        //Place an Order 
                    }
                    if (custChoice == "v")
                    {

                    }
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
