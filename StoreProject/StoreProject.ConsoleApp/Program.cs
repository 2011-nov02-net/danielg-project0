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
        

        public static void Main(string[] args)
        {

            // Setting up the dbConnection Options
            using var logStream = new StreamWriter("ef-logs.txt");
            var connectionString = ConnectionString._connectionString;
            var optionsBuilder = new DbContextOptionsBuilder<danielGProj0DBContext>();
            
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.LogTo(logStream.Write, LogLevel.Information);
            s_dbContextOptions = optionsBuilder.Options;


            // Enter Program Execution
            while (true)
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("Welcome to Dumb McDonald's");
                Console.WriteLine("--------------------------");
                Console.WriteLine("Are You: ");
                Console.WriteLine("Manager: (m)");
                Console.WriteLine("Customer: (c)");
                Console.WriteLine("Exit (x)");

                var input = Console.ReadLine();

                if (input == "m")
                {
                    ManagerView manView = new ManagerView(s_dbContextOptions);
                }
                else if (input == "c")
                {
                    CustomerView custView = new CustomerView(s_dbContextOptions);
                }
                else if (input == "x") 
                {
                    break;
                }

            }
        }
    }
}
