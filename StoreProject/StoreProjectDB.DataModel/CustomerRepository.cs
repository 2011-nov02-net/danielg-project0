using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StoreProject.Library.Customer;
using System.Linq;

namespace StoreProjectDB.DataModel
{
    public class CustomerRepository
    {
        /// <summary>
        /// Create field for context options that will be set using the context options from
        /// Program.cs -> Customer View -> right her
        /// </summary>
        private readonly DbContextOptions<danielGProj0DBContext> _contextOptions;

        /// <summary>
        /// Constructor with context options parameter that gets passed from Customer View
        /// </summary>
        public CustomerRepository(DbContextOptions<danielGProj0DBContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }


        public List<CustomerClass> GetAllCustomers()
        {
            // Create Context
            using var context = new danielGProj0DBContext(_contextOptions);
            // Get DB Object list of customers
            var dbCustomers = context.Customers.ToList();
            // Make DB list into Console Customers list
            var appCustomers = dbCustomers.Select(c => new CustomerClass(c.Name, c.Id)).ToList();
            // return customer list
            return appCustomers;
        }


        public void CreateCustomerInDb(CustomerClass customer)
        {
            // Create Context
            using var context = new danielGProj0DBContext(_contextOptions);
            // Create a database customer using info from ConsoleApp Customer
            Customer dbCustomer = new Customer
            {
                Name = customer.Name
            };

            // Add Customer to database and save change
            context.Customers.Add(dbCustomer);
            context.SaveChanges();
        }


        public int GetAmountOfCustomers()
        {
            // Create Context
            using var context = new danielGProj0DBContext(_contextOptions);
            // Count the number of entries in customer table
            var custCount = context.Customers.Count();

            return custCount;

        }


        public CustomerClass GetCustomerFromID(int id)
        {
            // Create Context
            using var context = new danielGProj0DBContext(_contextOptions);
            // Find the database entry for the specific Customer
            var customer = context.Customers.Find(id);
            // Create the Console Customer from the database customer
            CustomerClass appCustomer = new CustomerClass(customer.Name, customer.Id);

            return appCustomer;
        }



        public Dictionary<string, int> CreateStoreInventory(int storeID)
        {
            // Create empty dictionary to fill in inventory
            Dictionary<string, int> inventory = new Dictionary<string, int>();
            //SortedList<>
            // Create Context
            using var context = new danielGProj0DBContext(_contextOptions);
            // Get agg inventory items from the database- this is a stores inventory
            var itemsInInventory = context.AggInventories.Where(i => i.StoreId == storeID).ToList();
            // create console inventory with db inventory pieces
            //var inven = itemsInInventory.Select(i => inventory.Add((string)i.Product, (int)i.InStock)).ToDictionary();
            //var invent = itemsInInventory.Select(i => new Dictionary<string, int>() { i.Product, i.InStock });


            Dictionary<string, int> inv = itemsInInventory.ToDictionary(i => i.Product, i => i.InStock);



            return inv;
        }


        public List<StoreProject.Library.Product> GetProducts()
        {
            // Create context
            using var context = new danielGProj0DBContext(_contextOptions);
            // Get the product names and prices- these two methods just make the "products"
            //  that are the key in the dictionary
            var dbProducts = context.Products.ToList();
            // Make the list of products into an a list of app products
            var appProducts = dbProducts.Select(p => new StoreProject.Library.Product(p.Name, p.Price)).ToList();

            return appProducts;
        }










    }
}
