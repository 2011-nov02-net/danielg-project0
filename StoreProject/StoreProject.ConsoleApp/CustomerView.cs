using System;
using System.Collections.Generic;
using StoreProject.Library.Customer;

namespace StoreProject
{
    public class CustomerView
    {
        List<CustomerClass> customers = new List<CustomerClass>();
        private int customerId;
        //In here, I can possibly set up initial state like get the customer ID which is helpful for orders and stuff
        // In the constructors, Ill probably call a function that basically handles all of the stuff a customer can
        //      go through. 
        public CustomerView()
        {
            updateCustomers();
            BeACustomer();
        }

        public void updateCustomers()
        {
            customers = DataHolderClass.customers;
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
                    Console.WriteLine("Please Type Yor First Name: ");
                    var firstName = Console.ReadLine();
                    Console.WriteLine("Please Type Yor Last Name: ");
                    var lastName = Console.ReadLine();
                    CustomerClass newCust = new CustomerClass(firstName, lastName);
                    DataHolderClass.customers.Add(newCust);

                    //Divert control to the account made block below
                    input = "m";



                    

                }
                if (input == "r")
                {
                    foreach (var cust in customers)
                    {
                        cust.printDetails();
                    }

                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Please Enter Your Full Name: ");
                    var name = Console.ReadLine();



                    // Divert control to the found block below
                    input = "f";

                }
                if (input == "m" || input == "f")
                {
                    Console.WriteLine("-------------------");
                    Console.WriteLine("Would You Like To: ");
                    Console.WriteLine("Place an Order: (p)");
                    Console.WriteLine("View Your Order History: (v)");
                    var custChoice = Console.ReadLine();
                    if (custChoice == "p")
                    {
                        //Place an Order 
                    }
                    if (custChoice == "v")
                    {

                    }
                }
            }
        }



    }
}
