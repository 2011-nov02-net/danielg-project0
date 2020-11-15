using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreProject.Library;
using StoreProject.Library.Order;
using StoreProjectDB.DataModel;

namespace StoreProject
{
    class Program
    {
        static DbContextOptions<danielGProj0DBContext> s_dbContextOptions;
        

        

        //static danielGProj0DBContext

        public static void Main(string[] args)
        {
            using var logStream = new StreamWriter("ef-logs.txt");
            var connectionString = ConnectionString._connectionString;
            var optionsBuilder = new DbContextOptionsBuilder<danielGProj0DBContext>();
            
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.LogTo(logStream.Write, LogLevel.Information);
            s_dbContextOptions = optionsBuilder.Options;
            

            while (true)
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("Welcome to Dumb McDonald's");
                Console.WriteLine("--------------------------");
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
                    CustomerView custView = new CustomerView();
                }
                else if (input == "v")
                {
                    DisplayCustomers();
                }
                else if (input == "x") 
                {
                    break;
                }

            }
        }

        static void DisplayCustomers()
        {
            using var context = new danielGProj0DBContext(s_dbContextOptions);

            IQueryable<Customer> customers = context.Customers;

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Name} {customer.Id}");
            }
        }
    }
}
